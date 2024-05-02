using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{


    internal class sevensOut
    {
        

        // Properties
        public int total;
        private int _P1total; //Totals and total score of both players
        private int _P2total;
        public int P1score;
        public int P2score;
        private Die _die;
        public int rolled;
        private int _die1;
        private int _die2;
        private bool _gameContinue;


        //Constructor method
        public sevensOut()
        {
            statistics.sevensOutBegin(); //Incirments the beginning the game statistic

            //Introduction to player with instructions and options to progress.
            Console.WriteLine("\n\n\nWelcome to Sevens Out! Press enter to progress through the game.\n\n---------------------------\n1) Singleplayer vs Computer\n2) Two player\n---------------------------\n\nSelect an option:");
            string choice = Console.ReadLine();

            if (choice == "1") //If statement to decipher which gamemode player requires
            {
                while (playSingle()) //While loop calls function playSingle each time it compares, continuing until the method returns false
                { Console.WriteLine(""); }
            }
            else if (choice == "2")
            {
                while (playDouble())
                { Console.WriteLine(""); }
            }
            else { Console.WriteLine(""); } //Returns to menu if no or wrong value entered

        }

        //Methods
        public int rollDie() //Rolls a single die and returns its value
        {
            _die = new Die(); //Instantiates a die object 
            rolled = _die.Roll(); //Calls the die method roll().

            return rolled;
        }

        private int turn() //Takes two die and rolls them using above method then returns the total of them
        {
            _die1 = rollDie();
            _die2 = rollDie();

            total = _die1 + _die2; //Total of both die rolls

            if (_die1 == _die2) //If both rolls are the same, the value is doubled.
            { total = total * 2; }

            return (total);
        }


        public bool playSingle() //Single player implimentation against the computer.
        {
            Console.WriteLine(""); //Used for formating
            _gameContinue = true; //Variable depicts what is returned at the end of the game.

            _P1total = turn(); // Total roll value of the two die

            if (_P1total == 7) //If 7, the game halts.
            {
                Console.WriteLine("\nYou roled 7 and are out!\nYou scored " + P1score + ".\nThe computer scored " + P2score + ".");
                Console.ReadKey(); //Allows the user to view the console before it closes.
                _gameContinue = false; //Game ends after P2.
            }
            else
            {
                P1score = P1score + _P1total; //Adds score
                Console.WriteLine("You rolled " + _P1total + ".\nYour score is now " + P1score + ".\n");
            }



            _P2total = turn(); // Mirrored above for P2

            if (_P2total == 7)
            {
                Console.WriteLine("\nThe computer rolled 7 and is out!\nYou scored " + P1score + ".\nThe computer scored " + P2score + ".");
                Console.ReadKey();
                _gameContinue = false;
            }
            else
            {
                P2score = P2score + _P2total;
                Console.WriteLine("The computer rolled " + _P2total + ".\nThe computer's score is now " + P2score + ".");
            }

            Console.ReadLine(); //Allows user to press enter to continue

            //To prevent unfair amount of goes, returning is left until the end.
            if (_gameContinue == false) { statistics.sevensOutCompleted(); return false; }
            else { return true; }
        }


        public bool playDouble() //Duplication of above with minor tweaks
        {
            Console.WriteLine("");
            _gameContinue = true;

            _P1total = turn();

            if (_P1total == 7)
            {
                Console.WriteLine("\nPlayer 1 roled 7 and is out!\nYou scored " + P1score + ".\nPlayer 2 scored " + P2score + ".");
                Console.ReadKey();
                _gameContinue = false;
            }
            else
            {
                P1score = P1score + _P1total;
                Console.WriteLine("Player 1 rolled " + _P1total + ".\nPlayer 1's score is now " + P1score + ".\n");
            }

            Console.ReadLine(); //Allows user to press enter to have next go.

            _P2total = turn();

            if (_P2total == 7)
            {
                Console.WriteLine("\nPlayer 2 rolled 7 and is out!\nPlayer 1 scored " + P1score + ".\nPlayer 2 scored " + P2score + ".");
                Console.ReadKey();
                _gameContinue = false;
            }
            else
            {
                P2score = P2score + _P2total;
                Console.WriteLine("Player 2 rolled " + _P2total + ".\nPlayer 2's score is now " + P2score + ".");
            }

            Console.ReadLine();

            if (_gameContinue == false) { statistics.sevensOutCompleted(); return false; }
            else { return true; }
            
        }
    }



    internal class threeOrMore
    {
        //Properties
        private Die _die;
        private int _rolled;
        private int _die1; //Declares all die variables
        private int _die2;
        private int _die3;  
        private int _die4;
        private int _die5;
        private bool _gameContinue;
        private int _one; //Variables to count quanitity of values
        private int _two;
        private int _three;
        private int _four;
        private int _five;
        private int _six;
        public int _P1score;
        public int _P2score;
        private int _player;

        //Constructor method
        public threeOrMore()
        {
            statistics.threeOrMoreBegin(); //Incriments statistic

            //Introduction to player with instructions and options to progress.
            Console.WriteLine("\n\n\nWelcome to Three or more! Provide answers and press enter to progess through the game.\n\n---------------------------\n1) Two player\n---------------------------\n\nSelect an option:");
            string choice = Console.ReadLine();
            _die = new Die(); //Instatiates die object to be used by rollDie()

            _gameContinue = true;

            if (choice == "1") //If statement to decipher which gamemode player requires
            {
                Console.WriteLine("\nPlayer 1:");
                while (_gameContinue)
                { playDouble(); }
            }
            else { Console.WriteLine(""); } //Returns to menu if no or wrong value entered
        }

        //Methods

        public int rollDie() //Rolls a single die and returns its value
        {
            _rolled = _die.Roll(); //Calls the die method roll().

            return _rolled;
        }

        public void addScore(int points) 
        {
            if (_player == 2 || _player == 0) //Swaps the player each turn and adds appropriate points
            {
                _player = 1;
                _P1score = _P1score + points;
                Console.WriteLine(_P1score + " " + _P2score + "\n");
                if (_P1score > 19) //If p1 achieves or exceeds 20 points, the game stops.
                {
                    Console.WriteLine("Player 1 wins! Player 1 scored " + _P1score + "and player 2 scored " + _P2score + ".");
                    _gameContinue = false; statistics.threeOrMoreCompleted();
                }
                Console.WriteLine("\nPlayer 2:");
            }
            else
            {
                _player = 2;
                _P2score = _P2score + points;
                Console.WriteLine("Player 1: " + _P1score + "   Player 2: " + _P2score + "\n");
                if (_P2score > 19) //If p2 achieves or exceeds 20 points, the game stops.
                {
                    Console.WriteLine("Player 2 wins! Player 1 scored " + _P1score + "and player 2 scored " + _P2score + ".");
                    _gameContinue = false; statistics.threeOrMoreCompleted();
                }
                Console.WriteLine("\nPlayer 1:");
            }
        }

        public void playDouble()
        {
            _die1 = rollDie(); //Rolls all the die
            _die2 = rollDie();
            _die3 = rollDie();
            _die4 = rollDie();
            _die5 = rollDie();


            int[] rolls = {_die1, _die2, _die3, _die4, _die5}; //Assembles die into an array

            for (int i = 0; i < rolls.Length; i++) //Iterrates through the rolls array, counting the number of each value
            {
                if (rolls[i] == 1) { _one++; }
                else if (rolls[i] == 2) { _two++; }
                else if (rolls[i] == 3) { _three++; }
                else if (rolls[i] == 4) { _four++; }
                else if (rolls[i] == 5) { _five++; }
                else if (rolls[i] == 6) { _six++; }
            }

            Console.WriteLine("\nYou rolled: " + _die1 + ", " + _die2 + ", " + _die3 + ", " + _die4 + ", " + _die5); //Prints rolled outcomes ot user

            if (_one == 5 || _two == 5 || _three == 5 || _four == 5 || _five == 5 || _six == 5) //Or statements
            {
                Console.WriteLine("You got a 5 of a kind! + 12 points");
                addScore(12); //Calls addscore to iterate which players go it is and add appropriate score
                Console.ReadLine();
            }

            else if (_one == 4 || _two == 4 || _three == 4 || _four == 4 || _five == 4 || _six == 4)
            {
                Console.WriteLine("You got a 4 of a kind! + 6 points");
                addScore(6);
                Console.ReadLine();
            }

            else if (_one == 3 || _two == 3 || _three == 3 || _four == 3 || _five == 3 || _six == 3)
            {
                Console.WriteLine("You got a 3 of a kind! + 3 points");
                addScore(3);
                Console.ReadLine();
            }

            else if (_one == 2 || _two == 2 || _three == 2 || _four == 2 || _five == 2 || _six == 2)
            {
                Console.WriteLine("You got a pair!\n---------------------------\n1) Reroll all die\n2) Reroll remaining 3 die\n---------------------------\n\nSelect an option:");
                string choice = Console.ReadLine();
                if (choice == "2") //If this choice is selected, the non pair die need to be singled out
                {
                    int pairValue = 0; //New variable for which value is the pair
                    if (_one == 2) pairValue = 1;
                    else if (_two == 2) pairValue = 2;
                    else if (_three == 2) pairValue = 3;
                    else if (_four == 2) pairValue = 4;
                    else if (_five == 2) pairValue = 5;
                    else if (_six == 2) pairValue = 6;

                    if (_die1 != pairValue) { _die1 = rollDie(); } //Only rerolls die that are not part of the pair
                    if (_die2 != pairValue) { _die2 = rollDie(); }
                    if (_die3 != pairValue) { _die3 = rollDie(); }
                    if (_die4 != pairValue) { _die4 = rollDie(); }
                    if (_die5 != pairValue) { _die5 = rollDie(); }

                    int[] rerolled = { _die1, _die2, _die3, _die4, _die5};

                    _one = _two = _three = _four = _five = _six = 0; //Resets counter variables back to 0

                    for (int i = 0; i < rolls.Length; i++) //Iterrates through the rolls array, counting the number of each value
                    {
                        if (rerolled[i] == 1) { _one++; }
                        else if (rerolled[i] == 2) { _two++; }
                        else if (rerolled[i] == 3) { _three++; }
                        else if (rerolled[i] == 4) { _four++; }
                        else if (rerolled[i] == 5) { _five++; }
                        else if (rerolled[i] == 6) { _six++; }
                    }

                    Console.WriteLine("\nYou rolled: " + _die1 + ", " + _die2 + ", " + _die3 + ", " + _die4 + ", " + _die5); //Prints rolled outcomes ot user

                    if (_one == 5 || _two == 5 || _three == 5 || _four == 5 || _five == 5 || _six == 5) //Or statements
                    {
                        Console.WriteLine("You got a 5 of a kind! + 12 points");
                        addScore(12); //Calls addscore to iterate which players go it is and add appropriate score
                        Console.ReadLine();
                    }

                    else if (_one == 4 || _two == 4 || _three == 4 || _four == 4 || _five == 4 || _six == 4)
                    {
                        Console.WriteLine("You got a 4 of a kind! + 6 points");
                        addScore(6);
                        Console.ReadLine();
                    }

                    else if (_one == 3 || _two == 3 || _three == 3 || _four == 3 || _five == 3 || _six == 3)
                    {
                        Console.WriteLine("You got a 3 of a kind! + 3 points");
                        addScore(3);
                        Console.ReadLine();
                    }

                    else { Console.WriteLine(""); }


                }
                else { Console.WriteLine(""); } //Ends without calling addScore() so turn is not changed to other player.
            }

            else { addScore(0); Console.ReadLine(); } //Calls addscore with 0 to add 0 points to score but change player's turn.
            

            _one = _two = _three = _four = _five = _six = 0; //Resets counter variables back to 0
        }

    }
}