using System.ComponentModel;
using Microsoft.Office.Interop.Word;

namespace FrequencyAnalyzer
{
    /// <summary>
    /// Responsible for running the BackgroundWorker responsible for calculating word frequencies, and for creating the taskpane which is to display
    /// results to the user.
    /// </summary>
    public class WorkerManager
    {
        
        
        private static Microsoft.Office.Tools.CustomTaskPane taskpane = null;
        private ResultsTaskPane resultpane;
        
        int wordcount;
        
        private BackgroundWorker bgWorker = new BackgroundWorker();

        /// <summary>
        /// Sets up hooks for background worker.
        /// </summary>
        public WorkerManager()
        {
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        }

        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultpane.updateProgress(e.ProgressPercentage);
        }

        /// <summary>
        /// Called once the frequencies have been calculated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            resultpane.isCalculating(false);
            ResultContainer myResult = (ResultContainer)e.Result;


            if (myResult != null)
            { 
                
                if (myResult.ForSave)
                {
                    //Save to CSV
                    resultpane.saveToFile(myResult);
                    taskpane.Visible = false;
                }
                else
                {
                    //Populate the task pane.
                    resultpane.populateTable(myResult);
                }
            }

        }

        /// <summary>
        /// Starts the calculation of word frequencies by getting an array of all words in the current document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = Globals.ThisAddIn.Application;

            //Select the range as the entire document.
            object start = 0;
            object end = app.ActiveDocument.Characters.Count;
            Microsoft.Office.Interop.Word.Range rng = app.ActiveDocument.Range(ref start, ref end);

            Words words = app.ActiveDocument.Words;
            this.wordcount = app.ActiveDocument.Words.Count;

            //TODO - parellilize this with multiple background workers. here or in the ribbon class?
            FrequencyCalculation m = new FrequencyCalculation(bgWorker, words, 1, wordcount, (bool)e.Argument);
            e.Result = m.getResult();
        }

        /// <summary>
        /// Runs the worker if no other worker instance is already running.
        /// </summary>
        /// <param name="saveresult"></param>
        public void runBackgroundWorker(bool saveresult)
        {
            resultpane.isCalculating(true);

            if (!bgWorker.IsBusy){
                bgWorker.RunWorkerAsync(saveresult);
            }
        }


        public void createTaskPane()
        {
            resultpane = new ResultsTaskPane(this);

            //If a taskpane is already being displayed, remove it.
            if ((Globals.ThisAddIn.CustomTaskPanes.Count > 0))
            {
                Globals.ThisAddIn.CustomTaskPanes.Remove(taskpane);
            }

            taskpane = Globals.ThisAddIn.CustomTaskPanes.Add(resultpane, "Frequency Analyzer Results");
            taskpane.Visible = true;
        }

        /// <summary>
        /// Cancel the background worker.
        /// </summary>
        public void stopComputation()
        {
            bgWorker.CancelAsync();
            
            resultpane.isCalculating(false);
        }
    }
}
