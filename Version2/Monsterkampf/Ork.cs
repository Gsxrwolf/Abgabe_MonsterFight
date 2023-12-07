using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf
{
    internal class Ork : Monster
    {
        public Ork(float _hp = 20, float _ap = 5, float _dp = 3, float _s = 3)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
            type = "Ork";
        }

        override public string GetSpecialAttacksNames()
        {
            return "1 = Basic Attack, 2 = Attack Transferation, 3 = Defense Transferation\n";
        }

        #region Attacks
        override public float SpecialAttack1(Monster _enemy)             //TransferToAttack
        {
            if (defensePoints == 0)
            {
                TextAnimateTime("You dont have enough defense points to transfer", 2000);
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
        override public float SpecialAttack2(Monster _enemy)             //TransferToDefense
        {

            if (attackPoints == 0)
            {
                TextAnimateTime("You dont have enough attack points to transfer", 2000);
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
        override public void SpecialAttack1Reaktion(Monster _enemy)
        {
            TextAnimate("The " + type + " transferred 1 defense point to the attack points\n\n");
            TextAnimate("New AP of the " + type + " is " + attackPoints + "\n");
            TextAnimateTime("New DP of the " + type + " is " + defensePoints, 2000);
        }
        override public void SpecialAttack2Reaktion(Monster _enemy)
        {
            TextAnimate("The " + type + " transferred 1 attack point to the defense points\n\n");
            TextAnimate("New DP of the " + type + " is " + defensePoints + "\n");
            TextAnimateTime("New AP of the " + type + " is " + attackPoints, 2000);
        }
        #endregion


        override public float AttackManager(Monster _enemy, int _doAttackNumber)
        {
            doAttackNumber = _doAttackNumber;
            switch (doAttackNumber)
            {
                case 0:
                    {
                        damage = BasicAttack(_enemy);
                        BasicReaktion(_enemy);
                        attackDone = true;
                        break;
                    }

                case 1:
                    {
                        damage = SpecialAttack1(_enemy);
                        if (attackDone)
                        {
                            SpecialAttack1Reaktion(_enemy);
                        }
                        break;
                    }
                case 2:
                    {
                        damage = SpecialAttack2(_enemy);
                        if (attackDone)
                        {
                            SpecialAttack2Reaktion(_enemy);
                        }
                        break;
                    }
            }
            return damage;
        }
    }
}
