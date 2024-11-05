namespace Atlas.RPG.Items.Items.Armors;

public abstract class ArmorBase : ItemBase
{
        public int Defense { get; set; }
        
        protected ArmorBase(string name, string description, double weight, decimal value, int defense)
        {
                Type = ItemType.Armor;
                Name = name;
                Description = description;
                Weight = weight;
                Value = value;
                Defense = defense;
        }
}