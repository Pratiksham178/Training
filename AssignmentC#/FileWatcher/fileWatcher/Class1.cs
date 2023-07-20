
using System;
using System.Configuration;
using System.IO;

namespace fileWatcher
{
    class Program
    {
        
        public static string GetPath(string keyname)
        {
            string path;
            path = ConfigurationManager.AppSettings.Get(keyname);

            return path;
        }
        public static void WriteLog(string message)
        {
            var dateTime = DateTime.Now;
            var path = GetPath("pathLogFolder");
            String filename = $"{path}/{dateTime.ToShortDateString()}.txt";
            File.AppendAllText(filename, message);
            
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            string message = $"Changed : {e.FullPath} at {DateTime.Now.TimeOfDay}\n";
            WriteLog(message);
            Console.WriteLine(message);
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string message = $"Created : {e.FullPath}\nAt {DateTime.Now.TimeOfDay}\n";
            WriteLog(message);
            Console.WriteLine(message);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e){
            string message = $"Deleted : {e.FullPath}\nat {DateTime.Now.TimeOfDay} \n";
            WriteLog(message);
            Console.WriteLine($"Deleted: {e.FullPath}");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            string message = $"Renamed :\nOld: {e.OldFullPath} \nNew: {e.FullPath}\nat {DateTime.Now.TimeOfDay}\n";
            WriteLog(message);
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
        public static void Main()
        {
            string path = GetPath("path");
            Console.WriteLine(path);
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            Console.ReadKey();
        } 
    }
}