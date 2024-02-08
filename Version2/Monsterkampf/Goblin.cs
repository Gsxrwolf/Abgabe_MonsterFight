using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf
{
    internal class Goblin : Monster
    {
        public float heal=0; // Value for health regeneration

        // Constructor to initialize Troll attributes
        public Goblin(float _hp = 15, float _ap = 7, float _dp = 1, float _s = 5)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
            type = "Goblin";
        }


        /// <summary>
        /// Override method to provide special attack names
        /// </summary>
        /// <returns>A string withe the attack names</returns>
        override public string GetSpecialAttacksNames()
        {
            return "1 = Basic Attack, 2 = Fast Attack, 3 = Assasin Attack\n";
        }

        #region Attacks
        /// <summary>
        /// Override method for Special Attack 1 of Goblin: SpeedAttack
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        /// <returns>Calculated damage amount</returns>
        override public float SpecialAttack1(Monster _enemy)
        {
            float enemyDP = _enemy.GetDP();


            damage = (attackPoints + (speed/2)) - enemyDP;


            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        /// <summary>
        /// Override method for Special Attack 2 of Goblin: StealHP
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        /// <returns>Calculated damage amount</returns>
        override public float SpecialAttack2(Monster _enemy)
        {
            float enemyHP = _enemy.GetHP();
            float enemyDP = _enemy.GetDP();

            heal = (enemyHP / 5)-(enemyDP/2);
            if (heal < 0)
            {
                heal = 0;
            }


            healthPoints = healthPoints + heal;
            _enemy.SetHP(_enemy.GetHP() - heal);


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
        /// Override method for reaction to Special Attack 1 of Goblin
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        override public void SpecialAttack1Reaktion(Monster _enemy)
        {
            TextAnimate("The " + type + " attacked very fast and made " + damage + " damage to the " + _enemy.GetT() + "\n");

            _enemy.CalcNewHp(damage);
            TextAnimateTime("New HP of the " + _enemy.GetT() + " is " + _enemy.GetHP(), 2000);
        }

        /// <summary>
        /// Override method for reaction to Special Attack 2 of Troll
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        override public void SpecialAttack2Reaktion(Monster _enemy)
        {
            TextAnimate("The " + type + " stole " + heal + " health points from the " + _enemy.GetT() + "\n");

            _enemy.CalcNewHp(damage);
            TextAnimate("New HP of the " + type + " is " + healthPoints + "\n");
            TextAnimateTime("New HP of the " + _enemy.GetT() + " is " + _enemy.GetHP(), 2000);
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
                        break;
                    }

                // Case 1: Special Attack 1
                case 1:
                    {
                        damage = SpecialAttack1(_enemy);    // Calculate damage
                        SpecialAttack1Reaktion(_enemy); // Corresponding reaction
                        break;
                    }

                // Case 2: Special Attack 2
                case 2:
                    {
                        damage = SpecialAttack2(_enemy);    // Calculate damage
                        SpecialAttack2Reaktion(_enemy); // Corresponding reaction
                        break;
                    }
            }
            return damage;
        }
    }
}
