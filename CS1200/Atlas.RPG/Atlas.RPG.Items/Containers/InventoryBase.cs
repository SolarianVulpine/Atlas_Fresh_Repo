namespace Atlas.RPG.Items;

public class InventoryBase
{
    protected int _capacity;
    protected ItemBase[] _contents;

    public InventoryBase(int capacity)
    {
        _capacity = capacity;
        _contents = new ItemBase[_capacity];
    }

    public virtual bool AddItem(ItemBase item)
    {
        for (int i = 0; i < _capacity; i++)
        {
            if (_contents[i] == null)
            {
                _contents[i] = item;
                return true;
            }
        }
        return false;
    }

    public virtual ItemBase RemoveItem(int index)
    {
        if (index >= 0 && index < _capacity)
        {
            ItemBase item = _contents[index];
            if (item != null)
            {
                _contents[index] = null;
                return item;
            }
        }
        return null;
    }

    public virtual void ListContents()
    {
        Console.WriteLine("Contents");
        Console.WriteLine("=================");
        foreach (var item in _contents)
        {
            if (item != null)
            {
                string itemType = item.Type.ToString().PadRight(8);
                string itemName = item.Name.PadRight(20);
                string weight = $"{item.Weight:F2}kg".PadLeft(8);
                string value = $"${item.Value:F2}".PadLeft(8);
                Console.WriteLine($"{itemType}|{itemName}|{weight}|{value}");
            }
        }
    }
}