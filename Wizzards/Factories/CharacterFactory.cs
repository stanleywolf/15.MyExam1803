using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Enum;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string charType, string name)
        {
            if (!System.Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
            switch (charType)
            {
                case"Warrior":
                    return new Warrior(name,parsedFaction);
                case "Cleric":
                    return new Cleric(name,parsedFaction);
                    default:
                    throw new ArgumentException($"Invalid character type \"{charType }\"!");
            }
        }
    }
}
