using System.Globalization;

namespace Monsterkampf
{
    internal class Program
    {
        #region Special Variables
        static public int speed = 1; // Speed factor for text animation
        static public bool validInput;
        #endregion

        static public Monster player1; // Monster instance for player 1
        static public Monster player2; // Monster instance for player 2
        static public Monster tempMonster; // Temporary Monster instance for swapping player1 and player2

        static public float tempHP;
        static public float tempAP;
        static public float tempDP;
        static public float tempS;

        static public bool fightRunning = true; 

        static public float curDamage; // Current damage during a round

        static public int roundCounter = 0; 

        static public bool startNewFight; 

        /// <summary>
        /// Main method for the program
        /// </summary>
        static void Main(string[] args)
        {
            do
            {
                ChooseMonsters(); // Allow players to choose their monsters

                GameLoop(); // Run the game loop

                WinnerScreen(); // Display the winner of the fight

                NewFight(); // Ask if players want to start a new fight

            } while (startNewFight); // Repeat if players want to start a new fight
        }

        /// <summary>
        /// Method to allow players to choose their monsters.
        /// </summary>
        static public void ChooseMonsters()
        {
            // Loop twice to allow each player to choose a monster
            for (int i = 0; i < 2; i++)
            {
                validInput = false; 

                while (validInput == false)
                {
                    // Display message based on player number
                    if (i == 0)
                    {
                        TextAnimate("Please select your first monster\n");
                        TextAnimate("1=Ork, 2=Troll, 3=Goblin\n");
                    }
                    else
                    {
                        TextAnimate("Please select your second monster\n");
                        TextAnimate("1=Ork, 2=Troll, 3=Goblin\n");
                    }

                    // Read player input
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    // Handle player input
                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                if (i == 0)
                                {
                                    SetMonsterVariables(); // Set temporary monster variables
                                    player1 = new Monster(tempHP, tempAP, tempDP, tempS, "Ork"); // Create an Ork monster for the first player
                                }
                                else
                                {
                                    // Create an Ork monster for the second player
                                    if (player1.GetT() == "Ork")
                                    {
                                        // Prevent choosing the same monster twice
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than Ork", 1000); 
                                        break;
                                    }
                                    SetMonsterVariables(); 
                                    player2 = new Monster(tempHP, tempAP, tempDP, tempS, "Ork");

                                    // Swap players if the second player's monster is faster
                                    if (player1.GetS() < player2.GetS())
                                    {
                                        tempMonster = player1;
                                        player1 = player2;
                                        player2 = tempMonster;
                                    }
                                }
                                validInput = true; 
                                break;
                            }

                        case ConsoleKey.D2:     //Same as above but using a "troll"
                            {
                                if (i == 0)
                                {
                                    SetMonsterVariables(); 
                                    player1 = new Monster(tempHP, tempAP, tempDP, tempS, "Troll"); 
                                }
                                else
                                {
                                    if (player1.GetT() == "Troll")
                                    {
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than Troll", 1000); 
                                        break;
                                    }
                                    SetMonsterVariables(); 
                                    player2 = new Monster(tempHP, tempAP, tempDP, tempS, "Troll"); 

                                    if (player1.GetS() < player2.GetS())
                                    {
                                        tempMonster = player1;
                                        player1 = player2;
                                        player2 = tempMonster;
                                    }
                                }
                                validInput = true; 
                                break;
                            }

                        case ConsoleKey.D3:     //Same as above but using a "goblin"
                            {
                                if (i == 0)
                                {
                                    SetMonsterVariables();
                                    player1 = new Monster(tempHP, tempAP, tempDP, tempS, "Goblin");
                                }
                                else
                                {
                                    if (player1.GetT() == "Goblin")
                                    {
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than Goblin", 1000);
                                        break;
                                    }
                                    SetMonsterVariables();
                                    player2 = new Monster(tempHP, tempAP, tempDP, tempS, "Goblin");

                                    if (player1.GetS() < player2.GetS())
                                    {
                                        tempMonster = player1;
                                        player1 = player2;
                                        player2 = tempMonster;
                                    }
                                }
                                validInput = true;
                                break;
                            }
                        default:
                            {
                                TextAnimateTime("Invalid input, please try again", 1000); // Inform user of invalid input
                                validInput = false; // Set flag to false for invalid input
                                break;
                            }
                    }
                }
            }
            TextAnimateTime("Monsters saved", 1000);    // Inform user that monsters are saved
        }


        /// <summary>
        /// Method to set temporary variables for monster attributes
        /// </summary>
        static public void SetMonsterVariables()
        {
            SetMonsterHp();
            SetMonsterAp();
            SetMonsterDp();
            SetMonsterS();
        }

        /// <summary>
        /// Method to set temporary variable for monster health points
        /// </summary>
        static public void SetMonsterHp()
        {
            validInput = false;
            while (validInput == false)
            {
                Console.Clear();
                TextAnimate("Please set a value for the health points of your monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the health points of your monster", 1000);
                }
                else
                {
                    TextAnimateTime("Saved", 500);
                    validInput = true;
                    tempHP = valurInput;
                }
            }
        }

        /// <summary>
        /// Method to set temporary variable for monster attack points
        /// </summary>
        static public void SetMonsterAp()
        {
            validInput = false;
            while (validInput == false)
            {
                Console.Clear();
                TextAnimate("Please set a value for the attack points of your monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the attack points of your monster", 1000);
                }
                else
                {
                    TextAnimateTime("Saved", 500);
                    validInput = true;
                    tempAP = valurInput;
                }
            }
        }

        /// <summary>
        /// Method to set temporary variable for monster defense points
        /// </summary>
        static public void SetMonsterDp()
        {
            validInput = false;
            while (validInput == false)
            {
                Console.Clear();
                TextAnimate("Please set a value for the defense points of your monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the defense points of your monster", 1000);
                }
                else
                {
                    TextAnimateTime("Saved", 500);
                    validInput = true;
                    tempDP = valurInput;
                }
            }
        }

        /// <summary>
        /// Method to set temporary variable for monster speed
        /// </summary>
        static public void SetMonsterS()
        {
            validInput = false;
            while (validInput == false)
            {
                Console.Clear();
                TextAnimate("Please set a value for the speed of your monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the speed of your monster", 1000);
                }
                else
                {
                    TextAnimateTime("Saved", 500);
                    validInput = true;
                    tempS = valurInput;
                }
            }
        }

        /// <summary>
        /// Game loop which contains repeating PlayRound method
        /// </summary>
        static public void GameLoop()
        {
            Console.Clear();
            roundCounter = 0;
            TextAnimateTime("The " + player1.GetT() + " is starting the fight", 2000);
            while (fightRunning)
            {
                TextAnimateTime("Round " + roundCounter, 1000);
                PlayRound();
                roundCounter++;
            }
        }

        /// <summary>
        /// Method to play a single round of the fight
        /// </summary>
        static public void PlayRound()
        {
            // First monster attacks
            curDamage = player1.Attack(player2);
            Console.Write("Round " + roundCounter + "\n\n");
            TextAnimate("The " + player1.GetT() + " made " + curDamage + " damage to the " + player2.GetT() + "\n");
            player2.CalcNewHp(curDamage);
            TextAnimateTime("New HP of the " + player2.GetT() + " is " + player2.GetHP(), 3000);

            // Check if second monster died
            if (player2.IsDead())
            {
                Console.Write("Round " + roundCounter + "\n\n");
                TextAnimateTime("The " + player2.GetT() + " is dead", 2000);
                player1.SetIsWinner(true);
                fightRunning = false;
                return;
            }

            // Second monster attacks
            curDamage = player2.Attack(player1);
            Console.Write("Round " + roundCounter + "\n\n");
            TextAnimate("The " + player2.GetT() + " made " + curDamage + " damage to the " + player1.GetT() + "\n");
            player1.CalcNewHp(curDamage);
            TextAnimateTime("New HP of the " + player1.GetT() + " is " + player1.GetHP(), 3000);

            // Check if first monster died
            if (player1.IsDead())
            {
                Console.Write("Round " + roundCounter + "\n\n");
                TextAnimateTime("The " + player1.GetT() + " is dead", 2000);
                player2.SetIsWinner(true);
                fightRunning = false;
                return;
            }
        }

        /// <summary>
        /// Method to display the winner of the fight
        /// </summary>
        static public void WinnerScreen()
        {
            if (player1.GetIsWinner())
            {
                TextAnimateTime("The " + player1.GetT() + " won after " + roundCounter + " rounds", 2000);
            }

            if (player2.GetIsWinner())
            {
                TextAnimateTime("The " + player2.GetT() + " won after " + roundCounter + " rounds", 2000);
            }
        }

        /// <summary>
        /// Method to ask if players want to start a new fight
        /// </summary>
        static public void NewFight()
        {
            validInput = false;
            while (validInput == false)
            {
                TextAnimate("Start a new fight?\n");
                TextAnimate("[Y]es, [N]o\n");
                ConsoleKeyInfo input2 = Console.ReadKey(true);
                switch (input2.Key)
                {
                    case ConsoleKey.Y:
                        {
                            Console.Clear();
                            TextAnimateTime("Alright, let's go", 500);
                            startNewFight = true;
                            fightRunning = true;
                            player1 = null;
                            player2 = null;
                            validInput = true;
                            Console.Clear();
                            break;
                        }

                    case ConsoleKey.N:
                        {
                            Console.Clear();
                            TextAnimateTime("Ok", 1000);
                            startNewFight = false;
                            validInput = true;
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            TextAnimateTime("Please answer with [Y]es or [N]o", 1000);
                            validInput = false;
                            break;
                        }
                }
            }
        }

        #region Special Methods
        /// <summary>
        /// Prints a string letter by letter with a small delay
        /// </summary>
        /// <param name="_input">String to print</param>
        public static void TextAnimate(string _input)
        {
            if (_input != null || _input != "")
            {

                char[] letters = _input.ToCharArray();
                string output = "";

                for (int i = 0; i < letters.Length; i++)
                {
                    Console.Write(letters[i]);
                    Thread.Sleep(20);
                }
            }

        }

        /// <summary>
        /// Similar to TextAnimate but clears console after a given time
        /// </summary>
        /// <param name="_input">String to print</param>
        /// <param name="_time">Time after console clear in ms</param>
        public static void TextAnimateTime(string _input, int _time)
        {
            TextAnimate(_input);
            Thread.Sleep(_time);
            Console.Clear();
        }
        #endregion
    }
}