using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        //Properties
        private int _threeOrMoreScore1;
        private int _threeOrMoreScore2;

        //Constructor method
        public Testing()
        {
            sevensOut so = new sevensOut(); //Creates new sevensOut object
            Debug.Assert(so.total == 7, "Game should stop now");


            threeOrMore tom = new threeOrMore(); //Creates new three or more object
            _threeOrMoreScore1 = tom._P1score; //Ensures P1 is not over 20
            Debug.Assert(_threeOrMoreScore1 >= 20);
            _threeOrMoreScore2 = tom._P2score; //Ensures P2 is not over 20
            Debug.Assert(_threeOrMoreScore2 >= 20);
        }
        
        
    }

    internal class statistics
    {
        //Properties
        private static int sevensOutBegun; //Static variables mean class does not have to be instantiated to use
        private static int sevensOutComplete;

        private static int threeOrMoreBegun;
        private static int threeOrMoreComplete;

        //No consturcor method required

        public static void sevensOutBegin() { sevensOutBegun++; } //Upon being called, the appropriate variable is incrimented
        public static void sevensOutCompleted() { sevensOutComplete++; }

        public static void threeOrMoreBegin() { threeOrMoreBegun++; }
        public static void threeOrMoreCompleted() { threeOrMoreComplete++; }

        public void displayStats() //Displays statistics that have been accumulated
        {
            Console.WriteLine("\n\nGame statistics:\nNumber of times Sevens Out has been started: " + sevensOutBegun + "\nNumber of times Sevens Out has been completed: " + sevensOutComplete);
            Console.WriteLine("Number of times Three or More has been started: " + threeOrMoreBegun + "\nNumber of times Three or More has been completed: " + threeOrMoreComplete);
        }
    }
}
