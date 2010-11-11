using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace FrequencyAnalyzer
{
    public partial class ResultsTaskPane : UserControl 
    {
        
        delegate void ProgressBarCallback(int value);
        delegate void ResultsCallback(ResultContainer results);
        
        
        bool calculating = false;
        WorkerManager manager;

        public ResultsTaskPane(WorkerManager manager)
        {
            InitializeComponent();

            this.manager = manager;
        }

        public void ResultsDisplay(ResultContainer results)
        {

            resultsbox.Items.Clear();
            
            // It's on the same thread, no need for Invoke
            Dictionary<String, int> frequencies = results.Frequencies;
            int wordcount = results.Wordcount;
            //Related information
            totalwords.Text = "Total Word Count: " + wordcount;
            uniquewords.Text = "Unique Word Count: " + frequencies.Count;


            var ordered_results = from k in frequencies.Keys orderby frequencies[k] descending select k;

            double previous_frequency = 0;

            foreach (string key in ordered_results)
            {
                double word_frequency = (frequencies[key] / (double)wordcount) * 100;

                if (word_frequency == previous_frequency)
                { //Don't display the same percentage over and over again. Just for the first time it appears.
                    resultsbox.Items.Add(key + "\t [" + frequencies[key] + "]");
                }
                else
                {
                    resultsbox.Items.Add(key + "\t [" + frequencies[key] + ", " + word_frequency.ToString("#0.00") + "%]");
                    previous_frequency = word_frequency;
                }
            }

            progressBar.Visible = false;
            progressBar.Value = 0;
            calcLabel.Visible = false;
            totalwords.Visible = true;
            uniquewords.Visible = true;
            resultsbox.Visible = true;
            recalculatebutton.Text = "Re-calculate";
            calculating = false;

        }
        public void populateTable(ResultContainer results){

            if (results != null)
            { //it will be null if the user cancelled the operation prematurely.

                if (this.totalwords.InvokeRequired)
                {
                    // It's on a different thread, so use Invoke.
                    ResultsCallback d = new ResultsCallback(ResultsDisplay);
                    this.Invoke(d, new object[] { results });
                }
                else
                {
                    // It's on the same thread, no need for Invoke
                    Dictionary<String, int> frequencies = results.Frequencies;
                    int wordcount = results.Wordcount;
                    //Related information
                    totalwords.Text = "Total Word Count: " + wordcount;
                    uniquewords.Text = "Unique Word Count: " + frequencies.Count;


                    var ordered_results = from k in frequencies.Keys orderby frequencies[k] descending select k;

                    double previous_frequency = 0;

                    foreach (string key in ordered_results)
                    {
                        double word_frequency = (frequencies[key] / (double)wordcount) * 100;

                        if (word_frequency == previous_frequency)
                        { //Don't display the same percentage over and over again. Just for the first time it appears.
                            resultsbox.Items.Add(key + "\t [" + frequencies[key] + "]");
                        }
                        else
                        {
                            resultsbox.Items.Add(key + "\t [" + frequencies[key] + ", " + word_frequency.ToString("#0.00") + "%]");
                            previous_frequency = word_frequency;
                        }
                    }

                    progressBar.Visible = false;
                    progressBar.Value = 0;
                    calcLabel.Visible = false;
                    totalwords.Visible = true;
                    uniquewords.Visible = true;
                    resultsbox.Visible = true;
                    recalculatebutton.Text = "Re-calculate";
                    calculating = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void ResultsTaskPane_Load(object sender, EventArgs e)
        {

        }

        private void recalculatebutton_Click(object sender, EventArgs e)
        {

            if (calculating)
            { //This means the button has been pressed to stop the computation.
                progressBar.Visible = false;
                progressBar.Value = 0;
                recalculatebutton.Text = "Calculate";
                calcLabel.Text = "Analysis terminated.";
                calculating = false;

                manager.stopComputation();
            }
            else
            { //This means the button has been pressed to re-calculate everything.
                calcLabel.Text = "Calculating results.";
                progressBar.Visible = true;
                calcLabel.Visible = true;
                totalwords.Visible = false;
                uniquewords.Visible = false;
                resultsbox.Visible = false;
                recalculatebutton.Text = "Terminate Calculation";
                manager.runBackgroundWorker(false);
            }
    
        }

        public void updateProgress(int progress)
        {
            // Check if this method is running on a different thread
            // than the thread that created the control.
            if (this.progressBar.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                ProgressBarCallback d = new ProgressBarCallback(ProgressBar);
                this.Invoke(d, new object[] { progress });
            }
            else
            {
                // It's on the same thread, no need for Invoke
                progressBar.Value = progress;
            }

        }

        public void saveToFile(ResultContainer results)
        {
            saveFileDialog1.Filter = "Comma Separated Value|*.csv";
            saveFileDialog1.Title = "Where to save the file?";
            saveFileDialog1.FileName = "Word Frequency";
            saveFileDialog1.ShowDialog();
            
            Dictionary<String, int> frequencies = results.Frequencies;
            int wordcount = results.Wordcount;
            double previous_frequency = 0;

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();

                var ordered_results = from k in frequencies.Keys orderby frequencies[k] descending select k;
                AddText(fs, "Word, Count, Frequency\n");
                foreach (string key in ordered_results)
                {
                    double word_frequency = (frequencies[key] / (double)wordcount) * 100;
                    AddText(fs, key + ", " + frequencies[key] + ", " + word_frequency.ToString("#0.00") + "%\n");
                    previous_frequency = word_frequency;
                }
                
                // close the stream
                fs.Close();

                progressBar.Visible = false;
                progressBar.Value = 0;
                calcLabel.Visible = false;
                totalwords.Visible = false;
                uniquewords.Visible = false;
                resultsbox.Visible = false;
                recalculatebutton.Text = "Re-calculate";
                calculating = false;
                // write a line of text to the file

                this.Visible = false;

            }

        }


        private static void AddText(System.IO.FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }


        private void ProgressBar(int value)
        {
            this.progressBar.Value = value;
        }

        public void isCalculating(bool calculating)
        {
            this.calculating = calculating;
        }
    }
}
