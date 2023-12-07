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

        static public float curDamage;

        static public int roundCounter = 0;

        static public bool startNewFight;

        static void Main(string[] args)
        {
            #region Debugging Settings
            speed = 1;
            #endregion
            do
            {
                ChooseMonsters();

                GameLoop();

                WinnerScreen();

                NewFight();

            } while (startNewFight);
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
                        TextAnimate("1=Ork, 2=Troll, 3=Goblin\n");
                    }
                    else
                    {

                        TextAnimate("Please select your second Monsters\n");
                        TextAnimate("1=Ork, 2=Troll, 3=Goblin\n");
                    }
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    switch (input.Key)
                    {

                        case ConsoleKey.D1:
                            {

                                if (i == 0)
                                {
                                    SetMonsterVariables();
                                    player1 = new Monster(tempHP, tempAP, tempDP, tempS, "Ork");
                                }
                                else
                                {
                                    if (player1.GetT() == "Ork")
                                    {
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than ork", 1000);
                                        break;
                                    }
                                    SetMonsterVariables();
                                    player2 = new Monster(tempHP, tempAP, tempDP, tempS, "Ork");

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
                                    SetMonsterVariables();
                                    player1 = new Monster(tempHP, tempAP, tempDP, tempS, "Troll");
                                }
                                else
                                {
                                    if (player1.GetT() == "Troll")
                                    {
                                        Console.Clear();
                                        TextAnimateTime("Please choose a monster other than troll", 1000);
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
                                FrAnt = true;
                                break;
                            }


                        case ConsoleKey.D3:
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
                                        TextAnimateTime("Please choose a monster other than goblin", 1000);
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

        static public void SetMonsterVariables()
        {
            SetMonsterHp();
            SetMonsterAp();
            SetMonsterDp();
            SetMonsterS();
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

        static public void GameLoop()
        {
            Console.Clear();
            roundCounter = 0;
            TextAnimateTime("The " + player1.GetT() + " is starting the fight", 2000);
            while(fightRunning)
            {
                TextAnimateTime("Round " + roundCounter, 1000);
                PlayRound();
                roundCounter++;
            }
        }

        static public void PlayRound()
        {

            curDamage = player1.Attack(player2);
            Console.Write("Round " + roundCounter + "\n\n");
            TextAnimate("The " + player1.GetT() + " made " + curDamage + " damage to the " + player2.GetT() + "\n");

            player2.CalcNewHp(curDamage);
            TextAnimateTime("New HP of the " + player2.GetT() + " is " + player2.GetHP(), 3000);

            if (player2.IsDead())
            {
                Console.Write("Round " + roundCounter + "\n\n");
                TextAnimateTime("The " + player2.GetT() + " is dead", 2000);
                player1.SetIsWinner(true);
                fightRunning = false;
                return;
            }



            curDamage = player2.Attack(player1);
            Console.Write("Round " + roundCounter + "\n\n");
            TextAnimate("The " + player2.GetT() + " made " + curDamage + " damage to the " + player1.GetT() + "\n");

            player1.CalcNewHp(curDamage);
            TextAnimateTime("New HP of the " + player1.GetT() + " is " + player1.GetHP(), 3000);

            if (player1.IsDead())
            {
                Console.Write("Round " + roundCounter + "\n\n");
                TextAnimateTime("The " + player1.GetT() + " is dead", 2000);
                player2.SetIsWinner(true);
                fightRunning = false;
                return;
            }
        }

        static public void WinnerScreen()
        {
            if(player1.GetIsWinner())
            {
                TextAnimateTime("The " + player1.GetT() + " won after " + roundCounter + " rounds", 2000);
            }

            if(player2.GetIsWinner())
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