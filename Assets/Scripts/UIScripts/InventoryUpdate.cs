using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUpdate : MonoBehaviour
{

    public GameObject inventoryPrefab;
    public InventoryObject inventory;

    [SerializeField]
    private int startX, StartY;

    [SerializeField, Range(1, 100)]
    private int spaceBetweenItemX, spaceBetweenItemY;

    public int numberOfColums;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }


    //Updates the display when game is running 
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.items.Count; i++)
        {
            InventorySlot slot = inventory.Container.items[i];
            if (itemsDisplayed.ContainsKey(slot))
            {
                itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container.items[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].UISprite;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                itemsDisplayed.Add(slot, obj);

            }
        }

    }


    //Creates a display for the inventory when it is loaded

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.items.Count; i++)
        {

            InventorySlot slot = inventory.Container.items[i];

            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].UISprite;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            itemsDisplayed.Add(slot, obj);
        }


    }

    //sets positions for the items with in the inventory 
    public Vector3 GetPosition(int i)
    {
        return new Vector3(startX + (spaceBetweenItemX * (i % numberOfColums)), StartY + ((-spaceBetweenItemY * (i / numberOfColums))), 0f);
    }

}
