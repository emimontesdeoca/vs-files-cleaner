using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace VsFilesCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("vs-files-cleaner (https://github.com/emimontesdeoca/vs-files-cleaner).");
            Console.WriteLine("");
            Console.WriteLine("This application looks in all directories from this path for folders \"bin\" and \"obj\" and remove them.");
            Console.WriteLine("");

            var currentDirectory = @"C:\Development\Prodanet";
            var folders = new string[] { "obj", "bin" };
            var directories = GetDirectories(currentDirectory, folders);
            TreatDirectories(directories);

            Console.WriteLine("");
            Console.Write($"Press a key to exit");
            Console.ReadKey();
        }

        static List<string> GetDirectories(string path, string[] folders)
        {
            Console.WriteLine($"Getting directories in path: \"{path}\".");

            List<string> directories = new List<string>();

            foreach (var folder in folders)
            {
                directories.AddRange(Directory.GetDirectories(path, folder, SearchOption.AllDirectories).ToList());
            }

            return directories;
        }

        static void TreatDirectories(List<string> directories)
        {
            if (directories.Count > 0)
            {
                Console.Write($"Found {directories.Count} to remove, do you want to proceed? (y/n): ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "y":
                        directories.ForEach(x => Directory.Delete(x));
                        Console.WriteLine($"Removed all directories.");
                        break;
                    default:
                        Console.WriteLine($"Operation cancelled.");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"No directories found, nothing to do.");
            }
        }
    }
}
