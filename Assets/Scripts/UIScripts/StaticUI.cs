using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//this scritp here handles the equiped items inventory. 
public class StaticUI : UserUI
{
    //we make array of the equipment slots 
    public GameObject[] slots;
    public override void CreateSlots()
    {
        //Make new itemsDisplayed Dictionary for this inventory just to make sure nothing funky happens 
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.items.Length; i++)
        {
            //each loop we take one of the item slots set up in the editor and add all these events to it 
            var obj = slots[i];

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            //we last but not least we add the slot to the newly created dictionary that is only available for this script. 
            itemsDisplayed.Add(obj, inventory.Container.items[i]);
        }
    }
}
