namespace Atlas.RPG.Items.Items.Weapons
{
    public abstract class WeaponBase : ItemBase
    {
        public int Damage { get; set; }

        protected WeaponBase(string name, string description, double weight, decimal value, int damage)
            : base(name, description, weight, value)
        {
            Type = ItemType.Weapon;
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
            Damage = damage;
        }
    }
}
