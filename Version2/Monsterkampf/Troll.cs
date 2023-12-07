using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf
{
    internal class Troll : Monster
    {
        public Troll(float _hp = 30, float _ap = 3, float _dp = 3, float _s = 1)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
            type = "Troll";
        }
        override public string GetSpecialAttacksNames()
        {
            return "1 = Basic Attack, 2 = Heavy Attack, 3 = Petrification\n";
        }

        #region Attacks
        override public float SpecialAttack1(Monster _enemy)         //HeavyAttack
        {
            float enemyDP = _enemy.GetDP();

            CalcNewHp(enemyDP / 2);
            damage = attackPoints;

            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
        override public float SpecialAttack2(Monster _enemy)         //BuildDefense
        {
            defensePoints += 1;

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
            TextAnimate("The " + type + " lost " + _enemy.GetDP() / 2 + " health points but made " + damage + " damage to the " + _enemy.GetT() + "\n\n");

            _enemy.CalcNewHp(damage);
            TextAnimate("New HP of the " + type + " is " + healthPoints + "\n");
            TextAnimateTime("New HP of the " + _enemy.GetT() + " is " + _enemy.GetHP(), 2000);
        }
        override public void SpecialAttack2Reaktion(Monster _enemy)
        {
            TextAnimate("The " + type + " generated an extra defense point\n\n");
            TextAnimateTime("New DP of the " + type + " is " + defensePoints, 2000);
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
                        break;
                    }

                case 1:
                    {
                        damage = SpecialAttack1(_enemy);
                        SpecialAttack1Reaktion(_enemy);
                        break;
                    }
                case 2:
                    {
                        damage = SpecialAttack2(_enemy);
                        SpecialAttack2Reaktion(_enemy);
                        break;
                    }
            }
            return damage;
        }
    }
}
