using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New FishingRod Object", menuName = "Inventory system/Items/FishingRod")]
public class FishingRodObject : ItemObject
{
    public float catchChangeModifier;

    public float catchSpeed;

    private void Awake()
    {
        type = InGameItemType.FishingRod;
    }
}
