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
    public GameObject prefab;

    public InGameItemType type;

    [TextArea(15, 20)]
    public string description;
}
