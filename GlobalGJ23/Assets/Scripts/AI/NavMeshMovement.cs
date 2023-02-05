using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float stoppingDistance;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        agent.stoppingDistance = stoppingDistance;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
