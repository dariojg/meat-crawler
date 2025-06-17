
[System.Serializable]
public class InventoryItem
{

    public InventoryItemData data;
    public int StackSize { get; set; }


    public InventoryItem(InventoryItemData data)
    {
        this.data = data;
        AddToStack(1);
    }


    public void AddToStack(int amount)
    {
        StackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        StackSize -= amount;
    }
}
