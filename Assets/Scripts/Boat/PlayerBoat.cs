using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBoat : MonoBehaviour
{
    public InventoryObject inventory;

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

    public void OnSave()
    {
        //This line is for testing purposes 
        Debug.Log("Inventory Saved" + inventory.savePath);
        inventory.Save();
    }
    public void OnLoad(InputAction button)
    {
        inventory.Load(); 

    }


    //This piece of code simply clears the inventory when you restart the game not really good for testing purposes if you ask from me :)
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}

