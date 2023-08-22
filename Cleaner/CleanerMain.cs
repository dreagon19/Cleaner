using Cleaner.Validations;

namespace Cleaner
{
    public class CleanerMain
    {
        public void RunCleaner(string[] args)
        {
            //Validating Input
            var inputValidated = ValidateInput(args);

            if (inputValidated)
            {
                List<string> list = new List<string>();

                Console.WriteLine(string.Join("\n", args));

                //Get the path
                var path = GetPath(args);

                var allFiles = GetAllFilesInDirectory(path, false);

                //Call cleaner functions here

                //Console.WriteLine(string.Join("\n", allFiles));
            }
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

        private static bool IsEmptyDirectory(string dir)
        {
            return !Directory.EnumerateFileSystemEntries(dir).Any();
        }

        private string GetPath(string[] args)
        {
            return args[1];
        }

        public static bool ValidateInput(string[] args)
        {
            InputValidator validator = new InputValidator(args);
            var methods = typeof(InputValidator).GetMethods();

            return validator.Validate();
        }
    }
}