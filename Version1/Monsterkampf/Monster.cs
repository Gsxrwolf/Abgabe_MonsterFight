using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf
{
    internal class Monster
    {
        public float healthPoints;
        public float attackPoints;
        public float defensePoints;
        public float speed;
        public string type;
        public bool isWinner = false;

        public Monster(float _hp, float _ap, float _dp, float _s, string _t)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
            type = _t;
        }
        public float GetHP()
        {
            return healthPoints;
        }
        public float GetAP()
        {
            return attackPoints;
        }
        public float GetDP()
        {
            return defensePoints;
        }
        public float GetS()
        {
            return speed;
        }
        public string GetT()
        {
            return type;
        }
        public void SetIsWinner(bool _isWinner)
        {
            isWinner = _isWinner;
        }
        public bool GetIsWinner()
        {
            return isWinner;
        }

        public float Attack(Monster _enemy)
        {
            float damage;
            float enemyDP = _enemy.GetDP();

            damage = attackPoints - enemyDP;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        public void CalcNewHp(float _damage)
        {
            healthPoints = healthPoints - _damage;
            if(healthPoints < 0)
            {
                healthPoints = 0;
            }
        }
        public bool IsDead()
        {
            if(healthPoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
