using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace diary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\VICTUS\\source\\repos\\csharp\\diary\\diary\\input.txt";
            Check();

            void Check()
            {
                Console.WriteLine("1-read\n2-write\n3-close");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Read();
                }
                else if (choice == "2")
                {
                    Write();
                }
                else if (choice == "3")
                {
                    Close();
                }
            }
            void Close()
            {
                Environment.Exit(0);
            }
            void Read()
            {
                StreamReader streamReader = new StreamReader(path);
                string line = streamReader.ReadToEnd();
                Console.WriteLine(line);
                streamReader.Close();
                Check();
            }
            void Write()
            {
                StreamWriter streamWriter = new StreamWriter(path, true);
                string userinput = Console.ReadLine();
                streamWriter.WriteLine(userinput);
                streamWriter.Close();
                Check();
            }
        }
    }
}
