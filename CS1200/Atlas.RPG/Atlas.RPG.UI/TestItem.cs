using Atlas.RPG.Items.Items;

public class TestItem : ItemBase
{
    public TestItem(string name, string description, double weight, decimal value, ItemType type)
        : base(name, description, weight, value, type) {}
}