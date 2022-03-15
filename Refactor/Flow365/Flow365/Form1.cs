using Flow365.Classes;


namespace Flow365
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void floorsCount_ValueChanged(object sender, EventArgs e)
        {
            if (floorsCount.Value != 0)
            {
                createPatternButton.Enabled = true;
            }
            else
            {
                createPatternButton.Enabled = false;
            }
        }

        private void createPatternButton_Click(object sender, EventArgs e)
        {
            // Set important fields
            DBProcessor.startOfWorkDate = startOfWorkDate.Value;
            DBProcessor.endOfWorkDate = endOfWorkDate.Value;
            DBProcessor.floorsCount = Convert.ToInt32(floorsCount.Value);
            DBProcessor.folderPath = Selectfolder();

            DBProcessor.GenerateDB();  // Generate all needed DBs
        }

        private string Selectfolder()
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                return folderBrowserDialog.SelectedPath;
            }
            return "-1";
        }
    }
}