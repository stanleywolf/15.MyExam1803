
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag
    {
        public int Capacity { get; } = 100;
        private List<Item> items;
        public int Load => this.items.Sum(w => w.Weight);

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public IReadOnlyCollection<Item> Items
        {
            get { return items.AsReadOnly(); }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            ExistItem(name);

            var item = this.items.FirstOrDefault(f => f.GetType().Name == name);
            this.items.Remove(item);
            return item;

        }

        private void ExistItem(string name)
        {
            if (items.Count < 1)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            var itemExist = this.items.Any(f => f.GetType().Name == name);
            if (!itemExist)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
        }
    }
}
