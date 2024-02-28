using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

   private int health;
   private int maxHealth = 3;
   private bool dead;
   public GameObject[] hearts;

   void Update() 
   {
       if (dead == true) {
            //Code
       }
   }
   public void Heal(int hp) {

        health += hp;
        if (health > maxHealth) {
            health = maxHealth;
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
   