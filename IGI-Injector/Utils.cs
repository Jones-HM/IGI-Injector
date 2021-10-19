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
        private static string projAppName, cfgDllPath, keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        internal static List<string> inputDllPaths;
        internal const string CAPTION_CONFIG_ERR = "Config - Error", CAPTION_FATAL_SYS_ERR = "Fatal sytem - Error", CAPTION_APP_ERR = "Application - Error", CAPTION_COMPILER_ERR = "Compiler - Error", PATH_SEC = "PATH", GAME_SEC = "GAME", DLL_SEC = "DLL";
        internal static bool isGamePathSet = false, cfgMultiDll = false, cfgAutoInject = false;
        internal static int cfgDelayDll = 10, cfgGameLevel = 1, IGI1_MAX_LEVEL = 14, IGI2_MAX_LEVEL = 19;
        internal static string gameAbsPath, cfgGamePath, cfgGameName = "igi", cfgFile, cfgGameMode = "windowed", injectorFile = @"bin\igi-injector-cmd.exe";
        private static IniParser iniParser;
        private static int[] missionListItems = { 0, 11, 12, 13, 14, 15, 16, 17, 21, 22, 23, 24, 25, 26, 31, 32, 33, 34, 35, 36 };

        internal static bool DllRunner(bool dllInject)
        {
            bool status;
            if (inputDllPaths.Count > 0 && inputDllPaths[0].Length > 3)
            {
                bool gameRunning = IsGameRunning();
                if (gameRunning)
                {
                    string inputDllPath = "";

                    foreach (var dllName in inputDllPaths)
                        inputDllPath += dllName + " ";

                    string injectCmd = injectorFile + " -n " + cfgGameName + ".exe" + ((dllInject) ? " -i " : " -e ") + inputDllPath;

                    string shellOut = ShellExec(injectCmd);
                    if (shellOut.Contains("Could not find module") || shellOut.Contains("Error"))
                    {
                        ShowStatusError("DLL " + ((dllInject) ? "injection" : "ejection") + " was unsuccessful");
                        status = false;
                    }
                    else status = true;
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
            cfgGamePath = (cfgGamePath is null) ? LocateExecutable(cfgGameName + ".exe") : cfgGamePath;

            if (String.IsNullOrEmpty(cfgGamePath))
            {
                ShowWarning("Game path could not be detected automatically! Please select game path", CAPTION_CONFIG_ERR);
            }
            else
            {
                cfgGamePath = cfgGamePath.Substring(0, cfgGamePath.LastIndexOf("\\"));

                if (!File.Exists(cfgGamePath + "\\" + cfgGameName + ".exe"))
                    ShowError("Invalid game path selected.\nGame '" + cfgGameName.ToUpper() + "' not found at path '" + cfgGamePath + "'", CAPTION_FATAL_SYS_ERR);
            }

            //Write Path to config.
            iniParser.Write("game_path", cfgGamePath is null ? " " : cfgGamePath + "\\", PATH_SEC);

            string inputDllPath = "";
            if (inputDllPaths.Count == 1) inputDllPath = inputDllPaths[0];
            else
            {
                foreach (var dllName in inputDllPaths)
                    inputDllPath += dllName + ",";
                inputDllPath = inputDllPath.TrimEnd(',');
            }

            iniParser.Write("dll_path", inputDllPath is null ? "\n" : inputDllPath, PATH_SEC);

            //Write Game/App properties to config.
            iniParser.Write("multi_dll", cfgMultiDll.ToString(), DLL_SEC);
            iniParser.Write("delay", cfgDelayDll.ToString(), DLL_SEC);
            iniParser.Write("auto_inject", cfgAutoInject.ToString(), DLL_SEC);
            iniParser.Write("game", cfgGameName, GAME_SEC);
            iniParser.Write("level", cfgGameLevel.ToString(), GAME_SEC);
            iniParser.Write("mode", cfgGameMode, GAME_SEC);
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
                    //Read properties from PATH section.
                    gameAbsPath = iniParser.Read("game_path", PATH_SEC);
                    cfgDllPath = iniParser.Read("dll_path", PATH_SEC);

                    if (!cfgDllPath.Contains(".dll") && cfgDllPath.Length > 3) ShowSystemFatalError("Dll path is invalid directory or file,\nError (0x0000000F) ERROR_INVALID_DRIVE");

                    if (cfgDllPath.Contains(","))
                    {
                        var dllPathSplit = cfgDllPath.Split(',');
                        foreach (var dllPath in dllPathSplit)
                            if (dllPath.Contains(".dll"))
                                inputDllPaths.Add(dllPath.Trim());
                    }
                    else inputDllPaths.Add(cfgDllPath);

                    //foreach (var dllPath in inputDllPaths) ShowInfo("dllPath: " + dllPath);
                    if (!String.IsNullOrEmpty(inputDllPaths[0]))
                        IGIInjectorUI.mainRef.browseFile.Text = Path.GetFileName(inputDllPaths[0]);

                    //Read properties from DLL section.
                    cfgMultiDll = bool.Parse(iniParser.Read("multi_dll", DLL_SEC));
                    cfgAutoInject = bool.Parse(iniParser.Read("auto_inject", DLL_SEC));
                    cfgDelayDll = Int32.Parse(iniParser.Read("delay", DLL_SEC));

                    //Read properties from Game section.
                    cfgGameName = iniParser.Read("game", GAME_SEC);
                    cfgGameLevel = Int32.Parse(iniParser.Read("level", GAME_SEC));
                    cfgGameMode = iniParser.Read("mode", GAME_SEC);

                    //Handle invalid data.
                    if (!cfgGameMode.Contains("windowed") && !cfgGameMode.Contains("full")) throw new Exception("Game mode is invalid");
                    if (!cfgGameName.Contains("igi") && !cfgGameName.Contains("igi2")) throw new Exception("Game selected is not IGI game");

                    cfgGamePath = (!String.IsNullOrEmpty(gameAbsPath)) ? (gameAbsPath.Trim() + cfgGameName + ".exe") : null;
                }
                else
                {
                    CreateConfig(cfgFile);
                }
            }
            catch (FormatException ex)
            {
                if (ex.StackTrace.Contains("Boolean"))
                    ShowConfigError("multi_dll or auto_inject");
                else if (ex.StackTrace.Contains("Int32"))
                    ShowConfigError("delay_dll or game_level");
            }
            catch (Exception ex)
            {
                ShowSystemFatalError("Exception: " + ex.Message);
            }
        }


        private static bool CreateGameShortcut(string linkName, string pathToApp, string gameArgs = "")
        {
            if (!File.Exists(cfgGamePath))
            {
                ShowError("Invalid game path selected.\nGame '" + cfgGameName.ToUpper() + "' not found at path '" + cfgGamePath + "'", CAPTION_FATAL_SYS_ERR);
                return false;
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
            return true;
        }

        internal static bool CreateGameShortcut()
        {
            bool status = false;
            if (String.IsNullOrEmpty(gameAbsPath)) return false;

            if (!File.Exists(cfgGameName + "_full.lnk") || !File.Exists(cfgGameName + "_full.lnk"))
            {
                if (gameAbsPath.Contains("\""))
                    gameAbsPath = gameAbsPath.Replace("\"", String.Empty);
                status = CreateGameShortcut(cfgGameName + "_full", gameAbsPath);
                if (status) CreateGameShortcut(cfgGameName + "_window", gameAbsPath, "window");
            }
            return status;
        }

        internal static void GameRunner(bool windowed = true, int gameLevel = 1)
        {
            string gameRunCmd = "";

            if (cfgGameName == "igi2") gameLevel = missionListItems[gameLevel]; //Get levels from missions Area - IGI 2.

            if (windowed)
            {
                string shortcutLink = cfgGameName + "_window.lnk";
                if (!File.Exists(shortcutLink))
                    ShowStatusError("Game path not found for '" + cfgGameName.ToUpper() + "'");
                else
                {
                    gameRunCmd = "start " + shortcutLink + " level" + gameLevel;
                    GameProcessExit();
                    ShellExec(gameRunCmd);
                }
            }
            else
            {
                string shortcutLink = cfgGameName + "_full.lnk";
                if (!File.Exists(shortcutLink))
                    ShowStatusError("Game path was not found for '" + cfgGameName.ToUpper() + "'");
                else
                {
                    gameRunCmd = "start " + shortcutLink + " level" + gameLevel;
                    GameProcessExit();
                    ShellExec(gameRunCmd);
                }
            }
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
            Process[] pname = Process.GetProcessesByName(cfgGameName);
            bool isRunning = pname.Length > 0;
            return isRunning;
        }

        internal static void GameProcessExit()
        {
            bool gameRunning = IsGameRunning();
            if (gameRunning && !String.IsNullOrEmpty(cfgGameName))
            {
                var process = Process.GetProcessesByName(cfgGameName);
                if (process.Length > 0)
                    process[0].Kill();
            }
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
            var process = new Process();
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
            string output = process.StandardError.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}
