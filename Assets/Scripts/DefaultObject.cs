using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory system/Items/default")]
public class DefaultObject : ItemObject
{
    private void Awake()
    {
        type = InGameItemType.Default;
    }
}
