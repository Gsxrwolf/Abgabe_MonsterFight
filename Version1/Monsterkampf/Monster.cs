using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf
{
    // This class represents a monster in the game
    internal class Monster
    {
        // Properties of the monster
        public float healthPoints;   
        public float attackPoints;   
        public float defensePoints;  
        public float speed;          
        public string type;          
        public bool isWinner = false;

        // Constructor to create a monster with the given properties
        public Monster(float _hp, float _ap, float _dp, float _s, string _t)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
            type = _t;
        }

        /// <summary>
        /// Method to get the health points
        /// </summary>
        /// <returns>Health points</returns>
        public float GetHP()
        {
            return healthPoints;
        }

        /// <summary>
        /// Method to get the attack points
        /// </summary>
        /// <returns>Attack points</returns>
        public float GetAP()
        {
            return attackPoints;
        }

        /// <summary>
        /// Method to get the defense points
        /// </summary>
        /// <returns>Defense points</returns>
        public float GetDP()
        {
            return defensePoints;
        }

        /// <summary>
        /// Method to get the speed
        /// </summary>
        /// <returns>Speed</returns>
        public float GetS()
        {
            return speed;
        }

        /// <summary>
        /// Method to get the type of the monster
        /// </summary>
        /// <returns>Type of the monster</returns>
        public string GetT()
        {
            return type;
        }

        /// <summary>
        /// Method to set whether the monster is the winner
        /// </summary>
        /// <param name="_isWinner">Is Monster the winner</param>
        public void SetIsWinner(bool _isWinner)
        {
            isWinner = _isWinner;
        }

        // 
        /// <summary>
        /// Method to check if the monster is the winner
        /// </summary>
        /// <returns>Is monster the winner</returns>
        public bool GetIsWinner()
        {
            return isWinner;
        }

        /// <summary>
        /// Method for attacking another monster
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        /// <returns>Calculated damage amount</returns>
        public float Attack(Monster _enemy)
        {
            float damage;
            float enemyDP = _enemy.GetDP();

            // Calculating damage based on attack points and enemy's defense
            damage = attackPoints - enemyDP;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        /// <summary>
        /// Method to calculate the new health points after an attack
        /// </summary>
        /// <param name="_damage">Damage taken</param>
        public void CalcNewHp(float _damage)
        {
            healthPoints -= _damage;
            if (healthPoints < 0)
            {
                healthPoints = 0;
            }
        }

        /// <summary>
        /// Method to check if the monster is dead
        /// </summary>
        /// <returns>Is dead or not</returns>
        public bool IsDead()
        {
            return healthPoints == 0;
        }
    }

}
