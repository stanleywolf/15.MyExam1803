using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class HealthPotion:Item
    {
        public HealthPotion() : base(weight:5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health = Math.Max(character.BaseHealth, character.Health + 20);
        }
    }
}
