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
            Console.WriteLine("Character Name: " + playerName);

            Console.Clear();

            //print stage information
            Console.WriteLine("You hear seagulls around you and the sound of waves crashing on a shore.");
            Console.WriteLine("There's a muffled voice coming from somewhere but you're not sure where.");
            Console.WriteLine("The voice comes closer, you try to open your eyes but the light is blinding.");
            Console.WriteLine("Before you have time to adjust to it, it vanishes and the muffles have become shouts as something grabs ahold and beings shaking you.");

            //present choices to player
            Console.WriteLine("A. Attack");
            Console.WriteLine("B. Wake up");
            Console.WriteLine("C. Go back to sleep");

            
        }

    }
}
