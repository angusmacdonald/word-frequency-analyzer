namespace FrequencyAnalyzer
{
    partial class RibbonEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = new Microsoft.Office.Tools.Ribbon.RibbonTab();
            this.group1 = new Microsoft.Office.Tools.Ribbon.RibbonGroup();
            this.freq_analyzer = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.savefrequencies = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.openIgnoreList = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabReviewWord";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabReviewWord";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.freq_analyzer);
            this.group1.Items.Add(this.savefrequencies);
            this.group1.Items.Add(this.openIgnoreList);
            this.group1.Label = "Word Frequency";
            this.group1.Name = "group1";
            // 
            // freq_analyzer
            // 
            this.freq_analyzer.Image = global::FrequencyAnalyzer.Properties.Resources.pie_chart_48;
            this.freq_analyzer.Label = "Display in Pane";
            this.freq_analyzer.Name = "freq_analyzer";
            this.freq_analyzer.ShowImage = true;
            this.freq_analyzer.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.freq_analyzer_Click);
            // 
            // savefrequencies
            // 
            this.savefrequencies.Image = global::FrequencyAnalyzer.Properties.Resources.save_32x32;
            this.savefrequencies.Label = "Save to CSV File";
            this.savefrequencies.Name = "savefrequencies";
            this.savefrequencies.ShowImage = true;
            this.savefrequencies.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.savefrequencies_Click);
            // 
            // openIgnoreList
            // 
            this.openIgnoreList.Image = global::FrequencyAnalyzer.Properties.Resources.fileopen_32;
            this.openIgnoreList.Label = "Open Ignore List";
            this.openIgnoreList.Name = "openIgnoreList";
            this.openIgnoreList.ShowImage = true;
            this.openIgnoreList.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.openIgnoreList_Click);
            // 
            // RibbonEntry
            // 
            this.Name = "RibbonEntry";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs>(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton freq_analyzer;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton savefrequencies;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openIgnoreList;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal RibbonEntry Ribbon1
        {
            get { return this.GetRibbon<RibbonEntry>(); }
        }
    }
}
