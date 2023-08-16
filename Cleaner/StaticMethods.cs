namespace Cleaner
{
    public class StaticMethods
    {
        public static bool IsPathParameterPrensent(string[] args)
        {
            if (!args.Contains("--path") || !args.Contains("-path"))
            {
                return false;
            }
            return true;
        }
    }
}
