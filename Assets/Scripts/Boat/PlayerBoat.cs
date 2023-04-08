using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBoat : MonoBehaviour
{
    public InputAction playerInputs;
    public InventoryObject inventory;

    [SerializeField]
    InventoryObject inventoryObjecttest;

    //private void OnEnable()
    //{
    //    PlayerInput.Enable();
    //}

    private void OnDisable()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    public void OnInventorySave()
    {
        inventory.Save();
        Debug.Log("inventorySaved" + inventoryObjecttest.savePath);
    }
    public void OnInventoryLoad()
    {
        inventory.Load(); 

    }


    //This piece of code simply clears the inventory when you restart the game not really good for testing purposes if you ask from me :)
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}

