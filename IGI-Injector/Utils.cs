using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using File = System.IO.File;

namespace IGI_Injector
{
    class Utils
    {
        private static string projAppName, cfgDllPath, gameAbsPath, cfgGamePath, keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        internal static List<string> inputDllPaths;
        internal const string GAME = "IGI", CAPTION_CONFIG_ERR = "Config - Error", CAPTION_FATAL_SYS_ERR = "Fatal sytem - Error", CAPTION_APP_ERR = "Application - Error", CAPTION_COMPILER_ERR = "Compiler - Error", PATH_SEC = "PATH", GAME_SEC = "GAME", DLL_SEC = "DLL";
        internal static bool cfgMultiDll = false, cfgAutoInject = false;
        internal static int cfgDelayDll = 10, cfgGameLevel = 1;
        internal static string cfgFile, cfgGameMode = "windowed", injectorFile = @"bin\igi-injector-cmd.exe";
        private static IniParser iniParser;

        internal static bool DllRunner(bool dllInject)
        {
            bool status = false;
            if (inputDllPaths.Count > 0)
            {
                bool gameRunning = IsGameRunning();
                if (gameRunning)
                {
                    string inputDllPath = "";

                    foreach (var dllName in inputDllPaths)
                        inputDllPath += dllName + " ";

                    string injectCmd = injectorFile + ((dllInject) ? " -i " : " -e ") + inputDllPath;
                    ShellExec(injectCmd);
                    status = true;
                }
                else
                {
                    ShowStatusError("IGI game is not running.");
                    status = false;
                }
            }
            else
            {
                ShowStatusError("No DLL files were selected.");
                status = false;
            }
            return status;
        }

        //Create config and save all data to file.
        internal static void CreateConfig(string configFile)
        {
            cfgGamePath = (cfgGamePath is null) ? LocateExecutable(GAME + ".exe") : cfgGamePath;
            bool gameFound = true;

            if (String.IsNullOrEmpty(cfgGamePath))
            {
                ShowWarning("Game path could not be detected automatically! Please select game path in config file", CAPTION_CONFIG_ERR);
                gameFound = false;
            }
            else
            {
                cfgGamePath = cfgGamePath.Substring(0, cfgGamePath.LastIndexOf("\\"));

                if (!File.Exists(cfgGamePath + "\\" + GAME + ".exe"))
                {
                    ShowError("Invalid path selected! Game 'IGI' not found at path '" + cfgGamePath + "'", CAPTION_FATAL_SYS_ERR);
                    gameFound = false;
                }
            }

            //Write Path to config.
            iniParser.Write("game_path", cfgGamePath is null ? " " : cfgGamePath + "\\", PATH_SEC);

            string inputDllPath = "";
            if (inputDllPaths.Count == 1) inputDllPath = inputDllPaths[0];
            else
            {
                foreach (var dllName in inputDllPaths)
                    inputDllPath += dllName + ",";
                inputDllPath.Replace(",", String.Empty);
            }

            iniParser.Write("dll_path", inputDllPath is null ? "\n" : inputDllPath, PATH_SEC);

            //Write vars to config.
            iniParser.Write("multi_dll", cfgMultiDll.ToString(), DLL_SEC);
            iniParser.Write("delay_dll", cfgDelayDll.ToString(), DLL_SEC);
            iniParser.Write("auto_inject_dll", cfgAutoInject.ToString(), DLL_SEC);
            iniParser.Write("game_level", cfgGameLevel.ToString(), GAME_SEC);
            iniParser.Write("game_mode", cfgGameMode, GAME_SEC);

            if (!gameFound) Environment.Exit(1);
        }

        //Read config and load all data from file.
        internal static void ParseConfig()
        {
            projAppName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", String.Empty);
            cfgFile = projAppName + ".ini";
            iniParser = new IniParser(cfgFile);
            try
            {
                if (File.Exists(cfgFile))
                {
                    //Read paths for config.
                    gameAbsPath = iniParser.Read("game_path", PATH_SEC);
                    cfgDllPath = iniParser.Read("dll_path", PATH_SEC);
                    cfgGamePath = (!String.IsNullOrEmpty(gameAbsPath)) ? (gameAbsPath.Trim() + GAME + ".exe") : null;

                    if (cfgDllPath.Contains(","))
                    {
                        var dllPathSplit = cfgDllPath.Split(',');
                        foreach (var dllPath in dllPathSplit)
                            inputDllPaths.Add(dllPath.Trim());
                    }
                    else inputDllPaths.Add(cfgDllPath);

                    //foreach (var dllPath in inputDllPaths) ShowInfo("dllPath: " + dllPath);
                    if (!String.IsNullOrEmpty(inputDllPaths[0]))
                        IGIInjectorUI.mainRef.browseFile.Text = Path.GetFileName(inputDllPaths[0]);

                    //Read properties from config.
                    cfgMultiDll = bool.Parse(iniParser.Read("multi_dll", DLL_SEC));
                    cfgAutoInject = bool.Parse(iniParser.Read("auto_inject_dll", DLL_SEC));
                    cfgDelayDll = Int32.Parse(iniParser.Read("delay_dll", DLL_SEC));
                    cfgGameLevel = Int32.Parse(iniParser.Read("game_level", GAME_SEC));
                    cfgGameMode = iniParser.Read("game_mode", GAME_SEC);
                }
                else
                {
                    ShowWarning("Config file not found in current directory", CAPTION_CONFIG_ERR);
                    CreateConfig(cfgFile);
                }
            }
            catch (FormatException ex)
            {
                if (ex.StackTrace.Contains("bool"))
                    ShowConfigError("multi_dll");
                else if (ex.StackTrace.Contains("Int32"))
                    ShowConfigError("delay_dll or game_level");
            }
        }


        private static void CreateGameShortcut(string linkName, string pathToApp, string gameArgs = "")
        {
            if (!File.Exists(cfgGamePath))
            {
                ShowSystemFatalError("Invalid path selected!\nGame 'IGI' not found at path '" + cfgGamePath + "'");
            }

            var shell = new WshShell();
            string shortcutAddress = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + linkName + ".lnk";

            if (File.Exists(shortcutAddress)) File.Delete(shortcutAddress);

            var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Shortcut for IGI";
            shortcut.Hotkey = "Ctrl+ALT+I";
            shortcut.Arguments = gameArgs;
            shortcut.WorkingDirectory = pathToApp;
            shortcut.TargetPath = cfgGamePath;
            shortcut.Save();
        }

        internal static void CreateGameShortcut()
        {
            if (!File.Exists(GAME + "_full.lnk") || !File.Exists(GAME + "_full.lnk"))
            {
                if (gameAbsPath.Contains("\""))
                    gameAbsPath = gameAbsPath.Replace("\"", String.Empty);
                CreateGameShortcut(GAME + "_full", gameAbsPath);
                CreateGameShortcut(GAME + "_window", gameAbsPath, "window");
            }
        }

        internal static void GameRunner(bool windowed = true, int gameLevel = 1)
        {
            string gameRunCmd;
            bool gameRunning = IsGameRunning();
            if (windowed) gameRunCmd = "start " + GAME + "_window.lnk" + " level" + gameLevel;
            else gameRunCmd = "start " + GAME + "_full.lnk" + " level" + gameLevel;

            if (!gameRunning)
                ShellExec(gameRunCmd);
        }


        internal static void ShowStatusInfo(string text)
        {
            IGIInjectorUI.mainRef.statusLbl.ForeColor = System.Drawing.Color.ForestGreen;
            IGIInjectorUI.mainRef.statusLbl.Text = "INFO: " + text; ;
        }

        internal static void ShowStatusError(string text)
        {
            IGIInjectorUI.mainRef.statusLbl.ForeColor = System.Drawing.Color.Tomato;
            IGIInjectorUI.mainRef.statusLbl.Text = "ERROR: " + text;
        }

        internal static bool IsGameRunning()
        {
            Process[] pname = Process.GetProcessesByName(GAME);
            bool isRunning = pname.Length > 0;
            return isRunning;
        }

        internal static void ShowWarning(string warnMsg, string caption = "WARNING")
        {
            MessageBox.Show(warnMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal static void ShowError(string errMsg, string caption = "ERROR")
        {
            MessageBox.Show(errMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void ShowInfo(string infoMsg, string caption = "INFO")
        {
            MessageBox.Show(infoMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void ShowSystemFatalError(string errMsg)
        {
            ShowError(errMsg, CAPTION_FATAL_SYS_ERR);
            Environment.Exit(1);
        }

        private static void ShowConfigError(string keyword)
        {
            ShowError("Config file has invalid property for '" + keyword + "'", CAPTION_CONFIG_ERR);
            Environment.Exit(1);
        }

        private static string LocateExecutable(String filename)
        {
            RegistryKey localMachine = Registry.LocalMachine;
            RegistryKey fileKey = localMachine.OpenSubKey(string.Format(@"{0}\{1}", keyBase, filename));
            object result = null;
            if (fileKey != null)
            {
                result = fileKey.GetValue(string.Empty);
                fileKey.Close();
            }

            return (string)result;
        }

        //Execute shell command and get std-output.
        private static string ShellExec(string cmdArgs, string shell = "cmd.exe")
        {
            Process process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = shell;
            startInfo.Arguments = "/c " + cmdArgs;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}
