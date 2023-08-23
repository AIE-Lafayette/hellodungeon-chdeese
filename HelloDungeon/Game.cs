using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        public void Run()
        {

            //create and initialize variables
            string playerName;
            int playerHealth = 100;
            bool isAlive = true;
            float storyProgress = 3.3f;
            int stage;

            //get first and last name

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.Clear();

            //combine and print
            playerName = firstName + " " + lastName;
            Console.WriteLine("Welcome " + playerName);
        }

    }
}
