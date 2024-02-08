namespace Monsterkampf
{
    internal class Monster : Program
    {
        // Protected fields to store monster attributes
        protected float healthPoints;
        protected float attackPoints;
        protected float defensePoints;
        protected float speed;
        protected int doAttackNumber;
        protected float damage;
        protected bool isWinner = false;
        protected string type;

        // Getter and setter methods for each attribute
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
        public string GetAll()  // Method to get all monster attributes as a formatted string
        {
            string output;

            output = "healthPoints: " + healthPoints + "\n"
                   + "attackPoints: " + attackPoints + "\n"
                   + "defensePoints: " + defensePoints + "\n"
                   + "speed: " + speed + "\n\n";

            return output;
        }
        #endregion

        /// <summary>
        /// Method to perform basic attack
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        /// <returns>Calculated damage amount</returns>
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

        /// <summary>
        /// Method to print a respond after the attack
        /// </summary>
        /// <param name="_enemy">Monster to attack</param>
        public void BasicReaktion(Monster _enemy)
        {
            Program.TextAnimate("The " + type + " made " + damage + " damage to the " + _enemy.GetT() + "\n");

            _enemy.CalcNewHp(damage);
            Program.TextAnimateTime("New HP of the " + _enemy.GetT() + " is " + _enemy.GetHP(), 2000);
        }

        /// <summary>
        /// Method to calculate the new health points after an attack
        /// </summary>
        /// <param name="_damage">Damage taken</param>
        public void CalcNewHp(float _damage)
        {
            healthPoints = healthPoints - _damage;
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


        #region Virtual Methods
        // Virtual methods for special attacks
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
        // Virtual methods for reaction to special attacks
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
