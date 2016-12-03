using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCounter
{
    class WordCounter
    {
        int i, count = 0, j = 1;
        static string line = "";
        char delimiter = ' ';
        char delimiter2 = '\n';
        static void Main()
        {           
            WordCounter pro = new WordCounter();

            line = File.ReadAllText("text.txt");

            pro.Process(pro.GetFile(line));
        }

        public List<string> GetFile(string text)
        {
            List<string> sampleText = new List<string>();
            sampleText = line.Split(delimiter, delimiter2).ToList();
            return sampleText;
        }

        public void Process(List<string> words)
        {
            for(i = 0; i <= words.Count - 1; i++)
            {
                if(i == words.Count - 1)
                {
                    count++;
                    Console.WriteLine("Word: [" + words[i] + "] occured " + count + " times");
                }
                else
                {
                    count++;
                }

                while(j != words.Count)
                {   
                    if(words[j] == words[i])
                    {
                        count++;
                        words.RemoveAt(j);
                    } 
                    else
                    {
                        j++;
                    }

                    if(j == words.Count)
                    {
                        Console.WriteLine("Word: [" + words[i] + "] occured " + count + " times"); 
                        j = i;
                        j += 2;
                        count = 0;
                        break;
                    } 
                }
            }
        }
    }
}