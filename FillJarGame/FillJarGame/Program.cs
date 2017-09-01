using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillJarGame
{

    public class Jar    //Created Jar class.
    {
        public string jaritem;
        public int jarMax;

        public Jar()
        {
            //empty construtor method.
        }

        public Jar(string val1, int val2)
        {
            jaritem = val1;
            jarMax = val2;
        }
    }

    class Program
    {
        static int StartGame(int jarMax, int randomJarNum, string jarItem)  //The method which starts the game from the player perspective.
        {
            int userInput = 0;      //Declared and initializes variables w/ values. 
            int attempts = 1;   

            Console.WriteLine("~New Game~\n");
            Console.WriteLine("How many {0} are in the jar? Pick a number between 1 and {1}\n", jarItem, jarMax);

            while (userInput != randomJarNum)   //While loop that will continue to loop until user response equals the random number.
            {
                Console.Write("please type your guess here:\t");
                userInput = Convert.ToInt32(Console.ReadLine());
                
                if (userInput != randomJarNum)      //nested boolean expressions for clean code execution.
                {
                    Console.WriteLine("Sorry, incorrect guess.");
                    attempts++;     //postfix operation that will increment the variable each time a guess is wrong.
                }
                else
                {
                    Console.WriteLine("\nCongrats, your guess of {0} is correct!\nYou got it in {1} attempt(s)", userInput, attempts);
                }

            }
            return (0);
        }

        static int FillJar(Jar object1)     //Method to generate a random number within the limits 1 and Max number of jar items. Object1 is "NewJar", just renamed.
        {
            int someNumber;

            Random RjarNum = new Random();  //Creates a new Random object.

            someNumber = RjarNum.Next(1, object1.jarMax);   //Executes the "Next" method in the "Random" class. Sends min (1) and max (object1.jarMax) as params and stores the random number into variable.

            return someNumber; //returns the variabl containing the random number generated.
        }

        static void CreateGame() //This method begins execution for the fill jar game. Also, houses the Admin mode of the Game.
        {
            string jarItem;             //A series of declared variables. 
            string continueGame;
            int jarMax;
            int randomJarNum;
            
            Console.WriteLine("~ADMINISTRATOR MODE~\n");
            Console.WriteLine("What type of item do you want to use to fill the jar?");
            jarItem = Console.ReadLine();      //Reads in user/admin input and stores it into a variable.

            Console.WriteLine("What is the maximum number of {0} that can fit in the jar?", jarItem);
            jarMax = Convert.ToInt32(Console.ReadLine());   //Reads in user/admin input, converts that input into a type "int", and stores it into a variable.

            Jar NewJar = new Jar(jarItem, jarMax);  //Creates a new Jar object from the creates Jar Class. Also, passes the two values captured from user/admin.

            do      //Do, while loop
            {
                Console.Clear();    //Clears console for clean code execution and readablity. 

                randomJarNum = FillJar(NewJar);     //Sends the new Jar object to a method for execution. Stores the return value from the fill jar method into variable.

                StartGame(jarMax,randomJarNum,jarItem);     //Passes several params to the method start game.  

                Console.WriteLine("\nWould you like to play Fill Jar the game again? Please type yes or no.");      
                continueGame = Console.ReadLine();  ////Reads in user/player input and stores it into a variable.

                if (continueGame == "no")           //A series of boolean expressions testing the input captured from user/player to continue the game.
                    continueGame = "no";
                else if (continueGame == "No")
                    continueGame = "no";
                else if (continueGame == "NO")
                    continueGame = "no";
                else
                    continueGame = "yes";
            }
            while (continueGame != "no");   //repeats do, while loop if user/player choose yes to continue the game.
            
        }

        static void Main(string[] args)
        {
            CreateGame(); 
        }
    }
}
