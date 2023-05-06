using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory system/Inventory/Default")]
public class InventoryObject : ScriptableObject
{ 
    public string savePath;
    [SerializeField]
    public ItemDataBaseObject database;
    public Inventory Container;


    //As the function name says this adds item to the inventory slots 
    public void AddItem(Item _item, int _amount)
    {
        if (_item.itemValues.Length > 0)
        {
            SetFirstEmptySlot(_item, _amount);
            return; 
        }

        for (int i = 0; i < Container.items.Length; i++)
        {
            if (Container.items[i].ID == _item.Id)
            {
                Container.items[i].AddAmount(_amount);
                return;
            }
        }
        SetFirstEmptySlot(_item, _amount);
    }


    //this makes temporary item slots for when you swap 2 items to each other slots even if one of the slots is empty. 
    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount);
        item1.UpdateSlot(temp.ID, temp.item, temp.amount);
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Container.items.Length; i++)
        {
            if(Container.items[i].item == _item)
            {
                Container.items[i].UpdateSlot(-1, null, 0);
            }
        }
    }

    public InventorySlot SetFirstEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < Container.items.Length; i++)
        {
            if (Container.items[i].ID <= -1)
            {
                Container.items[i].UpdateSlot(_item.Id, _item, _amount);
                return Container.items[i];
            }
        }
        //Still missing inventory full functionality. 
        return null;
    }
#region "save and Load"
    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }
 
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();


            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < Container.items.Length; i++)
            {
                Container.items[i].UpdateSlot(newContainer.items[i].ID, newContainer.items[i].item, newContainer.items[i].amount);
            }
            stream.Close();
        }
    }
    #endregion
    //clears your inventory this is here if needed
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container.Clear();
    }

}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] items = new InventorySlot[12];

    public void Clear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].UpdateSlot(-1, new Item(), 0);
        }
    }
}


#region "IventorySlot"
[System.Serializable]
public class InventorySlot
{
    public InGameItemType[] allowedItems = new InGameItemType[0];
    public int ID = -1;
    public Item item;
    public int amount;
    public UserUI parent;

    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }
    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public bool CanPlaceInSlot(ItemObject _item)
    {
        if(allowedItems.Length <= 0)
        {
            return true;
        }
        for (int i = 0; i < allowedItems.Length; i++)
        {
            if (_item.type == allowedItems[i])
                return true;
        }
        return false;
    }
}
#endregion