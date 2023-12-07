using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf
{
    internal class Monster
    {
        protected float healthPoints;
        protected float attackPoints;
        protected float defensePoints;
        protected float speed;
        protected int doAttackNumber;
        protected float damage;
        protected bool isWinner = false;
        protected string type;

        #region Get Set
        public float GetHP()
        {
            return healthPoints;
        }
        public void SetHP(float _HP)
        {
            healthPoints = _HP;
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
        public void SetAll(float _hp, float _ap, float _dp, float _s)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
        }
        public string GetAll()
        {
            string output;

            output = "healthPoints: " + healthPoints + "\n"
                   + "attackPoints: " + attackPoints + "\n"
                   + "defensePoints: " + defensePoints + "\n"
                   + "speed: " + speed + "\n\n";

            return output;
        }
        #endregion

        public float BasicAttack(Monster _enemy)
        {
            float enemyDP = _enemy.GetDP();

            damage = attackPoints - enemyDP;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        public void BasicReaktion(Monster _enemy)
        {
            Program.TextAnimate("The " + type + " made " + damage + " damage to the " + _enemy.GetT() + "\n");

            _enemy.CalcNewHp(damage);
            Program.TextAnimateTime("New HP of the " + _enemy.GetT() + " is " + _enemy.GetHP(), 2000);
        }

        public void CalcNewHp(float _damage)
        {
            healthPoints = healthPoints - _damage;
            if (healthPoints < 0)
            {
                healthPoints = 0;
            }
        }
        public bool IsDead()
        {
            if (healthPoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region Virtual Methods
        virtual public string GetSpecialAttacksNames()
        {
            return "";
        }
        virtual public float AttackManager(Monster _enemy, int _doAttackNumber)
        {
            return damage;
        }

        virtual public float SpecialAttack1(Monster _enemy)
        {
            return damage;
        }

        virtual public float SpecialAttack2(Monster _enemy)
        {
            return damage;
        }

        #region Attack Reaction
        virtual public void SpecialAttack1Reaktion(Monster _enemy)
        {
        }
        virtual public void SpecialAttack2Reaktion(Monster _enemy)
        {
        }
        #endregion
        #endregion

    }
}
