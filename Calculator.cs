namespace Average_Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######################################################################################");
            Console.WriteLine("Enter numbers in and type 'END' to get the result (But you must have atleast 2 inputs)");
            Console.WriteLine("'END' Will calculate the average of all the numbers you've entered");
            Console.WriteLine("If you see a bunch of zeros followed by a small number, ignore it, thats an error that I cant fix");
            Console.WriteLine("                                         (ex: 14.000000000000000000000034)");
            Console.WriteLine("You can do around 65535 Numbers (If you'd like)");
            Console.WriteLine(" ");
            Console.WriteLine("Type 'ENDr' to get the result and calculate another set of numbers");
            Console.WriteLine("######################################################################################");
            reCalculate:
            bool allInputsComplete = false; // Initialize all variables
            bool doCalculationsAgain = false;
            string tester;
            int inputCount = 0;
            double[] numbers = new double[65535];
            for (int i = 0; i < 65535; i++) { numbers[i] = 0; }
            while (allInputsComplete == false || inputCount < 2)
            {
                Console.Write(inputCount + " Enter Number: ");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                tester = Convert.ToString(Console.ReadLine()); // Convert user input to either: number array or to end
                tester = tester.ToLower();
                if (tester == "end")
                { allInputsComplete = true; }
                else if (tester == "endr")
                { allInputsComplete = true; doCalculationsAgain = true; }
                else if (tester.StartsWith("repeat") && tester.EndsWith(";")) {

                    string tester2 = tester.Remove(0, 7);
                    tester2 = tester2.Replace(';', ' ');

                    string[] splitRepeat = tester2.Split(':',2);
                    splitRepeat[0] = Convert.ToDouble(splitRepeat[0]);

                    Console.WriteLine(splitRepeat[0]);
                    /*
                    string[] splitRepeat = tester.Split(':',2,"repeat");
                    splitRepeat[1] = Convert.ToDouble(splitRepeat[1]);
                    
                    for (int i = 0; i < splitRepeat[1]; i++)
                    {
                        numbers[inputCount] = Convert.ToDouble(splitRepeat[2]);
                        inputCount++;
                    }
                    Console.WriteLine(splitRepeat.Length);
                    */
                }
                else if (inputCount >= 65534) {
                inputCount = 65534;
                    Console.WriteLine("You have exceded the maximum number of possible entrys");
                    allInputsComplete = true;
                    doCalculationsAgain = true;
                }
                else
                {
                    try { numbers[inputCount] = Convert.ToDouble(tester); } // Try to convert the number to a double and if its not
                    catch                                                   // Then tell the user they put invalid stuff i guess
                    {
                        Console.WriteLine("Possible invalid entry (Try again)");
                        inputCount--;
                    }
                    inputCount++;
                }
            }
            double finalResult = numbers[0] + numbers[1]; // This actually calculates the average
            for (int i = 2; i <= inputCount; i++)
            {
                finalResult += numbers[i];
            }
            finalResult = finalResult / inputCount;
            Console.WriteLine(finalResult);
            if (doCalculationsAgain)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Do it again....");
                Console.WriteLine("In all known laws of physics, there is no way a bee can fly");
                goto reCalculate;
            }
            Console.ReadLine();
        }
    }
}
