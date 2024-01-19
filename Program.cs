using System;
using ReadySetBoole.Ex00;
using ReadySetBoole.Ex01;
using ReadySetBoole.Ex02;
using ReadySetBoole.Ex03;
using ReadySetBoole.Ex04;

namespace ReadySetBoole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exerciceNum = CheckArgs(args);
            if (exerciceNum == -1)
                return;

            switch (exerciceNum)
            {
                case 0:
                    Console.WriteLine("Exercise 00 - Adder (Enter \"quit\" to quit)");
                    while (true)
                    {
                        int a = GetNaturalNumberFromInput("\nFirst number: ");
                        if (a == -1)
                            break;
                        int b = GetNaturalNumberFromInput("Second number: ");
                        if (b == -1)
                            break;

                        int result = Adder.Add(a, b);

                        Console.WriteLine("Result is : " + result);
                    }
                    break;

                case 1:
                    Console.WriteLine("Exercise 01 - Multiplier (Enter \"quit\" to quit)");
                    while (true)
                    {
                        int a = GetNaturalNumberFromInput("\nFirst number: ");
                        if (a == -1)
                            break;
                        int b = GetNaturalNumberFromInput("Second number: ");
                        if (b == -1)
                            break;

                        int result = Multiplayer.Multiply(a, b);

                        Console.WriteLine("Result is : " + result);
                    }
                    break;

                case 2:
                    Console.WriteLine("Exercise 02 - Gray Code (Enter \"quit\" to quit)");
                    while (true)
                    {
                        int a = GetNaturalNumberFromInput("\nNumber: ");
                        if (a == -1)
                            break;

                        int result = GrayCode.GetGrayCode(a);

                        Console.WriteLine("Result is : " + result);
                    }
                    break;

                case 3:
                    Console.WriteLine("Exercise 03 - Boolean evaluation (Enter \"quit\" to quit)");
                    while (true)
                    {
                        Console.Write("\nInput: ");
                        string? input = Console.ReadLine();
                        while (input == null)
                        {
                            Console.Write("\nInput: ");
                            input = Console.ReadLine();
                        }
                        if (input != null && input.Equals("quit"))
                            break;

                        bool result = BooleanEvaluation.Evaluate(input);

                        Console.WriteLine("Result is : " + result);
                    }
                    break;

                case 4:
                    Console.WriteLine("Exercise 04 - Truth table (Enter \"quit\" to quit)");
                    while (true)
                    {
                        Console.Write("\nInput: ");
                        string? input = Console.ReadLine();
                        while (input == null)
                        {
                            Console.Write("\nInput: ");
                            input = Console.ReadLine();
                        }
                        if (input != null && input.Equals("quit"))
                            break;

                        TruthTable.PrintTruthTable(input);
                    }
                    break;
                default:
                    Console.Error.WriteLine("One exercise number is expected.");
                    Console.Error.WriteLine("Ex: dotnet run 00");
                    break;
            }
        }

        private static int CheckArgs(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("One exercice number is expected.");
                Console.Error.WriteLine("Ex: dotnet run 00");

                return -1;
            }

            int exerciceNum;
            if (!int.TryParse(args[0], out exerciceNum))
            {
                Console.Error.WriteLine("A number is expected.");
                Console.Error.WriteLine("Ex: dotnet run 00");

                return -1;
            }

            if (exerciceNum < 0 || exerciceNum > 11)
            {
                Console.Error.WriteLine("Only exercises 0 - 11 are available.");

                return -1;
            }

            if (args.Length > 1)
            {
                Console.WriteLine(
                    "Warning: More than one argument provided, only the first one will be proceeded"
                );
            }

            return exerciceNum;
        }

        private static int GetNaturalNumberFromInput(string message)
        {
            string? input;
            int number;

            Console.Write(message);
            input = Console.ReadLine();

            if (input != null && input.Equals("quit"))
                return -1;

            while (!int.TryParse(input, out number) || number < 0)
            {
                Console.Write("Please enter a valid natural number: ");
                input = Console.ReadLine();

                if (input != null && input.Equals("quit"))
                    return -1;
            }

            return number;
        }
    }
}
