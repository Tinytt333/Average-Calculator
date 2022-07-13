namespace Average_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######################################################################################");
            Console.WriteLine("Enter numbers in and type 'END' to get the result (But you must have atleast 2 inputs)");
            Console.WriteLine("'END' Will calculate the average of all the numbers you've entered");
            Console.WriteLine("If you see a bunch of zeros followed by a small number, ignore it, thats an error that I cant fix");
            Console.WriteLine("                                         (ex: 14.000000000000000000000034)");
            Console.WriteLine("You can do around 15000 Numbers (If you'd like)");
            Console.WriteLine(" ");
            Console.WriteLine("Type 'ENDr' to get the result and calculate another set of numbers");
            Console.WriteLine("######################################################################################");
            reCalculate:
            bool allInputsComplete = false; // Initialize all variables
            bool doCalculationsAgain = false;
            string Tester;
            int inputCount = 0;
            double[] numbers = new double[15009];
            for (int i = 0; i < 15007; i++) { numbers[i] = 0; }
            while (allInputsComplete == false || inputCount < 2)
            {
                Console.Write(inputCount + " Enter Number: ");

                Tester = Convert.ToString(Console.ReadLine()); // Convert user input to either: number array or to end
                Tester = Tester.ToLower();
                if (Tester == "end")
                { allInputsComplete = true; }
                else if (Tester == "endr")
                { allInputsComplete = true; doCalculationsAgain = true; }
                else if (inputCount >= 15006) {
                    inputCount = 15006;
                    Console.WriteLine("You have exceded the maximum number of possible entrys");
                    allInputsComplete = true;
                    doCalculationsAgain = true;
                }
                else
                {
                    try { numbers[inputCount] = Convert.ToDouble(Tester); } // Try to convert the number to a double and if its not
                    catch                                                   // Then tell the user they put invalid stuff i guess
                    {
                        Console.WriteLine("Possible invalid entry (Try again)");
                        inputCount += 150;
                    } // Ik this looks dumb but idk another way too do this (might change it later)
                    inputCount++;
                }
            }
            double finalResult = numbers[0] + numbers[1]; // This actually calculates the average
            for (int i = 2; i <= inputCount; i++)
            {
                finalResult += numbers[i]; // This was originally "finalResult = finalResult + numbers[i]" until I remembered '+='
            }                               // But ofcourse floating point garbage happens which is the reason for the 4th Console.WriteLine
            finalResult = finalResult / inputCount;
            Console.WriteLine(finalResult);
            if (doCalculationsAgain)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Do it again....");
                goto reCalculate;
            }
            Console.ReadLine();
        }
    }
}