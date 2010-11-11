using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Office.Interop.Word;

namespace FrequencyAnalyzer
{
    /// <summary>
    /// Contains the logic for calculating the frequency of each word in the document. This class should be run using a BackgroundWorker object,
    /// which is then passed in as a parameter in the constructor.
    /// </summary>
    class FrequencyCalculation
    {
        /// <summary>
        /// Contains all the punctuation marks that the add-in should ignore when calculating frequencies.
        /// </summary>
        private static HashSet<String> punctuation;
        
        BackgroundWorker bgWorker = null;
        Words words;
        int start_word;
        int end_word;

        /// <summary>
        /// Whether the result is going to be saved or printed out onscreen.
        /// </summary>
        private bool tosave;

        /// <summary>
        /// Set up the class with the BackgroundWorker class being used for this comptuation (to allow for callbacks), the words in the document, the total
        /// number of tokens, and an indication of whether the results will be displayed onscreen or saved to file.
        /// </summary>
        /// <param name="bw">the BackgroundWorker class being used for this comptuation (to allow for callbacks)</param>
        /// <param name="words">an array of the words in the document</param>
        /// <param name="start_word">the word on which this frequency calculator will start counting (including punctuation marks) from the words array.
        /// The lowest allowable value for this parameter is 1.</param>
        /// <param name="start_word">the word on which this frequency calculator will stop counting (including punctuation marks) from the words array</param>
        /// <param name="tosave">whether the result will be saved to CSV (true) or displayed in the taskpane (false).</param>
        public FrequencyCalculation(BackgroundWorker bw, Words words, int start_word, int end_word, bool tosave)
        {
            this.bgWorker = bw;
            this.words = words;
            this.start_word = start_word;
            this.end_word = end_word;
            this.tosave = tosave;

            punctuation = IgnoreList.getIgnoreList();

        }

        /// <summary>
        /// Calculate the number of occurences of each word contained in the 'words' field.
        /// </summary>
        /// <returns>An object containing the result of the analysis (a Dictionary containing the word [key] and the number of occurences [value], the number
        /// of words in the document, and a boolean indicating whether the result is to be displayed in the taskpane or saved to CSV.</returns>
        internal ResultContainer getResult()
        {
            
            try
            {
                Dictionary<String, int> frequencies = new Dictionary<String, int>();
                int trimmed_word_count = 0; //the word count not including punctuation.
                int previous_progress = 0;


                //Loop through all words.
                for (int i = start_word; i < end_word; i++)
                {
                    //Get the word, trim it of whitespace and make it lower case so they're all the same.
                    String word = words[i].Text.Trim();
                    word = word.ToLower();

                    //If the word is a punctuation mark, ignore it.
                    if (!punctuation.Contains(word))
                    {
                        if (frequencies.ContainsKey(word))
                        {
                            int count = frequencies[word];
                            frequencies.Remove(word);
                            frequencies.Add(word, ++count);
                            
                        }
                        else
                        {
                            frequencies.Add(word, 1);
                        }

                        trimmed_word_count++;
                    }

                    int progress = (int)((i / (double)end_word) * 100);

                    
                    if (previous_progress != progress)
                    { //If the progress has changed from the last iteration notify the interface so that the progress bar can be updated.
                        bgWorker.ReportProgress(progress);
                        previous_progress = progress;
                        if (bgWorker.CancellationPending)
                        { //If the computation has been cancelled by the user.
                            return null; //cancel the operation.
                        }
                    }
                    
                }

            return new ResultContainer(frequencies, trimmed_word_count, tosave);

            }
            catch (Exception)
            {
                //Do nothing.
                return null;
            }
        }
    }
}
