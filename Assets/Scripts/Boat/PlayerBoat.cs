using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBoat : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;
    public InputAction playerControls;
    [SerializeField]
    private Rigidbody rb;

    private Vector2 moveDicrection;
    private float movespeed = 10;

    private void OnEnable() => playerControls.Enable();

    private void OnDisable() => playerControls.Disable();

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
        moveDicrection = playerControls.ReadValue<Vector2>();
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Inventory Saved" + inventory.savePath);
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("inventory Loaded");
            inventory.Load();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDicrection.x * movespeed, 0, moveDicrection.y * movespeed);
    }

    //This piece of code simply clears the inventory when you restart the game not really good for testing purposes if you ask from me :)
    private void OnApplicationQuit()
    {
        inventory.Container.items = new InventorySlot[12]; 
    }
}

