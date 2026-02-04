using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float stoppingDistance = 5f;
    [SerializeField] private float attackRange = 5f;

    private NavMeshAgent agent;
    private Transform player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
        {
            Attack();
        } else
        {
            Move();
        }
    }

    void Attack()
    {
        transform.LookAt(player);

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 0.1f);
        if(Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Hit!");
            }
        }
    }

    private void Move()
    {
        agent.SetDestination(player.position);
    }
}
