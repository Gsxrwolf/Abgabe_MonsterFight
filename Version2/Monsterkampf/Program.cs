using System.Globalization;

namespace Monsterkampf
{
    internal class Program
    {
        #region Special Variables
        static public int speed = 1;
        static public bool FrAnt;
        #endregion

        static public Monster player1;
        static public Monster player2;
        static public Monster tempMonster;

        static public float tempHP;
        static public float tempAP;
        static public float tempDP;
        static public float tempS;

        static public bool fightRunning = true;

        static public int doAttackNumber = 0;

        static public bool attackDone = true;

        static public float curDamage;

        static public int roundCounter = 0;

        static public bool startNewFight;

        static void Main(string[] args)
        {
            #region Debugging Settings
            speed = 1;
            #endregion

            WantTutorial();
            do
            {
                ChooseMonsters();

                GameLoop();

                WinnerScreen();

                NewFight();

            } while (startNewFight);
        }

        static public void WantTutorial()
        {
            FrAnt = false;
            while (FrAnt == false)
            {
                TextAnimate("Do you want a tutorial?\n");
                TextAnimate("[Y]es, [N]o\n");
                ConsoleKeyInfo input2 = Console.ReadKey(true);
                switch (input2.Key)
                {
                    case ConsoleKey.Y:
                        {
                            Console.Clear();
                            TextAnimateTime("Alright let's start with a tutorial", 500);
                            Tutorial();
                            FrAnt = true;
                            Console.Clear();
                            break;
                        }

                    case ConsoleKey.N:
                        {
                            Console.Clear();
                            TextAnimateTime("Ok let's start with a fight", 1000);
                            FrAnt = true;
                            Console.Clear();
                            break;
                        }
                    default:
                        {

                            Console.Clear();
                            TextAnimateTime("Pleas answer with [Y]es or [N]o", 1000);
                            FrAnt = false;
                        }
                        break;
                }
            }
        }

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

        static public void ChooseMonsters()
        {
            for (int i = 0; i < 2; i++)
            {
                FrAnt = false;

                while (FrAnt == false)
                {
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
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    Console.Clear();
                    switch (input.Key)
                    {

                        case ConsoleKey.D1:
                            {

                                if (i == 0)
                                {
                                    player1 = new Ork();
                                    SetMonsterVariables(i);
                                }
                                else
                                {
                                    if (player1.GetT() == "Ork")
                                    {
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than ork", 1000);
                                        break;
                                    }
                                    player2 = new Ork();
                                    SetMonsterVariables(i);

                                    if (player1.GetS() < player2.GetS())
                                    {
                                        tempMonster = player1;
                                        player1 = player2;
                                        player2 = tempMonster;
                                    }

                                }

                                FrAnt = true;
                                break;
                            }


                        case ConsoleKey.D2:
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
                                FrAnt = true;
                                break;
                            }


                        case ConsoleKey.D3:
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
                                FrAnt = true;
                                break;
                            }
                        default:
                            {
                                TextAnimateTime("Invalid input please try again", 1000);
                                FrAnt = false;
                            }
                            break;

                    }

                }

            }

            TextAnimateTime("Monsters saved", 1000);
        }

        #region Monster Settings
        static public void SetMonsterVariables(int monsterCount)
        {
            Console.Clear();
            FrAnt = false;
            while (FrAnt == false)
            {
                if (monsterCount == 0) TextAnimate(player1.GetAll());
                if (monsterCount == 1) TextAnimate(player2.GetAll());

                TextAnimate("Play with default monster settings?\n");
                TextAnimate("[Y]es, [N]o\n");
                ConsoleKeyInfo input2 = Console.ReadKey(true);
                switch (input2.Key)
                {

                    case ConsoleKey.Y:
                        {
                            Console.Clear();
                            TextAnimateTime("Ok defaults will be used", 1000);
                            FrAnt = true;
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.N:
                        {
                            Console.Clear();
                            TextAnimateTime("Alright let's set up the monster", 500);

                            SetMonsterHp();
                            SetMonsterAp();
                            SetMonsterDp();
                            SetMonsterS();

                            if (monsterCount == 0) player1.SetAll(tempHP, tempAP, tempDP, tempS);
                            if (monsterCount == 1) player2.SetAll(tempHP, tempAP, tempDP, tempS);

                            FrAnt = true;
                            Console.Clear();
                            break;
                        }
                    default:
                        {

                            Console.Clear();
                            TextAnimateTime("Pleas answer with [Y]es or [N]o", 1000);
                            FrAnt = false;
                        }
                        break;
                }
            }

        }
        static public void SetMonsterHp()
        {
            FrAnt = false;
            while (FrAnt == false)
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
                    FrAnt = true;
                    tempHP = valurInput;
                }


            }

        }
        static public void SetMonsterAp()
        {
            FrAnt = false;
            while (FrAnt == false)
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
                    FrAnt = true;
                    tempAP = valurInput;
                }


            }
        }
        static public void SetMonsterDp()
        {
            FrAnt = false;
            while (FrAnt == false)
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
                    FrAnt = true;
                    tempDP = valurInput;
                }


            }
        }
        static public void SetMonsterS()
        {
            FrAnt = false;
            while (FrAnt == false)
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
                    FrAnt = true;
                    tempS = valurInput;
                }


            }
        }
        #endregion


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

        static public void PlayRound()
        {
            do
            {
                ChooseAttack(0);
                Console.Write("Round " + roundCounter + "\n\n");
                curDamage = player1.AttackManager(player2, doAttackNumber);

                if (player2.IsDead())
                {
                    Console.Write("Round " + roundCounter + "\n\n");
                    TextAnimateTime("The " + player2.GetT() + " is dead", 2000);
                    player1.SetIsWinner(true);
                    fightRunning = false;
                    return;
                }
            } while (!attackDone);
            attackDone = true;

            do
            {
                ChooseAttack(1);
                Console.Write("Round " + roundCounter + "\n\n");
                curDamage = player2.AttackManager(player1, doAttackNumber);


                if (player1.IsDead())
                {
                    Console.Write("Round " + roundCounter + "\n\n");
                    TextAnimateTime("The " + player1.GetT() + " is dead", 2000);
                    player2.SetIsWinner(true);
                    fightRunning = false;
                    return;
                }
            }while (!attackDone) ;
            attackDone = true;
        }

        static public void ChooseAttack(int _curPlayer)
        {
            FrAnt = false;

            while (FrAnt == false)
            {
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
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.Clear();
                switch (input.Key)
                {

                    case ConsoleKey.D1:
                        {
                            doAttackNumber = 0;
                            FrAnt = true;
                            break;
                        }


                    case ConsoleKey.D2:
                        {
                            doAttackNumber = 1;
                            FrAnt = true;
                            break;
                        }


                    case ConsoleKey.D3:
                        {
                            doAttackNumber = 2;
                            FrAnt = true;
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            doAttackNumber = 3;
                            FrAnt = true;
                            break;
                        }
                    default:
                        {
                            TextAnimateTime("Invalid input please try again", 1000);
                            FrAnt = false;
                        }
                        break;

                }

            }
        }

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

        static public void NewFight()
        {
            FrAnt = false;
            while (FrAnt == false)
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
                            FrAnt = true;
                            Console.Clear();
                            break;
                        }

                    case ConsoleKey.N:
                        {
                            Console.Clear();
                            TextAnimateTime("Ok", 1000);
                            startNewFight = false;
                            FrAnt = true;
                            Console.Clear();
                            break;
                        }
                    default:
                        {

                            Console.Clear();
                            TextAnimateTime("Pleas answer with [Y]es or [N]o", 1000);
                            FrAnt = false;
                        }
                        break;
                }
            }
        }
        #region Special Methods
        public static void TextAnimate(string _input)
        {
            if (_input != null || _input != "")
            {

                char[] letters = _input.ToCharArray();
                string output = "";

                for (int i = 0; i < letters.Length; i++)
                {
                    Console.Write(letters[i]);
                    Thread.Sleep(15 / speed);
                }
            }

        }
        public static void TextAnimateTime(string _input, int _time)
        {
            TextAnimate(_input);
            Thread.Sleep(_time / speed);
            Console.Clear();
        }
        #endregion
    }
    public class InputManager
    {
        static Queue<ConsoleKeyInfo> inputBuffer = new Queue<ConsoleKeyInfo>();
        static object inputLock = new object();
        static int maxBufferSize = 1;

        public InputManager()
        {
            Thread inputThread = new Thread(ReadInput);
            inputThread.Start();
        }

        private void ReadInput()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    lock (inputLock)
                    {
                        inputBuffer.Enqueue(key);
                        while (inputBuffer.Count > maxBufferSize)
                        {
                            inputBuffer.Dequeue();
                        }
                    }
                }
            }
        }

        public bool KeyPressed()
        {
            lock (inputLock)
            {
                return inputBuffer.Count > 0;
            }
        }

        public ConsoleKeyInfo ReadKey()
        {
            lock (inputLock)
            {
                if (inputBuffer.Count > 0)
                {
                    return inputBuffer.Dequeue();
                }
                else
                {
                    return new ConsoleKeyInfo();
                }
            }
        }
    }
}