using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Characters.Interfaces;
using DungeonsAndCodeWizards.Enum;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric:Character,IHealable
    {
        public Cleric(string name, Faction faction) : base(name, health:50, armor:25, abilityPoints:40, bag:new Backpack(), faction:faction)
        {
        }

        protected override double RestHealMultiplier { get; } = 0.5;

        public void Heal(Character character)
        {
            this.SecureAlive();
            character.SecureAlive();

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }
            character.Health += this.AbilityPoints;
        }
    }
}
