using System;
using System.Collections.Generic;

namespace FrequencyAnalyzer
{
    /// <summary>
    /// Contains the result of the analysis (a Dictionary containing the word [key] and the number of occurences [value], the number
    /// of words in the document, and a boolean indicating whether the result is to be displayed in the taskpane or saved to CSV.
    /// </summary>
    public class ResultContainer
    {
        private Dictionary<String, int> frequencies;
        private int wordcount;

        /// <summary>
        /// Whether the result of this is to be returned to the task pane, or if it is for saving to file.
        /// </summary>
        private bool forsave;

        public ResultContainer(Dictionary<String, int> frequencies, int wordcount, bool forsave){
            this.frequencies = frequencies;
            this.wordcount = wordcount;
            this.forsave = forsave;
        }

        public int Wordcount
        {
            get { return wordcount; }
        }

        public Dictionary<String, int> Frequencies
        {
            get { return frequencies; }
        }

        public bool ForSave
        {
            get { return forsave; }
        }
    }
}
