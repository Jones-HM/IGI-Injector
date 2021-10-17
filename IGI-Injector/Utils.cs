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
        private static string injectorName = "igi-injector-cmd", gameName = "IGI", projAppName, cfgFile, gameAbsPath, cfgGamePath;
        internal static string inputDllName = "";
        internal const string CAPTION_CONFIG_ERR = "Config - Error", CAPTION_FATAL_SYS_ERR = "Fatal sytem - Error", CAPTION_APP_ERR = "Application - Error", CAPTION_COMPILER_ERR = "Compiler - Error";
        internal static bool appLogs = false;
        internal static string keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";

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

        internal static bool GameRunning()
        {
            bool isRunning = false;
            Process[] pname = Process.GetProcessesByName(gameName);
            isRunning = (pname.Length > 0);
            return isRunning;
        }

        internal static bool DllRunner(bool dllInject)
        {
            bool status = false;
            if (!String.IsNullOrEmpty(inputDllName))
            {
                bool gameRunning = GameRunning();
                if (gameRunning)
                {
                    string injectCmd = injectorName + ((dllInject) ? " -i " : " -e ") + inputDllName;
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

        private static void ParseConfigProperty(string configPath, ref bool propertyName, string keyword)
        {
            if (configPath.Trim().Contains("true")) propertyName = true;
            else if (configPath.Trim().Contains("false")) propertyName = false;
            else ShowConfigError(keyword);
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

                if (!File.Exists(cfgGamePath + Path.DirectorySeparatorChar + gameName + ".exe"))
                {
                    ShowError("Invalid path selected! Game 'IGI' not found at path '" + cfgGamePath + "'", CAPTION_FATAL_SYS_ERR);
                    gameFound = false;
                }
            }

            string configData = "[GAME_PATH]\n" +
                "game_path = " + cfgGamePath + "\n\n" +
                "[GAME_VARS]\n" +
                "app_logs = false\n";

            File.WriteAllText(configFile, configData);
            if (!gameFound)
                Environment.Exit(1);
        }

        internal static void ParseConfig()
        {
            projAppName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", String.Empty);
            cfgFile = projAppName + ".ini";

            var keywords = new List<string>() { "game_path", "app_logs" };
            if (File.Exists(cfgFile))
            {
                var cfgData = File.ReadAllText(cfgFile);
                var split_data = cfgData.Split('\n');

                if (!keywords.All(o => cfgData.Contains(o)))
                {
                    ShowError("Config file '" + cfgFile + "' doesn't contain proper keywords", CAPTION_CONFIG_ERR);
                    Environment.Exit(1);
                }

                foreach (var data in split_data)
                {
                    if (keywords.Any(o => data.Contains(o)))
                    {
                        for (int i = 0; i < keywords.Count; i++)
                        {
                            if (data.Contains(keywords[i]))
                            {
                                var configPath = data.Substring(keywords[i].Length + 0x3);

                                if (i == 0)
                                {
                                    if (String.IsNullOrEmpty(configPath) || String.IsNullOrWhiteSpace(configPath))
                                        ShowConfigError(keywords[i]);
                                    else
                                    {
                                        string gPath = configPath.Trim();
                                        if (gPath.Contains("\""))
                                            gPath = configPath = gPath.Replace("\"", String.Empty);
                                        if (!File.Exists(gPath + Path.DirectorySeparatorChar + gameName + ".exe"))
                                        {
                                            ShowError("Invalid path selected! Game 'IGI' not found at path '" + gPath + "'", CAPTION_FATAL_SYS_ERR);
                                            Environment.Exit(1);
                                        }
                                        gameAbsPath = configPath.Trim();
                                        cfgGamePath = configPath.Trim() + gameName + ".exe";
                                    }
                                }
                                else if (i == 1)
                                    ParseConfigProperty(configPath, ref appLogs, keywords[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                ShowWarning("Config file not found in current directory", CAPTION_CONFIG_ERR);
                CreateConfig(cfgFile);
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

        internal static void GameRunner(bool windowed = true)
        {
            string gameRunCmd;
            if (windowed) gameRunCmd = "start " + gameName + "_window.lnk";
            else gameRunCmd = "start " + gameName + "_full.lnk";
            ShellExec(gameRunCmd);
        }

    }
}
