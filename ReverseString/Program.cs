using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sample = "this";
            char temp = ' ';
            int i = 0, j;
    
            char[] convert = sample.ToCharArray();
            
            if(convert.Length % 2 == 0)
            {
                for(i = 0; i < convert.Length/2; i++)
                {
                    for(j = convert.Length/2; j < convert.Length; j++)
                    {
                            temp = convert[j];
                            convert[j] = convert[i];
                            convert[i] = temp;
                    }
                }
            }
            else
            {
                for(i = 0; i < convert.Length/2; i++)
                {
                    for(j = (convert.Length/2) + 1; j < convert.Length; j++)
                    {
                            temp = convert[j];
                            convert[j] = convert[i];
                            convert[i] = temp;
                    }
                }
            }

            sample = new string(convert);
            Console.WriteLine(sample);
            Console.WriteLine();
            //sConsole.WriteLine();
        }
    }
}

//this
//siht

//homer
//remoh