using System;

namespace TextMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            TextMatching TextMatching = new TextMatching();
            TextMatching.Calculations(args);
        }

        
    }

    public class TextMatching {

        /// <summary>
        /// searches for one match between subtext and text, from index fromIndex
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="text"></param>
        /// <param name="subtext"></param>
        /// <returns> index of the first found instance</returns>
        public int FindMatch(int fromIndex, string text, string subtext)
        {
            for (int i = fromIndex; i < text.Length; i++)
            {
                for (int j = 0; j < subtext.Length; j++)
                {
                    // if text and subtext don't match
                    if (text[i] != subtext[j])
                    {
                        //go to next text symbol
                        break;
                    }
                    // if they match
                    else
                    {
                        if (subtext.Length - 1 == j)
                        {
                            // if we found a match, return starting position of original text
                            
                            return i - (subtext.Length - 2);
                        }
                        // if it's currently matching, check next letter in both arrays
                        i++;

                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// Prints valid values from parameter arr
        /// </summary>
        /// <param name="arr">array of integers</param>
        public string PrintResults(int[] arr)
        {
            string result = null;
            if (arr[0] < 0)
            {
                //Console.WriteLine("There is no output");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i + 1 != arr.Length)
                    {
                        result += arr[i];

                        if (arr[i + 1] > 0)
                        {
                            result += ',';
                            // if there is more valid values in the array, print a comma
                        }
                        else
                        {  
                            //if there is no more valid values, finish up
                            break;
                        }
                       

                    }
                   

                }
            }
            return result;
        }

        public void Calculations(string[] args) {

            string text = null;
            string subtext = null;
            Console.Write("please write text element:");
            text = Console.ReadLine();
            Console.Write("please write subtext element:");
            subtext = Console.ReadLine();

            //text = args[0];
            //subtext = args[1];

            // array of indexes of matches; contains values from 1 to text.Length
            int[] answerArray;          

            answerArray = Calc(text, subtext);
            Console.WriteLine(PrintResults(answerArray));
        }

        public int[] Calc(string text, string subtext) 
        {
            // array of indexes of matches; contains values from 1 to text.Length
            int[] answerArray = new int[50];
            // cursor variable is for marking the spot where was the last match found; next search begins from there
            int cursor = 0;
            string loweredText = text.ToLower();
            string loweredSubtext = subtext.ToLower();

            for (int i = 0; i < answerArray.Length; i++)
            {
                answerArray[i] = FindMatch(cursor, text, subtext);
                cursor = answerArray[i];
                if (answerArray[i] < 0)
                {
                    break;
                }
            }
            return answerArray;
        }
    }
}
