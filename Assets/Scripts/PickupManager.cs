using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    MajorManager major_manager;
    PlayerInventory inventory;

    public void Pickup(string item)
    {
        inventory.AddItem(item);
        Debug.Log(tag);
    }

    public (string, int) GetItem(string item)
    {
        return inventory.GetItem(item);
    }

    public void RemoveItem(string item, int amount = 1)
    {
        inventory.RemoveItem(item, amount);
    }

    public void PickupMajor(string major)
    {
        major_manager.AddMajor(major);
    }
    // Start is called before the first frame update
    void Start()
    {
        major_manager = GameObject.Find("MajorManager").GetComponent<MajorManager>();
        inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
