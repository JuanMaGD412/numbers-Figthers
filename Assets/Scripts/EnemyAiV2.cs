using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiV2 : MonoBehaviour
{
    public Transform player;
    public float visionDistance = 20f;
    public float shootDistance = 10f;
    public float coverSearchRadius = 15f;
    public LayerMask coverLayer;
    public float fireRate = 1f;

    private NavMeshAgent agent;
    private float nextFireTime;
    public bool inCover = false;
    public GameObject proyectil;
    public Transform puntoDisparo;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (CanSeePlayer()) 
        {
            if (!inCover && PlayeranSeeMe1())
            {
                FindCover1();
            }
            else
            {
                agent.isStopped = true;
                Shoot1();
            }
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }

    bool CanSeePlayer()
    {
        Ray ray = new Ray(transform.position + Vector3.up, (player.position - transform.position).normalized);

        if (Physics.Raycast(ray, out RaycastHit hit, visionDistance))
        {
            if (hit.transform == player)
            {
                return true;
            }
        }

        return false;
    }

    bool PlayeranSeeMe1()
    {
        Ray ray = new Ray(player.position + Vector3.up, (transform.position - player.position).normalized);

        if (Physics.Raycast(ray, out RaycastHit hit, visionDistance))
        {
            if (hit.transform == transform)
            {
                return true;
            }
        }

        return false;
    }

    void FindCover1()
    {
        Collider[] covers = Physics.OverlapSphere(transform.position, coverSearchRadius, coverLayer);   

        foreach (Collider cover in covers)
        {
            Vector3 directionToPlayer = (player.position - cover.transform.position).normalized;
            Vector3 coverPosition = cover.transform.position - directionToPlayer;

            if (NavMesh.SamplePosition(coverPosition, out NavMeshHit hit, 2f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
                inCover = true;
                return;
            }
        }
    }

    void LookAtPlayer1()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

        }
    }

    void Shoot1()
    {
        LookAtPlayer1();

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 10f / fireRate;
            Instantiate(proyectil, puntoDisparo.position, puntoDisparo.rotation);
        }
    }
}
