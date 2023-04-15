using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InGameItemType
{
    Boat,
    BoatEngine,
    FishingRod,
    Fish,
    Net,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite UISprite;

    public InGameItemType type;

    [TextArea(15, 20)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string name;
    public int Id;
    public Item(ItemObject item)
    {
        name = item.name;
        Id = item.Id;
    }
}