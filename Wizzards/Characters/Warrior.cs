using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Characters.Interfaces;
using DungeonsAndCodeWizards.Enum;

namespace DungeonsAndCodeWizards.Characters
{
    public class Warrior :  Character,IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, health:100, armor:50, abilityPoints:40,bag:new Satchel(),faction:faction)
        {
        }

        protected override double RestHealMultiplier { get; } = 0.5;

        public void Attack(Character character)
        {
            character.SecureAlive();
            this.SecureAlive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
            this.TakeDamage(character.AbilityPoints);
        }
    }
}
