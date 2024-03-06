using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrop : MonoBehaviour
{
    [SerializeField] string ObjectId;
    bool picked_up = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupManager pickup_manager = collision.gameObject.GetComponent<PickupManager>();

        if (pickup_manager != null)
        {
            picked_up = true;
            pickup_manager.Pickup(ObjectId);
            Destroy(transform.gameObject);
        }
    }

}
