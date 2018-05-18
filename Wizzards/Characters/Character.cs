using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Enum;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character
    {
        private string name;

        private double armor;
        public double BaseArmor { get; }

        private double health;
        public double BaseHealth { get; }

        private double abilityPoints;
        public Faction Faction { get; }
        public Bag Bag { get; protected set; }
        protected virtual double RestHealMultiplier => 0.2;
        public bool IsAlive { get; set; } = true;
        
        protected Character(string name, double health , double armor, double abilityPoints, Bag bag,Faction faction)
        {
            this.Name = name;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.BaseHealth = health;
            this.Health = health;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }
        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or whitespace!");
                }
                name = value;
            }
        }


        public double Health
        {
            get { return health; }
            set
            {
                health = Math.Min(value, this.BaseHealth);
            }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                armor = Math.Min(value, this.BaseArmor);
            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            protected set { abilityPoints = value; }
        }

        public void TakeDamage(double hitPoint)
        {
            SecureAlive();
            if (this.Armor >= hitPoint)
            {
                this.Armor = Math.Max(0,this.Armor -  hitPoint);
            }
            else
            {
               
                this.Health = Math.Max(0,this.Health - (hitPoint - this.Armor));
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        protected void Rest()
        {
            SecureAlive();
            this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);
        }

        protected void UseItem(Item item)
        {
            SecureAlive();
            UseItemOn(item, this);
        }

        protected void UseItemOn(Item item, Character character)
        {
            this.SecureAlive();
            character.SecureAlive();
            item.AffectCharacter(character);
        }

        protected void GiveCharacterItem(Item item, Character character)
        {
            this.SecureAlive();
            character.SecureAlive();
            
            character.RecieveItem(item);
        }

        protected void RecieveItem(Item item)
        {
            this.SecureAlive();
           this.Bag.AddItem(item);
        }
        public void SecureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
