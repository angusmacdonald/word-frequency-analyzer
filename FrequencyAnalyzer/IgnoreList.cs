using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FrequencyAnalyzer
{
    /// <summary>
    /// IgnoreList is used to find, load and save the ignore list. It also contains a default ignore list.
    /// </summary>
    class IgnoreList
    {

        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Properties.Settings.Default.ignoreListLocation;
        private static bool ignoreNumbers = false;


        /// <summary>
        /// Look for a word / character ignore list on disk at a specified location. If it is found, load it into memory and ignore all words / characters
        /// in the file. If it is not found a new ignore list will be created with a standard set of ignored characters.
        /// </summary>
        /// <returns>Words and characters to be ignored.</returns>
        public static HashSet<String> getIgnoreList()
        {

            try
            {

                // Create a new ignore file based on a preconfigured set of characters.
                createIgnoreListFileIfNotExists();
                

                // Read ignored words and characters from an existing ignore file.
                return readIgnoreList();

            }
            catch (Exception)
            {
                //If there are any exceptions as a result of the file handling, just return the standard ignore list rather than show the error.
                return createInitialIgnoreList();
            }

        }

        private static HashSet<String> readIgnoreList()
        {
            HashSet<String> ignoredWords = createInitialIgnoreList();

            foreach (string line in File.ReadAllLines(path))
            {
                if (!string.IsNullOrEmpty(line) && (!line.StartsWith("#")))
                {
                    ignoredWords.Add(line);
           
                }
            }

            return ignoredWords;
        }

        public static void createIgnoreListFileIfNotExists()
        {

            if (!File.Exists(path))
            {

                HashSet<String> standardIgnoredCharacters = createInitialIgnoreList();

                File.WriteAllText(path, "", Encoding.ASCII);

            }
        }

        /// <summary>
        /// These are the default characters that are always escaped. Users can specify others in the ignore list.
        /// </summary>
        /// <returns></returns>
        private static HashSet<String> createInitialIgnoreList()
        {
            HashSet<String> standardIgnoredCharacters = new HashSet<String>();
            standardIgnoredCharacters.Add("");
            standardIgnoredCharacters.Add(" ");
            standardIgnoredCharacters.Add(".");
            standardIgnoredCharacters.Add(",");
            standardIgnoredCharacters.Add(";");
            standardIgnoredCharacters.Add(":");
            standardIgnoredCharacters.Add("?");
            standardIgnoredCharacters.Add("-");
            standardIgnoredCharacters.Add(").");
            standardIgnoredCharacters.Add("`");
            standardIgnoredCharacters.Add("\"");
            standardIgnoredCharacters.Add("'");
            standardIgnoredCharacters.Add("/");
            standardIgnoredCharacters.Add("\\");
            standardIgnoredCharacters.Add("<");
            standardIgnoredCharacters.Add(">");
            standardIgnoredCharacters.Add(" ");
            standardIgnoredCharacters.Add("(");
            standardIgnoredCharacters.Add(")");
            standardIgnoredCharacters.Add("[");
            standardIgnoredCharacters.Add("]");
            standardIgnoredCharacters.Add("{");
            standardIgnoredCharacters.Add("}");
            standardIgnoredCharacters.Add("'");
            standardIgnoredCharacters.Add("?)");
            standardIgnoredCharacters.Add("!)");
            standardIgnoredCharacters.Add(".)");
            standardIgnoredCharacters.Add("“");
            standardIgnoredCharacters.Add("”");

            standardIgnoredCharacters.Add(".”");
            standardIgnoredCharacters.Add("?”");
            standardIgnoredCharacters.Add(".“");
            standardIgnoredCharacters.Add("?“");
            standardIgnoredCharacters.Add(".");
            standardIgnoredCharacters.Add("?\"");
            standardIgnoredCharacters.Add(".\"");
            standardIgnoredCharacters.Add("!\"");
            standardIgnoredCharacters.Add("?!");
            
            standardIgnoredCharacters.Add("!!");
            standardIgnoredCharacters.Add("].");
            standardIgnoredCharacters.Add("+!!");
            standardIgnoredCharacters.Add("+\"");
            standardIgnoredCharacters.Add("&");
            standardIgnoredCharacters.Add("...");
            standardIgnoredCharacters.Add("+");
            standardIgnoredCharacters.Add("-");
            standardIgnoredCharacters.Add("–");
            standardIgnoredCharacters.Add("â€");
            standardIgnoredCharacters.Add("â€œ");
            standardIgnoredCharacters.Add("â€¦)");
            standardIgnoredCharacters.Add("â€˜˜");
            standardIgnoredCharacters.Add("\a");
            return standardIgnoredCharacters;
        }

        internal static string getIgnoreListFilePath()
        {
            return path;
        }

        /// <summary>
        /// Whether we are to ignore numbers in the frequency counting.
        /// </summary>
        /// <returns></returns>
        internal static bool ignoringNumbers()
        {
          
            foreach (string line in File.ReadAllLines(path))
            {
                if (!string.IsNullOrEmpty(line) && (line.StartsWith("<numbers>")))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
