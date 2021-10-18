using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IGI_Injector
{
    public partial class IGIInjectorUI : Form
    {
        internal static IGIInjectorUI mainRef;

        public IGIInjectorUI()
        {
            try
            {
                InitializeComponent();
                var uxLib = new UXLib();
                uxLib.CustomFormMover(formMoverPanel, this);

                if (!File.Exists(Utils.injectorFile))
                    Utils.ShowSystemFatalError("Injector tool '" + Utils.injectorFile + "' not found.\nError (0x00000002) ERROR_FILE_NOT_FOUND");

                this.MinimizeBox = this.MaximizeBox = false;
                mainRef = this;

                Utils.inputDllPaths = new List<string>();

                //Parse config on AppStart.
                Utils.ParseConfig();

                //Set app properties from Config file.
                if (File.Exists(Utils.gameAbsPath + "\\" + Utils.cfgGameName + ".exe"))
                {
                    setGamePathBtn.Enabled = false;
                    setGamePathBtn.Text = "Game Path: " + Utils.gameAbsPath;
                }

                if (Utils.cfgGameMode == "windowed") windowCb.Checked = true;
                else if (Utils.cfgGameMode == "full") fullCb.Checked = true;

                levelStartTxt.Value = Utils.cfgGameLevel;
                autoInjectCb.Checked = Utils.cfgAutoInject;
                multiDLLCb.Checked = Utils.cfgMultiDll;
                delayTxt.Value = Utils.cfgDelayDll;
                gameTypeDD.SelectedIndex = (Utils.cfgGameName.Contains("igi2") ? 1 : 0);
            }
            catch (ArgumentOutOfRangeException)
            {
                Utils.ShowWarning("Game Level should be between [" + levelStartTxt.Minimum + "-" + levelStartTxt.Maximum + "]");
                levelStartTxt.Value = 1;
            }

            catch (Exception ex)
            {
                Utils.ShowSystemFatalError("Exception: " + ex.Message);
            }
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Dll files (*.dll)|*.dll|All files (*.*)|*.*";
            fileDlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            fileDlg.Title = "Select DLL";
            fileDlg.DefaultExt = ".dll";
            fileDlg.Multiselect = Utils.cfgMultiDll;
            fileDlg.CheckFileExists = fileDlg.RestoreDirectory = fileDlg.AddExtension = true;

            DialogResult resultDlg = fileDlg.ShowDialog();
            if (resultDlg == DialogResult.OK)
            {
                Utils.inputDllPaths.Clear();
                try
                {
                    foreach (var dllFile in fileDlg.FileNames)
                    {
                        Utils.inputDllPaths.Add(dllFile);
                        browseFile.Text = Path.GetFileName(dllFile);
                    }
                    statusLbl.Text = "";
                }
                catch (IOException ex)
                {
                    Utils.ShowStatusError(ex.Message);
                }
            }
        }

        private void setGamePathBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                Utils.gameAbsPath = Path.GetDirectoryName(folderBrowser.FileName) + Path.DirectorySeparatorChar;
                Utils.cfgGamePath = (!String.IsNullOrEmpty(Utils.gameAbsPath)) ? (Utils.gameAbsPath.Trim() + Utils.cfgGameName + ".exe") : null;
                Utils.CreateGameShortcut();
                Utils.ShowStatusInfo("Game path set success");
                setGamePathBtn.Enabled = false;
                setGamePathBtn.Text = "Game Path: " + Utils.gameAbsPath;
            }
            else Utils.ShowStatusError("Game path set error");
        }

        private void injectBtn_Click(object sender, EventArgs e)
        {
            if (autoInjectCb.Checked)
            {
                Utils.cfgGameLevel = Int32.Parse(levelStartTxt.Text.ToString());
                if (!Utils.IsGameRunning())
                {
                    Utils.GameRunner(windowCb.Checked, Utils.cfgGameLevel);
                    System.Threading.Thread.Sleep(Utils.cfgDelayDll * 1000);
                }
            }

            bool status = Utils.DllRunner(true);
            if (status) Utils.ShowStatusInfo("DLL was injected successfully");
        }


        private void ejectBtn_Click(object sender, EventArgs e)
        {
            bool status = Utils.DllRunner(false);
            if (status) Utils.ShowStatusInfo("DLL was ejected successfully");
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            string infoMsg = "IGI-Injector is tool to inject DLL into Project I.G.I Game\n" +
                "Developed by: Haseeb Mir\n" +
                "Tools/Language: C# (.NET 5.0)/GUI.\n";
            MessageBox.Show(infoMsg, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void startGameBtn_Click(object sender, EventArgs e)
        {
            Utils.cfgGameLevel = Convert.ToInt32(levelStartTxt.Text.ToString());
            Utils.GameRunner(windowCb.Checked, Utils.cfgGameLevel);
        }

        private void windowCb_CheckedChanged(object sender, EventArgs e)
        {
            if (windowCb.Checked) { fullCb.Checked = false; Utils.cfgGameMode = "windowed"; }
            else if (!windowCb.Checked && !fullCb.Checked) windowCb.Checked = true;
        }

        private void fullCb_CheckedChanged(object sender, EventArgs e)
        {
            if (fullCb.Checked) { windowCb.Checked = false; Utils.cfgGameMode = "full"; }
            else if (!fullCb.Checked && !windowCb.Checked) fullCb.Checked = true;
        }

        private void levelStartTxt_ValueChanged(object sender, EventArgs e)
        {
            Utils.cfgGameLevel = Int32.Parse(((NumericUpDown)(sender)).Value.ToString());
        }

        private void autoInjectCb_CheckedChanged(object sender, EventArgs e)
        {
            Utils.cfgAutoInject = (autoInjectCb.Checked);
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void gameTypeDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gameName = ((ComboBox)sender).Text;
            var gameIndex = ((ComboBox)sender).SelectedIndex;
            if (!String.IsNullOrEmpty(gameName))
            {
                Utils.cfgGameName = gameName.Replace("Project ", String.Empty).Replace(" ", String.Empty).ToLower();
                if (Utils.cfgGameName.Contains("igi1")) Utils.cfgGameName = Utils.cfgGameName.Replace("igi1", "igi");
            }

            if (gameIndex == 0)
            {
                levelStartTxt.Minimum = 1;
                levelStartTxt.Maximum = Utils.IGI1_MAX_LEVEL;
            }

            else if (gameIndex == 1)
            {
                levelStartTxt.Minimum = 1;
                levelStartTxt.Maximum = Utils.IGI2_MAX_LEVEL;
            }
        }

        private void delayTxt_ValueChanged(object sender, EventArgs e)
        {
            Utils.cfgDelayDll = Int32.Parse(((NumericUpDown)(sender)).Value.ToString());
        }

        private void multiDLLCb_CheckedChanged(object sender, EventArgs e)
        {
            Utils.cfgMultiDll = (multiDLLCb.Checked);
        }

        private void gameTypeDD_MouseClick(object sender, MouseEventArgs e)
        {
            setGamePathBtn.Enabled = true;
        }
    }
}
