using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMajor : MonoBehaviour
{
    [SerializeField] string Major;
    bool picked_up = false;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        PickupManager pickup_manager = collision.gameObject.GetComponent<PickupManager>();

        if (pickup_manager != null)
        {
            picked_up = true;
            pickup_manager.PickupMajor(Major);
            Destroy(transform.gameObject);
        }
    }

}
