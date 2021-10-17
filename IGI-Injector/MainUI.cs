using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IGI_Injector
{
    public partial class MainUI : Form
    {
        internal static MainUI mainRef;

        public MainUI()
        {
            InitializeComponent();
            if (!File.Exists(Utils.injectorFile))
                Utils.ShowSystemFatalError("Injector tool '" + Utils.injectorFile + "' not found.\nError (0x00000002) ERROR_FILE_NOT_FOUND");

            this.MinimizeBox = this.MaximizeBox = false;
            mainRef = this;
            Utils.ParseConfig();
            Utils.CreateGameShortcut();
            Utils.inputDllNames = new List<string>();
            levelStartTxt.Value = Utils.gameLevel;
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Dll files (*.dll)|*.dll|All files (*.*)|*.*";
            fileDlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            fileDlg.Title = "Select DLL";
            fileDlg.DefaultExt = ".dll";
            fileDlg.Multiselect = Utils.multiDll;
            fileDlg.CheckFileExists = fileDlg.RestoreDirectory = fileDlg.AddExtension = true;

            DialogResult resultDlg = fileDlg.ShowDialog();
            if (resultDlg == DialogResult.OK)
            {
                //string dllFile;
                Utils.inputDllNames.Clear();
                try
                {
                    foreach (var dllFile in fileDlg.FileNames)
                    {
                        Utils.inputDllNames.Add(dllFile);
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
                Utils.gameLevel = Convert.ToInt32(levelStartTxt.Text.ToString());
                if (Utils.IsGameRunning()) System.Threading.Thread.Sleep(3000);
                else
                {
                    Utils.GameRunner(windowCb.Checked, Utils.gameLevel);
                    System.Threading.Thread.Sleep(Utils.delayDll * 1000);
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
            Utils.gameLevel = Convert.ToInt32(levelStartTxt.Text.ToString());
            Utils.GameRunner(windowCb.Checked, Utils.gameLevel);
        }

        private void windowCb_CheckedChanged(object sender, EventArgs e)
        {
            if (windowCb.Checked) fullCb.Checked = false;
            else if (!windowCb.Checked && !fullCb.Checked) windowCb.Checked = true;
        }

        private void fullCb_CheckedChanged(object sender, EventArgs e)
        {
            if (fullCb.Checked) windowCb.Checked = false;
            else if (!fullCb.Checked && !windowCb.Checked) fullCb.Checked = true;
        }
    }
}
