using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   private int health;
   private bool dead;
   public GameObject[] hearts;

   void Update() 
   {
       if (dead == true) {
            //Code
       }
   }
   public void TakeDamage(int d) {
        if (health >= 1) {
            health -= d;
            Destroy(hearts[health].gameObject);
            if (health < 1) {
                dead = true;
            }
        }
   }

}
   