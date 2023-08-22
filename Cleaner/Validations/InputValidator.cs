using System.Reflection;

namespace Cleaner.Validations
{
    public class InputValidator
    {
        public readonly string[] args;

        public InputValidator(string[] args)
        {
            this.args = args;
        }

        //Think of a way to call all the validation method inside validate dynamically
        // Things to consider : Reflection , A List of Function

        public bool Validate()
        {
            if (args.Length == 0)
            {
                PrintAssemblyInfoAndHelp();
                return false;
            }

            var allMethods = GetValidatorDelegatesList();

            foreach (var method in allMethods)
            {
                if (!method(args))
                {
                    return false;
                }
            }

            return true;
        }

        private void PrintAssemblyInfoAndHelp()
        {
            var versionString = Assembly.GetEntryAssembly()?
                                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.ToString();
            Console.WriteLine($"cleaner v{versionString}\n\n");

            Console.WriteLine("Options:\r\n  path|-path|--path         A required parameter. Write the path to the folder after this params");
        }

        private List<ParameterValidationDelegate> GetValidatorDelegatesList()
        {
            ValidtorMethods validtorMethods = new ValidtorMethods();

            var checkMethods = new List<ParameterValidationDelegate>
            {
                 validtorMethods.CheckForRequiredParameters
                 //Add new validators here 
            };

            return checkMethods;
        }
    }
}