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
            string playerName = "";
            int playerHealth = 15;
            bool isAlive = true;

            //player stats
            int strength = 0;
            int strengthDamage = 2;
            int basePlayerDamage = 2;

            //get first and last name

            Console.Write("Enter Name:");
            playerName = Console.ReadLine();

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
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Wake up");
            Console.WriteLine("3. Go back to sleep");

            //choice mechanics
            string playerChoice = Console.ReadLine();
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
                if (combatInitiated)
                {
                    int enemyHealth = 20;
                    int enemyDamage = 2;
                    bool enemyStunned = false;
                    while (combatInitiated)
                    {
                        Console.WriteLine("Your Health: " + playerHealth + "       Enemy Health: " + enemyHealth);
                        if (playerHealth <= 0 || enemyHealth <= 0)
                        {
                            //end loop
                            combatInitiated = false;
                            if (enemyHealth <= 0)
                            {
                                //victory
                                Console.WriteLine("YOU WIN");
                                combatInitiated = false;
                            }
                            else
                            {
                                //defeat
                                Console.WriteLine("YOU DIED");
                                combatInitiated = false;
                                isAlive = false;
                            }
                            
                        }
                        else
                        {
                            //battle

                            //enemy move
                            string enemyChoice;
                            if (enemyStunned)
                            {
                                //enemy is stunned for a round
                                Console.WriteLine("The enemy is still getting back up!");
                                Console.WriteLine("----------------------------");
                                enemyChoice = "0";
                            }
                            else if (playerHealth >= 10 && enemyHealth >= 15)
                            {
                                //enemy prepares strong attack
                                enemyChoice = "1";
                                Console.WriteLine("The enemy turns his body and takes a step back, rearing to attack.");
                                Console.WriteLine("----------------------------");
                            }
                            else if (playerHealth > 4 && enemyHealth >= 8)
                            {
                                //enemy prepares quick attack
                                enemyChoice = "2";
                                Console.WriteLine("The enemy pulls back his arm and gets ready to swing!");
                                Console.WriteLine("----------------------------");
                            }
                            else if (enemyHealth < 8 && playerHealth > enemyHealth)
                            {
                                //enemy prepares dodge
                                enemyChoice = "3";
                                Console.WriteLine("The enemy looks like he's on gaurd.");
                                Console.WriteLine("----------------------------");
                            }
                            else
                            {
                                //enemy prepares block
                                enemyChoice = "4";
                                Console.WriteLine("The enemy slightly raises his shield.");
                                Console.WriteLine("----------------------------");
                            }
                            enemyStunned = false;

                            //present options to player
                            Console.WriteLine("What will you do?");
                            Console.WriteLine("1. Strong attack");
                            Console.WriteLine("2. Quick attack");
                            Console.WriteLine("3. Dodge");
                            Console.WriteLine("4. Block");

                            playerChoice = Console.ReadLine();

                            //get valid input for player choice with a while loop
                            while(playerChoice != "1" && playerChoice != "2" && playerChoice != "3" && playerChoice != "4")
                            {
                                Console.WriteLine("Enter 1, 2, 3, or 4.");
                                playerChoice = Console.ReadLine();
                            }
                            

                            //process damage stat
                            strengthDamage = strength * strengthDamage;
                            int playerDamage = basePlayerDamage + strengthDamage;


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
                                else
                                {
                                    //strong attack success
                                    Console.WriteLine("You hit the enemy for " + (playerDamage + 2) + " damage!");
                                    enemyHealth -= playerDamage + 2;
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
                                else
                                {
                                    //you quick attack enemy
                                    enemyHealth -= playerDamage;
                                    Console.WriteLine("you hit the enemy before he could do anything! You hit for " + playerDamage + " damage!");
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
                                if(enemyChoice == "1")
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
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey(true);
                        Console.Clear();
                    }

                        //continue story
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    
                }

            
            
        }

    }
}
