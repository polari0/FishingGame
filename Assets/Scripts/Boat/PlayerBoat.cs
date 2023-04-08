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
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
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

    //public void Save(InputAction.CallbackContext context)
    //{
    //    //This line is for testing purposes 
    //    Debug.Log("Inventory Saved" + inventory.savePath);
    //    inventory.Save();
    //}
    //public void Load(InputAction.CallbackContext context)
    //{
    //    inventory.Load(); 
    //}


    //This piece of code simply clears the inventory when you restart the game not really good for testing purposes if you ask from me :)
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}

