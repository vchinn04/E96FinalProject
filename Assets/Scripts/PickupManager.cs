using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    MajorManager major_manager;
    PlayerInventory inventory;

    public void Pickup(string item, GameObject obj)
    {
        inventory.AddItem(item);
        Debug.Log(tag);
    }

    public void PickupMajor(string major)
    {
        major_manager.AddMajor(major);
    }
    // Start is called before the first frame update
    void Start()
    {
        major_manager = GameObject.Find("Player").GetComponent<MajorManager>();
        inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
