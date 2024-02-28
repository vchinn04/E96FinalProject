using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 1;
    private Transform target;
    private void Update() {
        if (target != null) {
            float step = speed* Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
/*    private void OnCollisionStay2D(Collision2D other) {
        Debug.Log("Help");
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
*/
    private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.tag == "Player") {
                target = other.transform;
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                Debug.Log("target");
            }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            target = other.transform;
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Debug.Log("target");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            target = null;
        }
    }
}
