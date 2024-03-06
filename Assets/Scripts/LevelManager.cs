using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    bool locked = true;

    public void Unlock()
    {
        Debug.Log("Unlocked!");
        locked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupManager pickup_manager = collision.gameObject.GetComponent<PickupManager>();

        if (!locked && pickup_manager != null)
        {
            Debug.Log("Next Level!");
            int cur_scene_num = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(cur_scene_num + 1);
        }
    }
}
