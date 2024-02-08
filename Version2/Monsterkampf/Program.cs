using System.Globalization;

namespace Monsterkampf
{
    internal class Program
    {
        #region Special Variables
        static public int speed = 1;    // Speed factor for text animation
        static public bool validInput; 
        #endregion

        static public Monster player1;  // Monster instance for player 1
        static public Monster player2;  // Monster instance for player 2
        static public Monster tempMonster;  // Temporary Monster instance for swapping player1 and player2

        static public float tempHP;  
        static public float tempAP;  
        static public float tempDP;  
        static public float tempS;   

        static public bool fightRunning = true;  

        static public int doAttackNumber = 0;   // The attack number chosen by the player

        static public bool attackDone = true;    // Flag to track if the attack is done and successful

        static public float curDamage;  // Current damage during a round

        static public int roundCounter = 0; 

        static public bool startNewFight;    



        /// <summary>
        /// Main method for the program
        /// </summary>
        static void Main(string[] args)
        {
            #region Debugging Settings
            speed = 1;
            #endregion

            WantTutorial();
            do
            {
                ChooseMonsters();   // Allow players to choose their monsters

                GameLoop(); // Run the game loop

                WinnerScreen(); // Display the winner of the fight

                NewFight(); // Ask if players want to start a new fight

            } while (startNewFight);    // Repeat if players want to start a new fight
        }

        /// <summary>
        /// Asks the user if they want a tutorial and provides one if requested
        /// </summary>
        static public void WantTutorial()
        {
            validInput = false;

            // Loop until valid input is received
            while (validInput == false)
            {
                // Display tutorial prompt
                TextAnimate("Do you want a tutorial?\n");
                TextAnimate("[Y]es, [N]o\n");

                // Read key input
                ConsoleKeyInfo input2 = Console.ReadKey(true);

                // Process the input
                switch (input2.Key)
                {
                    case ConsoleKey.Y:
                        {
                            // Clear the console and start the tutorial
                            Console.Clear();
                            TextAnimateTime("Alright let's start with a tutorial", 500);
                            Tutorial();
                            validInput = true;
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.N:
                        {
                            // Clear the console and proceed without tutorial
                            Console.Clear();
                            TextAnimateTime("Ok let's start with a fight", 1000);
                            validInput = true;
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            // Clear the console and display an error message for invalid input
                            Console.Clear();
                            TextAnimateTime("Please answer with [Y]es or [N]o", 1000);
                            validInput = false;
                            break;
                        }
                }
            }
        }


        /// <summary>
        /// Prints tutorial text
        /// </summary>
        static public void Tutorial()
        {
            TextAnimate("First you gonna choose 2 out of 3 possible monsters types (Ork, Troll, Goblin)\n\n");
            TextAnimate("After choosing a monster their default settings are shown\n");
            TextAnimate("You can use the default monster settings or customize them\n\n");
            TextAnimate("Each monster type has a basic attack and 2 special attacks or abilities\n");
            TextAnimate("The basic attack deals a damage calculated by subtracting the attack point of the attacking monster by the defense poinst of the enemy\n");
            TextAnimate("The following list show the special attacks of each monster type as well as a short description of the monster type\n\n\n\n");
            TextAnimate("ORK: At default a very basic monster type\n\nAttacks/Abilities:\n  -Attack Transferation ~~ Transfer a defense to an attack point\n  -Defense Transferation ~~ Transfer an attack to a defense point\n\n\n\n\n");
            TextAnimate("TROLL: At default a rather slow but tanky monster type\n\nAttacks/ Abilities:\n  -Heavy Attack ~~ Get a bit damage because breaking through the defense of the enemy but also deal your full attack points as damage\n  -Petrification ~~ Generate a defense point by adding stoneplates to the body of the troll\n\n\n\n\n");
            TextAnimate("GOBLIN: At default a pretty fast but squishy monster type\n\nAttacks/ Abilities:\n  -Fast Attack  ~~ Dealing more damage because of the extremely fast movement\n  -Assasin Attack ~~ Steal a fifth of the enemy health and regenerate the stolen health point\n\n\n\n\n");
            TextAnimate("Now you know everything relevant to start your first fight :)\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            TextAnimate("press enter to start fight");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Allows the players to choose their monsters for the fight
        /// </summary>
        static public void ChooseMonsters()
        {
            // Loop for each player to choose their monster
            for (int i = 0; i < 2; i++)
            {
                validInput = false;

                // Loop until valid input is received
                while (validInput == false)
                {
                    // Display prompts based on player index
                    if (i == 0)
                    {
                        TextAnimate("Please select your first Monsters\n");
                        TextAnimate("1 = Ork, 2 = Troll, 3 = Goblin\n");
                    }
                    else
                    {
                        TextAnimate("Please select your second Monsters\n");
                        TextAnimate("1 = Ork, 2 = Troll, 3 = Goblin\n");
                    }

                    // Read key input
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    Console.Clear();

                    // Process the input and create the respective monster
                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                if (i == 0)
                                {
                                    // Create an Ork monster for the first player
                                    player1 = new Ork();
                                    SetMonsterVariables(i);
                                }
                                else
                                {
                                    // Create an Ork monster for the second player
                                    if (player1.GetT() == "Ork")
                                    {
                                        // Prevent choosing the same monster twice
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than ork", 1000);
                                        break;
                                    }
                                    player2 = new Ork();
                                    SetMonsterVariables(i);

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
                                    player1 = new Troll();
                                    SetMonsterVariables(i);
                                }
                                else
                                {
                                    if (player1.GetT() == "Troll")
                                    {
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than troll", 1000);
                                        break;
                                    }
                                    player2 = new Troll();
                                    SetMonsterVariables(i);

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
                                    player1 = new Goblin();
                                    SetMonsterVariables(i);
                                }
                                else
                                {
                                    if (player1.GetT() == "Goblin")
                                    {
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than goblin", 1000);
                                        break;
                                    }
                                    player2 = new Goblin();
                                    SetMonsterVariables(i);

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
                                // Display an error message for invalid input
                                TextAnimateTime("Invalid input please try again", 1000);
                                validInput = false;
                                break;
                            }
                    }
                }
            }
            TextAnimateTime("Monsters saved", 1000);    // Notify that monsters have been saved
        }


        #region Monster Settings
        /// <summary>
        /// Sets the variables for the specified monster (player) based on user input
        /// </summary>
        /// <param name="monsterCount">The index of the monster being set (0 for the first monster, 1 for the second)</param>
        static public void SetMonsterVariables(int monsterCount)
        {
            Console.Clear();
            validInput = false;

            // Loop until valid input is received
            while (validInput == false)
            {
                // Display the current monster's details
                if (monsterCount == 0)
                    TextAnimate(player1.GetAll());
                if (monsterCount == 1)
                    TextAnimate(player2.GetAll());

                // Prompt the user to choose whether to use default monster settings
                TextAnimate("Play with default monster settings?\n");
                TextAnimate("[Y]es, [N]o\n");

                ConsoleKeyInfo input2 = Console.ReadKey(true);

                // Process the input and set monster variables accordingly
                switch (input2.Key)
                {
                    case ConsoleKey.Y:
                        {
                            // Use default settings
                            Console.Clear();
                            TextAnimateTime("Ok defaults will be used", 1000);
                            validInput = true;
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.N:
                        {
                            // Set up custom monster settings
                            Console.Clear();
                            TextAnimateTime("Alright let's set up the monster", 500);

                            // Prompt user to set health, attack, defense, and speed
                            SetMonsterHp();
                            SetMonsterAp();
                            SetMonsterDp();
                            SetMonsterS();

                            // Apply custom settings to the appropriate monster
                            if (monsterCount == 0)
                                player1.SetAll(tempHP, tempAP, tempDP, tempS);
                            if (monsterCount == 1)
                                player2.SetAll(tempHP, tempAP, tempDP, tempS);

                            validInput = true;
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            // Display an error message for invalid input
                            Console.Clear();
                            TextAnimateTime("Please answer with [Y]es or [N]o", 1000);
                            validInput = false;
                            break;
                        }
                }
            }
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
                TextAnimate("Please set a value for the healthpoints of your Monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the healthpoints of your Monster", 1000);

                }
                else
                {
                    TextAnimateTime("saved", 500);
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
                TextAnimate("Please set a value for the attackpoints of your Monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the attackpoints of your Monster", 1000);

                }
                else
                {
                    TextAnimateTime("saved", 500);
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
                TextAnimate("Please set a value for the defensepoints of your Monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the defensepoints of your Monster", 1000);

                }
                else
                {
                    TextAnimateTime("saved", 500);
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
                TextAnimate("Please set a value for the speed of your Monster\n");
                string rawinput = Console.ReadLine().Trim();

                if (!float.TryParse(rawinput, out float valurInput))
                {
                    TextAnimateTime("Please set a valid value for the speed of your Monster", 1000);

                }
                else
                {
                    TextAnimateTime("saved", 500);
                    validInput = true;
                    tempS = valurInput;
                }


            }
        }
        #endregion

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
        /// Plays a single round of the fight between the two monsters.
        /// </summary>
        static public void PlayRound()
        {
            // First player's turn
            do
            {
                ChooseAttack(0); // Player 1 chooses an attack
                Console.Write("Round " + roundCounter + "\n\n");
                curDamage = player1.AttackManager(player2, doAttackNumber); // Player 1 attacks player 2

                // Check if player 2 is dead
                if (player2.IsDead())
                {
                    Console.Write("Round " + roundCounter + "\n\n");
                    TextAnimateTime("The " + player2.GetT() + " is dead", 2000);
                    player1.SetIsWinner(true);
                    fightRunning = false;
                    return;
                }
            } while (!attackDone); // Repeat if attack or ability failed
            attackDone = true;

            // Second player's turn
            do
            {

                ChooseAttack(1); // Player 2 chooses an attack
                Console.Write("Round " + roundCounter + "\n\n");
                curDamage = player2.AttackManager(player1, doAttackNumber); // Player 2 attacks player 1

                // Check if player 1 is dead
                if (player1.IsDead())
                {
                    Console.Write("Round " + roundCounter + "\n\n");
                    TextAnimateTime("The " + player1.GetT() + " is dead", 2000);
                    player2.SetIsWinner(true);
                    fightRunning = false;
                    return;
                }
            } while (!attackDone); // Repeat if attack or ability failed
            attackDone = true;
        }


        /// <summary>
        /// Allows a player to choose an attack during a round
        /// </summary>
        /// <param name="_curPlayer">The index of the current player (0 for player1, 1 for player2)</param>
        static public void ChooseAttack(int _curPlayer)
        {
            validInput = false;

            // Loop until a valid input is received
            while (validInput == false)
            {
                // Display round information and prompt the player to choose an attack
                Console.Write("Round " + roundCounter + "\n\n");
                if (_curPlayer == 0)
                {
                    TextAnimate(player1.GetT() + " please select your attack\n");
                    TextAnimate(player1.GetSpecialAttacksNames());
                }
                else if (_curPlayer == 1)
                {
                    TextAnimate(player2.GetT() + " please select your attack\n");
                    TextAnimate(player2.GetSpecialAttacksNames());
                }

                // Read key input
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.Clear();

                // Process the input and determine the chosen attack
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        {
                            // Set the attack number based on the input
                            doAttackNumber = 0;
                            validInput = true;
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            doAttackNumber = 1;
                            validInput = true;
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            doAttackNumber = 2;
                            validInput = true;
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            doAttackNumber = 3;
                            validInput = true;
                            break;
                        }
                    default:
                        {
                            // Display an error message for invalid input
                            TextAnimateTime("Invalid input please try again", 1000);
                            validInput = false;
                            break;
                        }
                }
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
                            TextAnimateTime("Alright let's go", 500);
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
                            TextAnimateTime("Pleas answer with [Y]es or [N]o", 1000);
                            validInput = false;
                        }
                        break;
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