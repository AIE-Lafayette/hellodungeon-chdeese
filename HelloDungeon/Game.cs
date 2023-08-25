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

            Console.WriteLine("Enter Name:");
            string playerName = Console.ReadLine();

            Console.Clear();

            //print name for feedback
            Console.WriteLine("Character Name " + playerName);

            
        }

    }
}
