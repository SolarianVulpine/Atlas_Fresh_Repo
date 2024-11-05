namespace Atlas.RPG.Items.Items.Potions;

public class HealthPotion : PotionBase
{
    public HealthPotion()
    {
        Type = ItemType.Potion;
        Name = "Health Potion";
        Description = "A potion that restores health.";
        Weight = 1;
        Value = 10;
    }

    public override void Drink()
    {
        Console.WriteLine("Glug, glug, glug! You feel better!");
    }
}
