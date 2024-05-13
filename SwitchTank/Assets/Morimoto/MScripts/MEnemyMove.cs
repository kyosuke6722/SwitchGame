using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MEnemyMove : MonoBehaviour
{
    [SerializeField]
    public Transform m_player = null;

    private NavMeshAgent agent = null;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //agent.SetDestination(m_player.transform.position);
        agent.destination = m_player.transform.position;
    }
}
