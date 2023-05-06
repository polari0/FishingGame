using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * this Enum is the list of different Item types with in the game
 * Editing it will change the Item types that are availble and it is kinda the back bone of this entire system 
*/
public enum InGameItemType
{
    Boat,
    BoatEngine,
    FishingRod,
    Fish,
    Net,
    Default
}


/*
 * This Enum contains the different stats/buffs given item can give to player character 
 * Edit it to change what buffs you want your character to have.
 */
public enum ItemStats
{
    CatchRate,
    Weight, 
    SellValue,
    CatchRateModifier,
    FuelAmount,
    EngineSpeed
}

//this is the base class for all items in this game holding all nesseccary info that every item type needs. 
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite UISprite;

    public InGameItemType type;

    [TextArea(15, 20)]
    public string description;
    public ItemValues[] itemValues;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}



[System.Serializable]
public class Item
{
    public string name;
    public int Id;
    [Tooltip("This is the list of buffs your item can give and can be modiefied freely atleast im pretty sure it can...")]
    public ItemValues[] itemValues;

    public Item()
    {
        name = "";
        Id = -1;
    }

    public Item(ItemObject item)
    {
        name = item.name;
        Id = item.Id;
        itemValues = new ItemValues[item.itemValues.Length];
        for(int i = 0; i < itemValues.Length; i++)
        {
            itemValues[i] = new ItemValues(item.itemValues[i].min, item.itemValues[i].max)
            {
                itemStats = item.itemValues[i].itemStats
            };
        }
    }
}

//this class holds stats for the fish we can generate trough catching them from the bond. 
//this is also only needed for the randomized item stats and perhabs not needed here 
[System.Serializable]
public class ItemValues
{
    public ItemStats itemStats;
    public int value;
    public int min;
    public int max;
    public ItemValues(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValues();
    }
    public void GenerateValues()
    {
        value = Random.Range(min, max);
    }
}