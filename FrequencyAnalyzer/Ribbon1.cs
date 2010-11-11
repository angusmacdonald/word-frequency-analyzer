using Microsoft.Office.Tools.Ribbon;

namespace FrequencyAnalyzer
{
    /// <summary>
    /// Displayed in the review tab of the ribbon.
    /// </summary>
    public partial class RibbonEntry : OfficeRibbon
    {

        private WorkerManager workermanager;

       
        public RibbonEntry()
        {
            InitializeComponent();
            workermanager = new WorkerManager();
        }


        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        /// <summary>
        /// Calculate the word frequencies and display them in the pane.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void freq_analyzer_Click(object sender, RibbonControlEventArgs e)
        {
            workermanager.createTaskPane();
            workermanager.runBackgroundWorker(false);
        }

        /// <summary>
        /// Calculate the word frequencies and save them to CSV file.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void savefrequencies_Click(object sender, RibbonControlEventArgs e)
        {
            workermanager.createTaskPane();
            workermanager.runBackgroundWorker(true);

        }

        /// <summary>
        /// Opens the text file containing ignored words and characters.
        /// 
        /// Icon for this from: http://www.iconspedia.com/icon/open-file-407-.html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openIgnoreList_Click(object sender, RibbonControlEventArgs e)
        {
            IgnoreList.createIgnoreListFileIfNotExists();

            System.Diagnostics.Process.Start(IgnoreList.getIgnoreListFilePath()); //open the ignore list in the default text editor file.
        }

    }
}
