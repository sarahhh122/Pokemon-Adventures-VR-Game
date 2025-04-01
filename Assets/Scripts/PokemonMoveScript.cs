using UnityEngine;
using UnityEngine.AI;

public class PokemonMoveScript : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;
    public float smoothingFactor = 5f;  

    private NavMeshAgent agent;
    private float timer;
    private Animator animator;

    // Start
   void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
        float currentSpeed = agent.velocity.magnitude;
        float smoothSpeed = Mathf.Lerp(animator.GetFloat("Speed"), currentSpeed, Time.deltaTime * smoothingFactor);
        
        if(animator != null)
        {
            animator.SetFloat("Speed", smoothSpeed);
        }
    
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
