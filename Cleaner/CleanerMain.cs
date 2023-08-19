namespace Cleaner
{
    public class CleanerMain
    {
        public void RunCleaner(string[] args)
        {
            List<string> list = new List<string>();

            Console.WriteLine(string.Join("\n", args));

            var allFiles = GetAllFilesInDirectory(@"D:\Download", false);


            //Call cleaner functions here

            //Console.WriteLine(string.Join("\n", allFiles));
        }

        public List<string> GetAllFilesInDirectory(string targetDirectory, bool deleteDirectory)
        {
            var allFiles = new List<string>();

            Parallel.ForEach(Directory.EnumerateDirectories(targetDirectory, "*", SearchOption.AllDirectories), (dir) =>
            {
                if (!IsEmptyDirectory(dir))
                {
                    allFiles.Add(dir);
                }
                else if (deleteDirectory)
                {
                    Directory.Delete(dir, true);
                }
                else
                {
                    Console.WriteLine($@"This dir: {dir} is empty");
                }
            });

            Parallel.ForEach(Directory.EnumerateFiles(targetDirectory, "*", SearchOption.AllDirectories), (file) =>
            {
                allFiles.Add(file);
            });

            return allFiles;
        }

        static bool IsEmptyDirectory(string dir)
        {
            return !Directory.EnumerateFileSystemEntries(dir).Any();
        }
    }
}