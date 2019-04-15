using System;
using System.Text.RegularExpressions;

namespace TestCommandSharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Declaration of constants 122 = z, 97 = a
            const ushort maxRange = 122;
            const ushort minimumRange = 96;
           
            if (args.Length == 0)
            {
                Console.WriteLine("Please pass an argument to the command line in the following format:");
                Console.WriteLine("Each parameter should be of the form <number><string> where <number> is a single digit from 0 to 9 and <string> is a lower case string composed of the characters from a to z with length of at least 1.");
                Console.WriteLine("ex: 0apple, 1arthur, 9z ...");

                return;
            } else { 
            
                //Gets the value out from the arguments 
                foreach(string arg in args)
                {
                    //saving the inital arg in a variable for easy acess
                    string parameter = arg;
                    //The Regex that is being used here will discard the numeric values after first input - Eg: 111 will be only 1
                    ushort number = ushort.Parse(Regex.Match(parameter, @"\d").Value);
                    //The Regex here returns only the string portion of the paramater as lowercase.
                    string str = Regex.Replace(parameter, @"[\d-]", string.Empty).ToLower();
                    //Checks if the argument has at least one character or esle print an error message
                    if (str.Length >= 1)
                    {
                        //Converts the string to a character array so we can increment the values
                        char[] CharArr = str.ToCharArray();
                        for (int i = 0; i < CharArr.Length; i++)
                        {
                            //Passing the char to a variable for easy referencing
                            ushort charInt = CharArr[i];
                            ushort addedChar = (ushort)(charInt + number);
                            //Checks if the added value passed the Z letter range and starts again on A
                            if (addedChar > maxRange)
                            {
                                ushort deficit = (ushort)(addedChar - maxRange);
                                charInt = (ushort)(minimumRange + deficit);
                            } else
                            {
                                charInt = addedChar;
                            }
                            //We are passing the added and converted char value back to its array position all in this single function.
                            CharArr[i] = (char)(charInt);
                        }
                        //Converts the Char Array back into string to print
                        string result = new string(CharArr);
                        //Print out the parameter and its new changed version in a single line
                        Console.WriteLine($"{parameter} -> {result}");
                    } else
                    {
                        Console.WriteLine($"{parameter} -> is not a valid argument, please add a <string> of at least one character after your numerical<int> value. eg: '1s'");
                    }

                }
            }
        }
    }
}
