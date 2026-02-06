using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float stoppingDistance = 5f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float sightRange = 15f;

    private NavMeshAgent agent;
    private Transform player;
    private Transform waypointOne;
    private Transform waypointTwo;
    private Transform currentPoint;
    private float timePassed;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        waypointOne = GameObject.FindGameObjectWithTag("waypointOne").transform;
        waypointTwo = GameObject.FindGameObjectWithTag("waypointTwo").transform;
        currentPoint = waypointOne;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit sight;
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 0.1f);
        if (Physics.Raycast(transform.position, transform.forward, out sight, sightRange))
        {
            if (sight.collider.CompareTag("Player"))
            {
                Move(player);
            }
        }
        
        if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
        {
            Attack();
        }
        else
        {
            Patrol();
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

    private void Move(Transform target)
    {
        agent.SetDestination(target.position);
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, currentPoint.position) <= agent.stoppingDistance)
        {
            Sweep();
            
        } else
        {
            Move(currentPoint);
        }
    }

    private void Sweep()
    {
        transform.Rotate(Vector3.up * 65f * Time.deltaTime);
        timePassed += Time.deltaTime;
        if (timePassed >= 7f)
        {
            if (currentPoint == waypointOne)
            {
                currentPoint = waypointTwo;
            }
            else
            {
                currentPoint = waypointOne;
            }
            timePassed = 0;
        }
    }
}
