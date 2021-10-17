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
        private static string gameName = "IGI", projAppName, cfgFile, gameAbsPath, cfgGamePath, keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        internal static List<string> inputDllNames;
        internal const string CAPTION_CONFIG_ERR = "Config - Error", CAPTION_FATAL_SYS_ERR = "Fatal sytem - Error", CAPTION_APP_ERR = "Application - Error", CAPTION_COMPILER_ERR = "Compiler - Error", GAME_PATH = "GAME_PATH", GAME_VARS = "GAME_VARS";
        internal static bool multiDll = false;
        internal static int delayDll = 10, gameLevel = 1;
        internal static string injectorFile = @"bin\igi-injector-cmd.exe";
        private static IniFile configIni;

        internal static void ShowStatusInfo(string text)
        {
            MainUI.mainRef.statusLbl.ForeColor = System.Drawing.Color.ForestGreen;
            MainUI.mainRef.statusLbl.Text = "INFO: " + text; ;
        }

        internal static void ShowStatusError(string text)
        {
            MainUI.mainRef.statusLbl.ForeColor = System.Drawing.Color.Tomato;
            MainUI.mainRef.statusLbl.Text = "ERROR: " + text;
        }

        internal static bool IsGameRunning()
        {
            bool isRunning = false;
            Process[] pname = Process.GetProcessesByName(gameName);
            isRunning = (pname.Length > 0);
            return isRunning;
        }

        internal static bool DllRunner(bool dllInject)
        {
            bool status = false;
            if (inputDllNames.Count > 0)
            {
                bool gameRunning = IsGameRunning();
                if (gameRunning)
                {
                    string inputDllName = "";

                    foreach (var dllName in inputDllNames)
                        inputDllName += dllName + " ";

                    string injectCmd = injectorFile + ((dllInject) ? " -i " : " -e ") + inputDllName;
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

        //Execute shell command and get std-output.
        internal static string ShellExec(string cmdArgs, string shell = "cmd.exe")
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
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


        public static void ShowWarning(string warnMsg, string caption = "WARNING")
        {
            MessageBox.Show(warnMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string errMsg, string caption = "ERROR")
        {
            MessageBox.Show(errMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string infoMsg, string caption = "INFO")
        {
            MessageBox.Show(infoMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowConfigError(string keyword)
        {
            ShowError("Config file has invalid property for '" + keyword + "'", CAPTION_CONFIG_ERR);
            Environment.Exit(1);
        }

        public static void ShowSystemFatalError(string errMsg)
        {
            ShowError(errMsg, CAPTION_FATAL_SYS_ERR);
            Environment.Exit(1);
        }

        internal static string LocateExecutable(String filename)
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

        internal static void CreateConfig(string configFile)
        {
            cfgGamePath = LocateExecutable(gameName + ".exe");
            bool gameFound = true;

            if (String.IsNullOrEmpty(cfgGamePath))
            {
                ShowWarning("Game path could not be detected automatically! Please select game path in config file", CAPTION_CONFIG_ERR);
                gameFound = false;
            }
            else
            {
                cfgGamePath = cfgGamePath.Substring(0, cfgGamePath.LastIndexOf("\\"));

                if (!File.Exists(cfgGamePath + "\\" + gameName + ".exe"))
                {
                    ShowError("Invalid path selected! Game 'IGI' not found at path '" + cfgGamePath + "'", CAPTION_FATAL_SYS_ERR);
                    gameFound = false;
                }
            }

            configIni.Write("game_path", cfgGamePath is null ? " " : cfgGamePath, "GAME_PATH");
            configIni.Write("multi_dll", "false", "GAME_VARS");
            configIni.Write("delay_dll", "10", "GAME_VARS");
            configIni.Write("game_level", "1", "GAME_VARS");

            //File.WriteAllText(configFile, configData);

            if (!gameFound) Environment.Exit(1);
        }

        internal static void ParseConfig()
        {
            projAppName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", String.Empty);
            cfgFile = projAppName + ".ini";
            configIni = new IniFile(cfgFile);
            try
            {
                if (File.Exists(cfgFile))
                {
                    gameAbsPath = configIni.Read("game_path", GAME_PATH);
                    cfgGamePath = gameAbsPath.Trim() + gameName + ".exe";

                    multiDll = bool.Parse(configIni.Read("multi_dll", GAME_VARS));
                    delayDll = Int32.Parse(configIni.Read("delay_dll", GAME_VARS));
                    gameLevel = Int32.Parse(configIni.Read("game_level", GAME_VARS));
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
            var shell = new WshShell();
            string shortcutAddress = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + linkName + ".lnk";

            if (File.Exists(shortcutAddress))
                File.Delete(shortcutAddress);

            var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Shortcut for IGI";
            shortcut.Hotkey = "Ctrl+ALT+I";
            shortcut.Arguments = gameArgs;
            shortcut.WorkingDirectory = pathToApp;
            shortcut.TargetPath = pathToApp + Path.DirectorySeparatorChar + "igi.exe";
            shortcut.Save();
        }

        internal static void CreateGameShortcut()
        {
            if (!File.Exists(gameName + "_full.lnk") || !File.Exists(gameName + "_full.lnk"))
            {
                if (gameAbsPath.Contains("\""))
                    gameAbsPath = gameAbsPath.Replace("\"", String.Empty);
                CreateGameShortcut(gameName + "_full", gameAbsPath);
                CreateGameShortcut(gameName + "_window", gameAbsPath, "window");
            }
        }

        internal static void GameRunner(bool windowed = true, int gameLevel = 1)
        {
            string gameRunCmd;
            bool gameRunning = IsGameRunning();
            if (windowed) gameRunCmd = "start " + gameName + "_window.lnk" + " level" + gameLevel;
            else gameRunCmd = "start " + gameName + "_full.lnk" + " level" + gameLevel;

            if (!gameRunning)
                ShellExec(gameRunCmd);
        }

    }
}
