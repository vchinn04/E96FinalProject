using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
