using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Factories;

namespace DungeonsAndCodeWizards.BussinesLogic
{
    public class DungeonMaster
    {
        private List<Character> partyCharacters;
        private CharacterFactory characterFactpry;
        public List<Character> PartyCharacters
        {
            get { return partyCharacters; }
            set { partyCharacters = value; }
        }

        public DungeonMaster()
        {
            this.PartyCharacters = new List<Character>();
            this.characterFactpry = new CharacterFactory();
        }

        public string JoinParty(string[] args)
        {
            var character = characterFactpry.CreateCharacter(args[0], args[1], args[2]);
            this.PartyCharacters.Add(character);
            return $"{args[2]} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            throw new NotImplementedException();
        }

        public string PickUpItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string UseItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string UseItemOn(string[] args)
        {
            throw new NotImplementedException();
        }

        public string GiveCharacterItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string GetStats()
        {
            throw new NotImplementedException();
        }

        public string Attack(string[] args)
        {
            throw new NotImplementedException();
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }

        public string EndTurn(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

    }
}
