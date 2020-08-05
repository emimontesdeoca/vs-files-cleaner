using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VsFilesCleanerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 0)
            {
                var currentDirectory = args[0];
                var folders = new string[] { "obj", "bin" };
                var directories = GetDirectories(currentDirectory, folders);
                directories.ForEach(x => Directory.Delete(x));
            }
        }

        static List<string> GetDirectories(string path, string[] folders)
        {
            List<string> directories = new List<string>();

            if (Directory.Exists(path))
            {
                foreach (var folder in folders)
                {
                    directories.AddRange(Directory.GetDirectories(path, folder, SearchOption.AllDirectories).ToList());
                }
            }

            return directories;
        }
    }
}
