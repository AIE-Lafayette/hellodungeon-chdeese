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

            //player stats
            int strength = 0;

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

            //choice mechanics
            string playerChoice = Console.ReadLine();
            bool combatInitiated = false;
            if(playerChoice == "A")
            {
                //fight
                Console.WriteLine("You throw a jab straight ahead with full force into the figure's center.");
                Console.WriteLine("The figure stumbles back and you're able to hop on your feet.");
                Console.WriteLine("STRENGTH UP!!");
                strength++;
                combatInitiated = true;
            }
            else 
            {
                if(playerChoice == "B")
                {
                    //dodge
                    Console.WriteLine("You open your eyes and there's a figure rearing for a punch.");
                    Console.WriteLine("You move your head out of the way just in time and you roll out from under him.");
                    combatInitiated = true;
                }
                else if(playerChoice == "C")
                 {
                    //next stage B
                    Console.WriteLine("There's a whoosh of air and you lose consciousness again.");
                 }

                //Option to Continue
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
            }
            
        }

    }
}
