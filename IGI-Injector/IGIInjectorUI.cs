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
            InitializeComponent();
            if (!File.Exists(Utils.injectorFile))
                Utils.ShowSystemFatalError("Injector tool '" + Utils.injectorFile + "' not found.\nError (0x00000002) ERROR_FILE_NOT_FOUND");

            this.MinimizeBox = this.MaximizeBox = false;
            mainRef = this;
            Utils.inputDllPaths = new List<string>();
            Utils.ParseConfig();
            Utils.CreateGameShortcut();

            //Set app properties from Config file
            levelStartTxt.Value = Utils.cfgGameLevel;
            if (Utils.cfgGameMode == "windowed") windowCb.Checked = true;
            else if (Utils.cfgGameMode == "full") fullCb.Checked = true;
            autoInjectCb.Checked = (Utils.cfgAutoInject);
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

        private void injectBtn_Click(object sender, EventArgs e)
        {
            if (autoInjectCb.Checked)
            {
                Utils.cfgGameLevel = Int32.Parse(levelStartTxt.Text.ToString());
                if (Utils.IsGameRunning()) System.Threading.Thread.Sleep(3000);
                else
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
            if (fullCb.Checked){ windowCb.Checked = false; Utils.cfgGameMode = "full";}
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
    }
}
