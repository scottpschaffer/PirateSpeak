using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateSpeak
{

    public class Solution
    {
        public string[] GetPossibleWords(string pWord, string[] meanings)
        {
            // initial way to hold correct words
            List<string> correctWords = new List<string>();
            for (var a = 0; a < meanings.Length; a++)
            {
                // if the length of the words don't match, then skip
                if (pWord.Length == meanings[a].Length)
                {
                    // split up the original word into char array to parse
                    char[] pWordArray = pWord.ToCharArray();
                    // word to compare assigned to tempWord for operating on
                    string tempWord = meanings[a];
                    for (var b = 0; b < pWordArray.Length; b++)
                    {
                        // see if letter is in tempWord and return its location
                        int letterIndex = tempWord.IndexOf(pWordArray[b]);
                        // -1 if letter not in tempWord
                        if (letterIndex >= 0)
                        {
                            // if letter is there, then remove it from tempWord
                            tempWord = tempWord.Remove(letterIndex, 1);
                        }
                    }

                    // if there are letters left, then they don't match
                    if (tempWord.Length == 0)
                    {
                        correctWords.Add(meanings[a]);
                    }
                }
            }

            // create array to contain correct words, based on size of correctWords
            string[] correctArray = new string[correctWords.Count];
            for (var c = 0; c < correctWords.Count; c++)
            {
                correctArray[c] = correctWords[c];
            }

            return correctArray;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string[] s = sol.GetPossibleWords("trisf", new[] { "qwert", "first" });
            for (var z = 0; z < s.Length; z++)
            {
                Console.WriteLine(s[z]);
            }
        }
    }
}
