using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        //displays the player's stats
        void displayStats(string name, int playerHealth, int strength)
        {
            //display stat sheet to player
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        //combat function
        void initiateCombat(string username, bool combat, int playerHealth, int baseDamage, bool playerAlive, int playerStrength)
        {
                int enemyHealth = 25;
                int enemyDamage = 2;
                bool enemyStunned = false;
                string playerChoice = "0";
                int strengthDamage = 2;
                while (combat)
                {

                    if (playerHealth <= 0 || enemyHealth <= 0)
                    {
                        //end loop
                        combat = false;
                        if (enemyHealth <= 0)
                        {
                            //victory
                            Console.WriteLine("YOU WIN");
                            combat = false;
                        }
                        else
                        {
                            //defeat
                            Console.WriteLine("YOU DIED");
                            combat = false;
                            playerAlive = false;
                        }

                    }
                    else
                    {
                        //display player and enemy health
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("Your Health: " + playerHealth + "       Enemy Health: " + enemyHealth);
                        Console.WriteLine("---------------       ----------------");

                        displayStats(username, playerHealth, playerStrength);


                        //battle

                        //enemy move
                        string enemyChoice;
                        if (enemyStunned)
                        {
                            //enemy is stunned for a round
                            Console.WriteLine("The enemy is still getting back up!");
                            Console.WriteLine("----------------------------------------------------------------------");
                            enemyChoice = "0";
                        }
                        else if ((playerHealth < enemyHealth) && (enemyHealth != 14) && (enemyHealth != 15) && (enemyHealth != 13))
                        {
                            //enemy prepares strong attack
                            enemyChoice = "1";
                            Console.WriteLine("The enemy turns his body and takes a step back, rearing to attack.");
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                        else if (playerHealth > 6 && enemyHealth >= 10)
                        {
                            //enemy prepares quick attack
                            enemyChoice = "2";
                            Console.WriteLine("The enemy pulls back his arm and gets ready to swing!");
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                        else if (enemyHealth < 8 && playerHealth > enemyHealth)
                        {
                            //enemy prepares dodge
                            enemyChoice = "3";
                            Console.WriteLine("The enemy looks like he's on gaurd.");
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                        else
                        {
                            //enemy prepares block
                            enemyChoice = "4";
                            Console.WriteLine("The enemy slightly raises his shield.");
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                        enemyStunned = false;


                        // call menu function to get player input for the battle
                        playerChoice = DisplayMenu("What will you do?", "Strong attack", "Quick attack", "Dodge", "Block", "0");
                        Console.WriteLine("----------------------------------------------------------------------");

                        //process damage stat
                        strengthDamage = playerStrength * strengthDamage;

                        strengthDamage = playerStrength * strengthDamage;
                        int playerDamage = baseDamage + strengthDamage;


                        //player choice
                        if (playerChoice == "1")
                        {
                            if (enemyChoice == "3")
                            {
                                //enemy dodge
                                Console.WriteLine("He dodged out of the way!");

                            }
                            else if (enemyChoice == "1")
                            {
                                //player and enemy have successful heavy attacks
                                Console.WriteLine("You trade heavy blows.");
                                enemyHealth -= playerDamage + 2;
                                playerHealth -= enemyDamage + 2;
                            }
                            else if (enemyChoice == "2")
                            {
                                //enemy interupts player
                                Console.WriteLine("The enemy's attack was too fast, he hit you before you could do anything!");
                                playerHealth -= enemyDamage;
                            }
                            else if (enemyChoice == "4")
                            {
                                //strong attack success
                                Console.WriteLine("You went through his block and did " + (playerDamage) + " damage!");
                                enemyHealth -= playerDamage + 2;
                            }
                            else
                            {
                                //strong attack while enemy is stunned success -- Critical Hit!
                                Console.WriteLine("You hit him while he was down! Critical hit!!");
                                enemyHealth -= playerDamage + 4;
                            }

                        }
                        else if (playerChoice == "2")
                        {
                            if (enemyChoice == "2")
                            {
                                //enemy attacks you first with the same attack
                                Console.WriteLine("He hit you first!");
                                playerHealth -= enemyDamage;
                            }
                            else if (enemyChoice == "4")
                            {
                                //enemy blocks your attack
                                Console.WriteLine("Your attack was blocked!");
                            }
                            else
                            {
                                //you quick attack enemy
                                enemyHealth -= playerDamage;
                                Console.WriteLine("You hit the enemy before he could do anything! You hit for " + playerDamage + " damage!");
                            }
                        }
                        else if (playerChoice == "3")
                        {
                            if (enemyChoice == "1")
                            {
                                //dodge stun
                                enemyStunned = true;
                                Console.WriteLine("You dodge and he falls on the ground! He's stunned!");
                            }
                            else
                            {
                                //evasion
                                Console.WriteLine("You dodged out the way!");
                            }

                        }
                        else
                        {
                            if (enemyChoice == "1")
                            {
                                //player takes heavy damage
                                Console.WriteLine("OWW the attack went through and you took " + (enemyDamage + 2) + " damage!!");
                            }
                            else if (enemyChoice == "2")
                            {
                                //successful block
                                Console.WriteLine("The enemy attacks but you raise your shield and block it!!");
                            }
                            else
                            {
                                //null block
                                Console.WriteLine("You raise your shield but nothing happened.");
                            }

                        }
                        //continue battle
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey(true);
                        Console.Clear();
                    }


                }

            
        }

        //asked the user if they would like to restart the game and does or ends the game accordingly
        bool restartMenu()
        {
            string userInput = "";
            while ((userInput != "1") && (userInput != "2"))
            {
                Console.WriteLine("To be continuted...    Would you like to restart?");
                Console.WriteLine("1. Yes     2. No");

                userInput = Console.ReadLine();

                //check input and end or restart game

                if (userInput == "1")
                {
                    //restart game
                    continue;
                }
                else if (userInput == "2")
                {
                    //returns value for gameover to exit restart loop
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Input, enter 1 for Yes, or enter 2 for No.");
                }
            }
            Console.Clear();
            return false;
        }

        //gets player's name (for now)
        string getPlayerInfo()
        {
            //get player name

            Console.Write("Enter Name:");
            string playerName = Console.ReadLine();

            Console.Clear();

            //print name for player feedback
            Console.WriteLine("Character Name: " + playerName);

            Console.Clear();
            return playerName; 
        }

        //Display menu options 4 & 5 must have 0 inside the string to not print them when calling.
        string DisplayMenu(string prompt, string optionA, string optionB, string optionC, string optionD, string optionE)
        {
            string playerChoice = "";
            while (playerChoice != "1" || playerChoice != "2" || playerChoice != "3" || playerChoice != "4" || playerChoice != "5")
            {
                Console.WriteLine(prompt);
                Console.WriteLine("1. " + optionA);
                Console.WriteLine("2. " + optionB);
                Console.WriteLine("3. " + optionC);
                if (optionD != "0")
                {
                    Console.WriteLine("4. " + optionD);
                    if (optionE != "0")
                    {
                        Console.WriteLine("5. " + optionE);
                    }
                }
                Console.Write("> ");

                playerChoice = Console.ReadLine();

                if (playerChoice == "1" || playerChoice == "2" || playerChoice == "3" || ((playerChoice == "4") && (optionD != "0")) || ((playerChoice == "5") && (optionE != "0")))
                {
                    return playerChoice;
                }
                else
                {
                    Console.WriteLine("Invalid Input, press any key to try again");
                    Console.ReadKey(true);
                }
                Console.Clear();

            }
            return "";

        }

        //main function
        public void Run()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                //create and initialize variables
                string playerName = "";
                int playerHealth = 10;
                bool isAlive = true;

                //player stats
                int strength = 0;
                int strengthDamage = 2;
                int basePlayerDamage = 2;

                //call the getPlayerInfo function to get players information (name for now)
                playerName = getPlayerInfo();

                //display prompt/options and recieve input from the player by calling the function DisplayMenu
                string playerChoice = DisplayMenu("Your name is: " + playerName + "\nYou hear seagulls around you and the sound of waves crashing on a shore. " +
                    "\nThere's a muffled voice coming from somewhere but you're not sure where. " +
                    "\nThe voice comes closer, you try to open your eyes but the light is blinding. " +
                    "\nBefore you have time to adjust to it, it vanishes and the muffles have become " +
                    "\nshouts as something grabs ahold and begins to shake you.",
                    "Attack", "Wake Up", "Go back to sleep", "0", "0");
                bool combatInitiated = false;
                bool getInput = true;
                while (getInput)
                {


                    if (playerChoice == "1")
                    {
                        //fight
                        Console.WriteLine("You throw a jab straight ahead with full force into the figure's center.");
                        Console.WriteLine("The figure stumbles back and you're able to hop on your feet.");
                        Console.WriteLine("STRENGTH UP!!");
                        strength++;
                        combatInitiated = true;
                        getInput = false;
                    }
                    else
                    {
                        if (playerChoice == "2")
                        {
                            //dodge
                            Console.WriteLine("You open your eyes and there's a figure rearing for a punch.");
                            Console.WriteLine("You move your head out of the way just in time and you roll out from under him.");
                            combatInitiated = true;
                            getInput = false;
                        }
                        else if (playerChoice == "3")
                        {
                            //next stage B
                            Console.WriteLine("There's a whoosh of air and you lose consciousness again.");
                            getInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, try again.");
                        }
                    }
                }

                //Option to Continue
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();

                //combat loop

                initiateCombat(playerName, combatInitiated, playerHealth, basePlayerDamage, isAlive, strength);

                //present the user an option to restart or end the game
                gameOver = restartMenu();
                Console.Clear();
            }



        }


    }

}
