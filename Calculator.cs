namespace Average_Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######################################################################################");
            Console.WriteLine("'END': Calculates all number entrys (Requires atleast 2 entrys)");
            Console.WriteLine("'ENDr': Same as 'END' but allows you to calculate another set of numbers");
            Console.WriteLine("'repeat:x:y;' Repeats one number for X entrys (ex. repeat:1.5:5; Repeats the number 1.5");
            Console.WriteLine("For 5 Entrys (You can also use (ex. repeat:12.42;) to repeat 12.42, 12 times)");
            Console.WriteLine(" ");
            Console.WriteLine("If you see a bunch of zeros followed by a small number, ignore it, thats an error that I cant fix");
            Console.WriteLine("                                         (ex: 14.000000000000000000000034)");
            Console.WriteLine("You can do around 65535 Numbers (If you'd like)");
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
                    tester2 = tester2.Trim();

                    string[] splitRepeat = tester2.Split(':', 2);

                    if (splitRepeat.Length == 2)
                    {
                        double[] splitRepeatD = new double[splitRepeat.Length];
                        splitRepeatD[0] = Convert.ToDouble(splitRepeat[0]);
                        splitRepeatD[1] = Convert.ToInt32(splitRepeat[1]);

                        for (int i = 0; i < splitRepeatD[1]; i++)
                        {
                            numbers[inputCount] = splitRepeatD[0];
                            Console.WriteLine("Entry " + inputCount + ": " + numbers[inputCount]);
                            inputCount++;
                        }
                    } else if (splitRepeat.Length == 1) {
                        string[] temp = splitRepeat[0].Split('.', 2);
                        int splitRepeatD = Convert.ToInt32(temp[0]);

                        for (int i = 1; i <= splitRepeatD; i++)
                        {
                            numbers[inputCount] = Convert.ToDouble(splitRepeat[0]);
                            Console.WriteLine("Entry " + inputCount + ": " + numbers[inputCount]);
                            inputCount++;
                        }
                    } else
                    {
                        Console.WriteLine("The repeat syntax you used was either too short or too long");
                    }
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
            finalResult /= inputCount;
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