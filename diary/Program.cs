using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Security.Policy;

namespace diary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\VICTUS\\source\\repos\\csharp\\diary\\diary\\input.txt";
            Check(path);
        }
        static void Check(string path)
        {
            Console.WriteLine("1-read\n2-write\n3-close");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Read(path);
            }
            else if (choice == "2")
            {
                Write(path);
            }
            else if (choice == "3")
            {
                Close();
            }
        }
        static void Close()
        {
            Environment.Exit(0);
        }
        static void Read(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string line = streamReader.ReadToEnd();
            string[] parts = line.Split('\n');
            List<string> result = new List<string>(parts);


            ConsoleKeyInfo keyinfo;
            int index = 0;
            while (true)
            {
                UpdatedMenu(index);
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index < result.Count - 1)
                    {
                        index++;
                    }
                    else { index = 0; }
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else { index = result.Count - 1; }
                }
                else if (keyinfo.Key == ConsoleKey.Enter)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = result[index], // URL браузера будет использован как имя файла
                        UseShellExecute = true
                    });

                    break;
                }
            }


            streamReader.Close();
            Check(path);

            void UpdatedMenu(int _index)
            {
                Console.Clear();
                foreach (string item in result)
                {
                    string selectOptionSymbol = "  ";
                    if (item == result[_index])
                    {
                        selectOptionSymbol = "> ";
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{selectOptionSymbol}{item}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        static void Write(string path)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            string userinput = Console.ReadLine();
            streamWriter.WriteLine(userinput);
            streamWriter.Close();
            Check(path);
        }
    }
}
