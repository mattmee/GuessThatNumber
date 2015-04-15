using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0;
        static Random randomNumber = new Random();
       
        static void Main(string[] args)
        {
            string input = string.Empty;
            int numberOfGuesses = 0;
            int guess = 0;
            SetNumberToGuess(randomNumber.Next(1, 101));
            AutoGuess(); //Computer figures out random number
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("The computer has randomly generated a number between 1 and 100. Make a guess! A number between 1 and 100 <3");
            do
            {
                SetNumberToGuess(randomNumber.Next(1, 101));  //sets the random number, between 1 and 100, 101 is not included
                while (guess != NumberToGuess)        //loop iterates until the guess is equal to the randomly selected number
                {
                    do
                    {
                        Console.WriteLine("Choose a number between 1 and 100.");
                        input = Console.ReadLine(); //gets a string input value 
                        if (ValidateInput(input))   //if input is convertable to an int between 1 and 100, convert the string to an int value
                        {
                            guess = Convert.ToInt32(input);  //converts the string variable into an int
                        }
                    } while (!ValidateInput(input));        //tests to see if the input is valid ie. convertable to int and between 1 and 100
                    numberOfGuesses++;                 //increment the guess amount
                    IsGuessTooHigh(guess);             //function call to see if guess is too high, function prints shit out
                    IsGuessTooLow(guess);              //function call to see if guess is too low, function prints shit out
                }
                Console.WriteLine("Great job! It took only {0} guesses to find out that {1} was the random number!", numberOfGuesses, NumberToGuess);  //cool!
                Console.WriteLine("Would you like to play again? yes or no");  //so thats a thing
                input = Console.ReadLine();  //gets input to see if user wants to play again
            } while (input == "yes" || input == "y" || input == "Yes" || input == "YES");   //if input is any of these strings, the loop starts
        }
        /// <summary>
        /// Automatically finds the random number by picking the center number between high and low
        /// </summary>
        public static void AutoGuess()
        {
            int guessNumber = 1;
            int newGuess = 50;
            int lowGuess = 0;
            int highGuess = 101;
            Console.WriteLine("Guess: {0}", newGuess);
            Console.WriteLine(NumberToGuess);
            while (newGuess != NumberToGuess)
            {
                guessNumber++;
                if (IsGuessTooHigh(newGuess) == true) //if guess is too high, change the upperbound limit
                {
                    highGuess = newGuess;
                    newGuess -= (highGuess - lowGuess) / 2; //new guess is set to the middle of the upper and lower bound limits
                }
                else if (IsGuessTooLow(newGuess) == true) //if guess is too low, change the lowerbound limit
                {
                    lowGuess = newGuess;
                    newGuess += (highGuess - lowGuess) / 2; //new guess is set to the middle of the upper and lower bound limits
                }
                Console.WriteLine("Guess: {0}", newGuess);
            }
            Console.WriteLine("Great job! It took only {0} guesses to find out that {1} was the random number!", guessNumber, NumberToGuess);  //cool!
        }

        /// <summary>
        /// Checks to see if the  user input is valid (convertable to an int)
        /// </summary>
        /// <param name="userInput">string value for user input</param>
        /// <returns></returns>
        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.
            int x = 0;
            if (Int32.TryParse(userInput, out x)) //tests to see if user input can be cconverted into an int
            {
                if (x < 101 && x > 0) //tests to see if user input is between 1 and 100
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        /// <summary>
        /// Sets global number to be guessed
        /// </summary>
        /// <param name="number">int random number</param>
        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;  //sets the global variable to the inputed number
        }
        /// <summary>
        /// Takes in the user's guess and checks to see if it is higher than the random number to guess
        /// </summary>
        /// <param name="userGuess">int user guess</param>
        /// <returns></returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            //self explainatory, if you don't understand what's going on you shouldn't be programming
            if (NumberToGuess < userGuess)
            {
                if (userGuess - NumberToGuess <= 10)  //if user guess is within 10
                    Console.WriteLine("Getting Warmer, but too high!");
                else
                    Console.WriteLine("Cold! Too high!");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Takes in the user's guess and checks to see if it is higher than the random number to guess
        /// </summary>
        /// <param name="userGuess">int user guess</param>
        /// <returns></returns>
        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            //self explainatory, if you don't understand what's going on you shouldn't be programming
            if (NumberToGuess > userGuess)
            {
                if (NumberToGuess - userGuess <= 10)  //if user guess is within 10
                    Console.WriteLine("Getting Warmer, but too low!");
                else
                    Console.WriteLine("Cold! Too low!");
                return true;
            }
            else
                return false;
        }
    }
}
