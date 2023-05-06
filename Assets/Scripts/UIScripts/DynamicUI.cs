using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//this script handles the player inventory
public class DynamicUI : UserUI
{
    //this is the prefab for the inventory object 
    public GameObject inventoryPrefab;


    //these controll the location of inventory slots with in your inventory. 
    [SerializeField]
    private int startX, StartY;
    [SerializeField, Range(1, 100)]
    private int spaceBetweenItemX, spaceBetweenItemY;
    public int numberOfColums;


    public override void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });


            itemsDisplayed.Add(obj, inventory.Container.items[i]);
        }
    }
    //sets positions for the items with in the inventory 
    private Vector3 GetPosition(int i)
    {
        return new Vector3(startX + (spaceBetweenItemX * (i % numberOfColums)), StartY + ((-spaceBetweenItemY * (i / numberOfColums))), 0f);
    }
}
