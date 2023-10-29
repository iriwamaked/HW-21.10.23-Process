using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid arguments! Please provide a file path and a word to search for.");
                return;
            }

            string filePath = args[0];
            string wordToSearch = args[1];

            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                int wordCount = CountOccurrences(content, wordToSearch);
                Console.WriteLine($"The word '{wordToSearch}' was found {wordCount} times in the file.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The specified file does not exist.");
                Console.ReadKey();
            }
        }

        static int CountOccurrences(string content, string word)
        {
            int count = 0;
            int i = 0;
            while ((i = content.IndexOf(word, i, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                i += word.Length;
                count++;
            }
            return count;
        }
    
    }
}
