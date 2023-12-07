using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf
{
    internal class Goblin : Monster
    {

        public float heal=0;

        public Goblin(float _hp = 15, float _ap = 7, float _dp = 1, float _s = 5)
        {
            healthPoints = _hp;
            attackPoints = _ap;
            defensePoints = _dp;
            speed = _s;
            type = "Goblin";
        }
        override public string GetSpecialAttacksNames()
        {
            return "1 = Basic Attack, 2 = Fast Attack, 3 = Assasin Attack\n";
        }

        #region Attacks
        override public float SpecialAttack1(Monster _enemy)             //SpeedAttack
        {
            float enemyDP = _enemy.GetDP();


            damage = (attackPoints + (speed/2)) - enemyDP;


            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
        override public float SpecialAttack2(Monster _enemy)             //StealHP
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
        override public void SpecialAttack1Reaktion(Monster _enemy)
        {
            TextAnimate("The " + type + " attacked very fast and made " + damage + " damage to the " + _enemy.GetT() + "\n");

            _enemy.CalcNewHp(damage);
            TextAnimateTime("New HP of the " + _enemy.GetT() + " is " + _enemy.GetHP(), 2000);
        }
        override public void SpecialAttack2Reaktion(Monster _enemy)
        {
            TextAnimate("The " + type + " stole " + heal + " health points from the " + _enemy.GetT() + "\n");

            _enemy.CalcNewHp(damage);
            TextAnimate("New HP of the " + type + " is " + healthPoints + "\n");
            TextAnimateTime("New HP of the " + _enemy.GetT() + " is " + _enemy.GetHP(), 2000);
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
