using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish Object", menuName = "Inventory system/Items/Fish")]
public class FishObject : ItemObject
{
    public float catchChange;

    public int sellValue;

    private void Awake()
    {
        type = InGameItemType.Fish;
    }
}
