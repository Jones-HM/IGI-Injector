using System;
using System.IO;
using System.Windows.Forms;

namespace IGI_Injector
{
    public partial class MainUI : Form
    {
        internal static MainUI mainRef;
        public MainUI()
        {
            this.MinimizeBox = this.MaximizeBox = false;
            InitializeComponent();
            mainRef = this;
            Utils.ParseConfig();
            Utils.CreateGameShortcut();
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Dll files (*.dll)|*.dll|All files (*.*)|*.*";
            fileDlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            fileDlg.Title = "Select DLL";
            fileDlg.CheckFileExists = true;
            fileDlg.DefaultExt = ".dll";
            DialogResult resultDlg = fileDlg.ShowDialog(); 
            if (resultDlg == DialogResult.OK)
            {
                string dllFile = fileDlg.FileName;
                try
                {
                    Utils.inputDllName = dllFile;
                    injectBtn.Enabled = ejectBtn.Enabled = true;
                }
                catch (IOException ex)
                {
                    Utils.ShowStatusError(ex.Message);
                }
            }
        }

        private void injectBtn_Click(object sender, EventArgs e)
        {
            bool status = Utils.DllRunner(true);
            if(status) Utils.ShowStatusInfo("DLL was injected successfully");
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
            Utils.GameRunner(true);
        }
    }
}
