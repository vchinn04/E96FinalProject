using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    (string, int)[] item_list =
    {
        ("Nut", 0),
        ("Spring", 0),
        ("Bolt", 0),
        ("Tire", 0),
        ("Key", 0)
    };
    //int[] item_count = new int[5];
    // Start is called before the first frame update

    public (string, int)[] GetItems()
    {
        return item_list;
    }

    public void AddItem(string item)
    {
        for (int i = 0; i < item_list.Length; i++)
        {
            string item_name = item_list[i].Item1;
            if (String.Compare(item_name, item) == 0)
            {
                item_list[i].Item2 += 1;
                Debug.Log("ADDED: ");
                Debug.Log(item_list[i].Item1);
                Debug.Log(item_list[i].Item2);
                return;
            }
        }
        return;
    }

    public void RemoveItem(string item)
    {
        for (int i = 0; i < item_list.Length; i++)
        {
            string item_name = item_list[i].Item1;
            if (String.Compare(item_name, item) == 0)
            {
                item_list[i].Item2 -= 1;
                if (item_list[i].Item2 < 0)
                    item_list[i].Item2 = 0;

                return;
            }
        }
        return;
    }

    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        
    }
}
