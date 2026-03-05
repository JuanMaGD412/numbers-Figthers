using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float visionDistance = 20f;
    public float shootDistance = 10f;
    public float fireRate = 1f;

    private NavMeshAgent agent;
    private float nextFireTime;
    public GameObject proyectil;
    public Transform puntoDisparo;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        agent.SetDestination(player.position);

        if (distance <= visionDistance )
        {
            if (CanSeePlayer())
            {
                agent.isStopped = true;
                Shoot();
            }
            else
            {
                
                agent.isStopped = false;
            }
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

    void LookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

        }
    }

    void Shoot()
    {
        LookAtPlayer();

        if ( Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 10f / fireRate;
            Instantiate(proyectil, puntoDisparo.position, puntoDisparo.rotation);
        }
    }
}
