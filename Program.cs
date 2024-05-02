using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args) //Main program body
        {
            while (menu()) //While loop keeps menu repeating
                {
                Console.WriteLine("");
                }
            Console.WriteLine("Closing program...");
        }



        public static bool menu()
        {
            Console.WriteLine("---------------------------\n1) Play Sevens Out\n2) Play Three or More\n3) View statistics\n4) Test\n5) Exit\n---------------------------\n\nSelect an option:");
            string choice = Console.ReadLine();

            if (choice == ("5"))
            {
                return false;
            }
            else if (choice == ("1"))
            {
                sevensOut game = new sevensOut(); 
                return true;
            }
            else if (choice == ("2"))
            {
                threeOrMore game = new threeOrMore();
                return true;
            }
            else if (choice == ("3"))
            {
                statistics stats = new statistics();
                stats.displayStats();
                return true;
            }
            else if (choice == ("4"))
            {
                Testing test = new Testing();
                return true;
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 5.\n\n");
                return true;
            }
        }  
        
    }
}
