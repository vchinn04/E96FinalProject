using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherObject : MonoBehaviour
{
    (string, int)[] required_items =
   {
        ("Nut", 1),
        ("Spring", 1),
        ("Bolt", 1),
        ("Tire", 1),
    };

    bool picked_up = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupManager pickup_manager = collision.gameObject.GetComponent<PickupManager>();

        if (pickup_manager != null)
        {
            for (int i = 0; i < required_items.Length; i++)
            {
                (string, int) req_item = required_items[i];
                (string, int) plr_item = pickup_manager.GetItem(req_item.Item1);

                if (req_item.Item2 > plr_item.Item2)
                {
                    Debug.Log("ITEM MISSING: ");
                    Debug.Log(req_item.Item1);
                    return;
                }
            }

            Debug.Log("All items there!");
            for (int i = 0; i < required_items.Length; i++)
            {
                (string, int) req_item = required_items[i];
                pickup_manager.RemoveItem(req_item.Item1, req_item.Item2);
            }
        }
    }
}
