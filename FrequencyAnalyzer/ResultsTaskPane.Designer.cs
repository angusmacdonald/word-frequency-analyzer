namespace FrequencyAnalyzer
{
    partial class ResultsTaskPane
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
            this.resultsbox = new System.Windows.Forms.ListBox();
            this.process1 = new System.Diagnostics.Process();
            this.recalculatebutton = new System.Windows.Forms.Button();
            this.totalwords = new System.Windows.Forms.Label();
            this.uniquewords = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.calcLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // resultsbox
            // 
            this.resultsbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsbox.FormattingEnabled = true;
            this.resultsbox.Location = new System.Drawing.Point(18, 101);
            this.resultsbox.Name = "resultsbox";
            this.resultsbox.Size = new System.Drawing.Size(152, 238);
            this.resultsbox.TabIndex = 0;
            this.resultsbox.Visible = false;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // recalculatebutton
            // 
            this.recalculatebutton.Location = new System.Drawing.Point(18, 18);
            this.recalculatebutton.Name = "recalculatebutton";
            this.recalculatebutton.Size = new System.Drawing.Size(152, 23);
            this.recalculatebutton.TabIndex = 1;
            this.recalculatebutton.Text = "Terminate Calculation";
            this.recalculatebutton.UseVisualStyleBackColor = true;
            this.recalculatebutton.Click += new System.EventHandler(this.recalculatebutton_Click);
            // 
            // totalwords
            // 
            this.totalwords.AutoSize = true;
            this.totalwords.Location = new System.Drawing.Point(18, 48);
            this.totalwords.Name = "totalwords";
            this.totalwords.Size = new System.Drawing.Size(138, 13);
            this.totalwords.TabIndex = 2;
            this.totalwords.Text = "Total Word Count: Loading.";
            this.totalwords.Visible = false;
            // 
            // uniquewords
            // 
            this.uniquewords.AutoSize = true;
            this.uniquewords.Location = new System.Drawing.Point(18, 72);
            this.uniquewords.Name = "uniquewords";
            this.uniquewords.Size = new System.Drawing.Size(145, 13);
            this.uniquewords.TabIndex = 3;
            this.uniquewords.Text = "Unique Word Count: Loading";
            this.uniquewords.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(18, 88);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(152, 23);
            this.progressBar.TabIndex = 4;
            // 
            // calcLabel
            // 
            this.calcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.calcLabel.AutoSize = true;
            this.calcLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcLabel.Location = new System.Drawing.Point(27, 55);
            this.calcLabel.Name = "calcLabel";
            this.calcLabel.Size = new System.Drawing.Size(136, 19);
            this.calcLabel.TabIndex = 5;
            this.calcLabel.Text = "Calculating results.";
            // 
            // ResultsTaskPane
            // 
            this.Controls.Add(this.calcLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.uniquewords);
            this.Controls.Add(this.totalwords);
            this.Controls.Add(this.recalculatebutton);
            this.Controls.Add(this.resultsbox);
            this.Name = "ResultsTaskPane";
            this.Size = new System.Drawing.Size(188, 353);
            this.Load += new System.EventHandler(this.ResultsTaskPane_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox resultsbox;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Button recalculatebutton;
        private System.Windows.Forms.Label totalwords;
        private System.Windows.Forms.Label uniquewords;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label calcLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;


    }
}
