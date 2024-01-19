namespace ReadySetBoole.Ex04
{
    public class TruthTable
    {
        public static void PrintTruthTable(string? expr)
        {
            string letters = "";

            if (expr == null || expr.Length == 0)
                return;

            foreach (char c in expr)
            {
                if (Char.IsLetter(c))
                {
                    if (!letters.Contains(c))
                        letters += c;
                }
            }

            // Sort letter alphabetically
            letters = new string(letters.OrderBy(c => c).ToArray());

            foreach (var letter in letters)
            {
                Console.Write("| ");
                Console.Write(letter);
                Console.Write(' ');
            }
            Console.WriteLine("| = |");

            // Print separation
            foreach (var letter in letters)
            {
                Console.Write("|---");
            }
            Console.WriteLine("|---|");

            ReplaceAndPrint(expr, letters);
        }

        private static void ReplaceAndPrint(string expr, string letters)
        {
            int[] truthLine = new int[letters.Length];
            bool stop = false;

            for (int i = 0; i < truthLine.Length; i++)
                truthLine[i] = 0;

            // Once every int is 1, we stop because we have printed all the truth table
            while (!stop)
            {
                // Check if we have to stop
                stop = true;
                for (int i = 0; i < truthLine.Length; i++)
                {
                    if (truthLine[i] == 0)
                    {
                        stop = false;
                        break;
                    }
                }

                printTruthLine(expr, letters, truthLine);
                // Update the truth line
                updateTruthLine(truthLine);
            }
        }

        private static void printTruthLine(string expr, string letters, int[] truthLine)
        {
            // replace expr with truthLine
            for (int i = 0; i < letters.Length; i++)
            {
                expr = expr.Replace(letters[i], (char)(truthLine[i] + '0'));
            }

            bool exprResult = ReadySetBoole.Ex03.BooleanEvaluation.Evaluate(expr);

            for (int i = 0; i < truthLine.Length; i++)
            {
                Console.Write("| ");
                Console.Write(truthLine[i]);
                Console.Write(' ');
            }
            Console.Write("| ");
            Console.ForegroundColor = exprResult ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(exprResult ? 1 : 0);
            Console.ResetColor();
            Console.WriteLine(" |");
        }

        private static void updateTruthLine(int[] truthLine)
        {
            // I need to update the truth line to follow the pattern of a truth table
            // The logic: Go in a reverse order, and change to one the first 0 you find, then stops.
            // Turn to 0 all encountered 1.
            for (int i = truthLine.Length - 1; i >= 0; i--)
            {
                if (truthLine[i] == 0)
                {
                    truthLine[i] = 1;
                    break;
                }
                else
                    truthLine[i] = 0;
            }
        }
    }
}
