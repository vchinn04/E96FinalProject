using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCollision : MonoBehaviour
{
    void Start()
    {
    }

    public bool CheckCollision(UnityEngine.Vector2 dir, float dist, GameObject center)
    {
        RaycastHit2D[] hit;
        center.layer = LayerMask.NameToLayer("Ignore Raycast");
        hit = Physics2D.RaycastAll(center.transform.position, dir, dist);
        center.layer = LayerMask.NameToLayer("Default");

        for (int i = 0; i < hit.Length; i++)
        {
            RaycastHit2D hit_obj = hit[i];
            SpriteRenderer s = null;
            TilemapRenderer t = null;

            try
            {
                t = hit_obj.collider.gameObject.GetComponent<TilemapRenderer>();
            } catch { }

            try
            {
                s = hit_obj.collider.gameObject.GetComponent<SpriteRenderer>();
            } catch { }

  
            if ((t != null && t.enabled) || (s != null && s.enabled))
            {
                return (hit_obj.collider != null);
            } 
        }

        return false;
    }

}
