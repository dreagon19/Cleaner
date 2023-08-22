namespace Cleaner.Validations
{
    public delegate bool ParameterValidationDelegate(string[] args);

    public class ValidtorMethods
    {
        public bool CheckForRequiredParameters(string[] args)
        {
            if (StaticMethods.IsPathParameterNotPrensent(args))
            {
                Console.WriteLine("Missing:\r\n  path|-path|--path         A required parameter. Write the path to the folder after this parameter");
                return false;
            }
            return true;
        }
    }
}
