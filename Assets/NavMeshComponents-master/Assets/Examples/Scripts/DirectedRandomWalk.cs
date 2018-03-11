using UnityEngine;
using UnityEngine.AI;

// Walk to a random position and repeat
[RequireComponent(typeof(NavMeshAgent))]
public class DirectedRandomWalk : MonoBehaviour
{
    public float m_Range = 25.0f;
    
    public Vector3 target = new Vector3(0,0,0);
    public float speed = 1f;
    NavMeshAgent m_agent;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (m_agent.pathPending || m_agent.remainingDistance > 0.1f)
            return;
        target = 
        m_agent.destination = m_Range * Random.insideUnitCircle;
        m_agent.destination += (target-transform.position).normalized*speed;
    }
}
