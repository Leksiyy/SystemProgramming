using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ArithmeticEvaluator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в консольное приложение для вычисления математических выражений!");
            
            while (true)
            {
                Console.Write("Введите математическое выражение (или 'exit' для выхода): ");
                string input = Console.ReadLine();

                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Выход из программы. До свидания!");
                    break;
                }

                try
                {
                    var result = await EvaluateExpression(input);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (CompilationErrorException ex)
                {
                    Console.WriteLine("Ошибка в выражении:");
                    foreach (var diagnostic in ex.Diagnostics)
                    {
                        Console.WriteLine(diagnostic.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        private static async Task<object> EvaluateExpression(string expression)
        {
            var options = ScriptOptions.Default
                .WithReferences(typeof(object).Assembly)
                .WithImports("System", "System.Math");

            return await CSharpScript.EvaluateAsync(expression, options);
        }
    }
}
