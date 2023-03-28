using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Net Object", menuName = "Inventory system/Items/Net")]
public class NetObject : ItemObject
{
    public float netCatchRate;

    public int maxFishCatched;

    private void Awake()
    {
        type = InGameItemType.Net;
    }
}
