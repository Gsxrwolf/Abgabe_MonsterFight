using System;

namespace Monsterkampf
{
    internal class Ork : Monster
    {
        // Constructor to initialize Ork attributes
        public Ork(float _hp = 20, float _ap = 5, float _dp = 3, float _s = 3)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
            type = "Ork";
        }

        /// <summary>
        /// Override method to provide special attack names
        /// </summary>
        /// <returns>A string withe the attack names</returns>
        override public string GetSpecialAttacksNames()
        {
            return "1 = Basic Attack, 2 = Attack Transferation, 3 = Defense Transferation\n";
        }

        #region Attacks
        /// <summary>
        /// Override method for Special Attack 1 of Ork: TransferToAttack
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        /// <returns>Calculated damage amount</returns>
        override public float SpecialAttack1(Monster _enemy)
        {
            if (defensePoints == 0)
            {
                Program.TextAnimateTime("You dont have enough defense points to transfer", 2000);
                attackDone = false;
            }
            else
            {
                attackDone = true;
                attackPoints += 1;
                defensePoints -= 1;
            }

            damage = 0;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        /// <summary>
        /// Override method for Special Attack 2 of Ork: TransferToDefense
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        /// <returns>Calculated damage amount</returns>
        override public float SpecialAttack2(Monster _enemy)
        {
            if (attackPoints == 0)
            {
                Program.TextAnimateTime("You dont have enough attack points to transfer", 2000);
                attackDone = false;
            }
            else
            {
                attackDone = true;
                defensePoints += 1;
                attackPoints -= 1;
            }

            damage = 0;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
        #endregion

        #region Attack Reaction
        /// <summary>
        /// Override method for reaction to Special Attack 1 of Ork
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        override public void SpecialAttack1Reaktion(Monster _enemy)
        {
            Program.TextAnimate("The " + type + " transferred 1 defense point to the attack points\n\n");
            Program.TextAnimate("New AP of the " + type + " is " + attackPoints + "\n");
            Program.TextAnimateTime("New DP of the " + type + " is " + defensePoints, 2000);
        }

        /// <summary>
        /// Override method for reaction to Special Attack 2 of Ork
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        override public void SpecialAttack2Reaktion(Monster _enemy)
        {
            Program.TextAnimate("The " + type + " transferred 1 attack point to the defense points\n\n");
            Program.TextAnimate("New DP of the " + type + " is " + defensePoints + "\n");
            Program.TextAnimateTime("New AP of the " + type + " is " + attackPoints, 2000);
        }
        #endregion

        /// <summary>
        /// Override method to manage attacks
        /// </summary>
        /// <param name="_enemy">The monster to attack</param>
        /// <param name="_doAttackNumber">The number representing the chosen attack</param>
        /// <returns>The damage inflicted on the enemy monster</returns>
        override public float AttackManager(Monster _enemy, int _doAttackNumber)
        {
            doAttackNumber = _doAttackNumber;
            switch (doAttackNumber) // Switch statement to handle different attack types
            {
                // Case 0: Basic Attack
                case 0:
                    {
                        
                        damage = BasicAttack(_enemy);   // Calculate damage
                        BasicReaktion(_enemy);  // Corresponding reaction
                        attackDone = true;  // Mark the attack as done
                        break;
                    }

                // Case 1: Special Attack 1
                case 1:
                    {
                        damage = SpecialAttack1(_enemy);    // Executing SpecialAttack1

                        // If action was successful, react to it
                        if (attackDone)
                        {
                            SpecialAttack1Reaktion(_enemy);
                        }
                        break;
                    }

                // Case 2: Special Attack 2
                case 2:
                    {
                        damage = SpecialAttack2(_enemy);    // Executing SpecialAttack2

                        // If action was successful, react to it
                        if (attackDone)
                        {
                            SpecialAttack2Reaktion(_enemy);
                        }
                        break;
                    }
            }

            // Return the damage inflicted on the enemy monster 
            // Is zero when special attacks were used because they dont do damage
            return damage;
        }

    }
}
