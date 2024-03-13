// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class PlayerHealth : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

// using UnityEngine;
// using UnityEngine.UI;
//from here
// public class PlayerHealth : MonoBehaviour
// {
//     public int health; // Number of hearts/lives at start
//     public int currentHealth; // Current number of hearts/lives
//     public bool dead;
//     public GameObject[] hearts;// UI images representing hearts


//     void Start()
//     {
//         health = hearts.Length;
//     }

//     void OnTriggerEnter(Collider2D other)
//     {
//         if (other.CompareTag("Enemy")) // Assuming moving objects have a tag "MovingObject"
//         {
//             // Debug.Log("welp");
//             TakeDamage(1); // Reduce health by 1 heart
//         }
//     }

//     void TakeDamage(int amount)
//     {
//         if (!dead && health >= 1)
//         {
//             health -= amount;
//             Destroy(hearts[health].gameObject);

//             if (health < 1)
//             {
//                 dead = true;
//                  // Handle player death here (e.g., play death animation, show game over screen, etc.)
//              }
//          }
//     }

// }
// to here

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerHealth : MonoBehaviour
// {
//    private int health;
//    private bool dead;
//    public GameObject[] hearts;

//    void Update() 
//    {
//        if (dead == true) {
//             //Code
//        }
//    }
//    public void TakeDamage(int d) {
//         if (health >= 1) {
//             health -= d;
//             Destroy(hearts[health].gameObject);
//             if (health < 1) {
//                 dead = true;
//             }
//         }
//    }

// }

using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    private int health;
    private bool dead;
    public GameObject[] hearts;

    void Start()
    {
        health = hearts.Length;
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         
    //         TakeDamage(1); // Assuming the player loses one heart upon collision with a moving object
    //     }
    // }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("dog");
        Debug.Log(other.tag);
        if (other.CompareTag("Enemy")) // Assuming moving objects have a tag "MovingObject"
        {
            Debug.Log("werk?");
            TakeDamage(1); // Reduce health by 1 heart
        }
    }

    public void TakeDamage(int damage)
    {
        if (!dead && health >= 1)
        {
            health -= damage;
            Destroy(hearts[health].gameObject);

            if (health < 1)
            {
                dead = true;
                SceneManager.LoadScene(5);
            }
        }
    }
}
