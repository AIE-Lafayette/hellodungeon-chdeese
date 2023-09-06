using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        //create and initialize variables
        string playerName = "";
        string playerChoice = "";
        bool isAlive = true;
        bool combatInitiated = false;
        bool getInput = true;

        //player stats
        int playerHealth = 10;
        int strength = 0;
        int strengthDamage = 2;
        int basePlayerDamage = 2;
        string enemyChoiceDialog = "";
        int enemyHealth;
        bool stunned = false;

        //function to determine the enemy's next move
        string enemyMove()
        {
            string eChoice;
            if (stunned)
            {
                //enemy is stunned for a round
                enemyChoiceDialog = "The enemy is still getting back up!";
                eChoice = "0";
                stunned = false;
            }
            else if ((playerHealth < enemyHealth) && (enemyHealth != 14) && (enemyHealth != 15) && (enemyHealth != 13))
            {
                //enemy prepares strong attack
                eChoice = "1";
                enemyChoiceDialog = "The enemy turns his body and takes a step back, rearing to attack.";
            }
            else if (playerHealth > 6 && enemyHealth >= 10)
            {
                //enemy prepares quick attack
                eChoice = "2";
                enemyChoiceDialog = "The enemy pulls back his arm and gets ready to swing!";
            }
            else if (enemyHealth < 8 && playerHealth > enemyHealth)
            {
                //enemy prepares dodge
                eChoice = "3";
                enemyChoiceDialog = "The enemy looks like he's on gaurd.";
            }
            else
            {
                //enemy prepares block
                eChoice = "4";
                enemyChoiceDialog = "The enemy slightly raises his shield.";
            }
            stunned = false;
            return eChoice;
        }

        //displays the player's stats
        void displayStats(string name, int playerHealth, int strength)
        {
            //display stat sheet to player
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        //combat function
        void initiateCombat(int baseDamage, bool playerAlive)
        {
                enemyHealth = 25;
                int enemyDamage = 2;
                stunned = false;
                playerChoice = "0";
                int strengthDamage = 2;
               
                while (combatInitiated)
                {

                    if (playerHealth <= 0 || enemyHealth <= 0)
                    {
                        //end loop
                        combatInitiated = false;
                        if (enemyHealth <= 0)
                        {
                            //victory
                            Console.WriteLine("YOU WIN");
                            combatInitiated = false;
                            continue;
                        }
                        else
                        {
                            //defeat
                            Console.WriteLine("YOU DIED");
                            combatInitiated = false;
                            playerAlive = false;
                            continue;
                        }

                    }
                    else
                    {
                        

                        //battle

                        //enemy move
                        string enemyChoice = enemyMove();




                    // call menu function to get player input for the battle
                    playerChoice = DisplayMenu("What will you do?", "Strong attack", "Quick attack", "Dodge", "Block", "0");
                        Console.WriteLine("----------------------------------------------------------------------");

                        //process damage stat
                        strengthDamage = strength * strengthDamage;

                        strengthDamage = strength * strengthDamage;
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
                                stunned = true;
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
                Console.WriteLine("Would you like to restart?");
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
                if (combatInitiated == true)
                {
                    //display player and enemy health
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine("Your Health: " + playerHealth + "       Enemy Health: " + enemyHealth);
                    Console.WriteLine("---------------       ----------------");
                
                 displayStats(playerName, playerHealth, strength);
                    

                 if (enemyChoiceDialog != "")
                 {
                    Console.WriteLine(enemyChoiceDialog);
                    Console.WriteLine("----------------------------------------------------------------------");
                 }
                }
                Console.WriteLine(prompt);
                Console.WriteLine("1. " + optionA);
                Console.WriteLine("2. " + optionB);
                if (optionC != "0")
                {
                    Console.WriteLine("3. " + optionC);
                    if (optionD != "0")
                    {
                        Console.WriteLine("4. " + optionD);
                        if (optionE != "0")
                        {
                            Console.WriteLine("5. " + optionE);
                        }
                    }
                }
                Console.Write("> ");

                playerChoice = Console.ReadLine();

                if (playerChoice == "1" || playerChoice == "2" || ((playerChoice == "3") && (optionC != "0")) || ((playerChoice == "4") && (optionD != "0")) || ((playerChoice == "5") && (optionE != "0")))
                {
                    return playerChoice;
                    Console.Clear();
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

        void PressToContinue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
            Console.Clear();
        }
        void Stage1()
        {
            //call the getPlayerInfo function to get players information (name for now)
            playerName = getPlayerInfo();

            //display prompt/options and recieve input from the player by calling the function DisplayMenu
            playerChoice = DisplayMenu("You hear seagulls around you and the sound of waves crashing on a shore. " +
                "\nThere's a muffled voice coming from somewhere but you're not sure where. " +
                "\nThe voice comes closer, you try to open your eyes but the light is blinding. " +
                "\nBefore you have time to adjust to it, it vanishes and the muffles have become " +
                "\nshouts as something grabs ahold and begins to shake you.",
                "Attack", "Wake Up", "Go back to sleep", "0", "0");

            while (getInput)
            {


                if (playerChoice == "1")
                {
                    //fight
                    Console.WriteLine("You throw a jab straight ahead with full force into the figure's center.");
                    Console.WriteLine("The figure stumbles back and you're able to hop on your feet.");
                    Console.WriteLine("STRENGTH UP!!");
                    PressToContinue();
                    strength++;
                    combatInitiated = true;
                    getInput = false;
                    initiateCombat(basePlayerDamage, isAlive);
                }
                else
                {
                    if (playerChoice == "2")
                    {
                        //dodge
                        Console.WriteLine("You open your eyes and there's a figure rearing for a punch.");
                        Console.WriteLine("You move your head out of the way just in time and you roll out from under him.");
                        PressToContinue();
                        combatInitiated = true;
                        getInput = false;
                        initiateCombat(basePlayerDamage, isAlive);
                    }
                    else if (playerChoice == "3")
                    {
                        //next stage B
                        Console.WriteLine("There's a whoosh of air and you lose consciousness again.");
                        PressToContinue();
                        getInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, try again.");
                    }
                }
            }

        }

        void Stage2()
        {
            //battle 2
            strength += 2;
            playerHealth = 30;
            enemyHealth = 70;
        }

        //main function
        public void Run()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                int stage = 1;
                if (stage == 1)
                {
                    Stage1();
                    stage++;
                    playerChoice = DisplayMenu("Do you want to continue?", "Yes", "No", "0", "0", "0");
                    if (playerChoice == "2")
                    {
                        gameOver = restartMenu();
                        continue;
                    }
                    else (playerChoice == "1")
                    {
                        continue;
                    }
                    
                }
                else if (stage == 2)
                {
                    Stage2();
                    stage++;
                    Console.WriteLine("The End.");
                    gameOver = restartMenu();
                    Console.Clear();
                }
            }



        }


    }

}
