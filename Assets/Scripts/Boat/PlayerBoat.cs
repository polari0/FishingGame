using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBoat : MonoBehaviour
{
    public InventoryObject inventory;
    //PlayerInputsSave playerInput;

    //private InputAction save;
    //private InputAction load;



    private void Awake()
    {
        //playerInput = new PlayerInputsSave();
    }

    private void OnEnable()
    {
        //save = playerInput.PlayerInputs.Save;
        //load = playerInput.PlayerInputs.Load;
    }


    private void OnDisable()
    {
        //save.Disable();
        //load.Disable();
    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Inventory Saved" + inventory.savePath);
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
        }
    }
    //This piece of code simply clears the inventory when you restart the game not really good for testing purposes if you ask from me :)
    private void OnApplicationQuit()
    {
        inventory.Container.items.Clear();
    }
}

