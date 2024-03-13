using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    PlayerHealth ph;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(target.position);
    }



    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            ph.TakeDamage(1);
        }
    }
}
