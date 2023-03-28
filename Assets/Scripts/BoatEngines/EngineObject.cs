using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BoatEngine Object", menuName = "Inventory system/Items/BoatEngine")]
public class EngineObject : ItemObject
{
    public int engineSpeed;
    public float engineFuelAmount;

    private void Awake()
    {
        type = InGameItemType.BoatEngine;
    }
}
