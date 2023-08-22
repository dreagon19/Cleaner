namespace Cleaner
{
    public class StaticMethods
    {
        public static bool IsPathParameterNotPrensent(string[] args)
        {
            if (!args.Contains("--path") || !args.Contains("-path"))
            {
                return true;
            }
            return false;
        }
    }
}
