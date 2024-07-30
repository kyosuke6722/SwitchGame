using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KoEnemyLandmine : MonoBehaviour
{
    private KoEnemyManager enemyManager;

    //移動速度
    [SerializeField]
    private float m_moveSpeed = 1.0f;
    [SerializeField]
    private float m_wanderRadius = 5.0f;
    //方向転換するまでの時間
    [SerializeField]
    private float m_wanderCnt = 5.0f;

    private NavMeshAgent m_navMeshAgent;
    private float m_cnt;

    void Start()
    {
        enemyManager = FindAnyObjectByType<KoEnemyManager>();
        enemyManager.AddEnemy(gameObject);

        //NavMeshAgentコンポーネントを取得
        if (TryGetComponent(out m_navMeshAgent))
        {
            //Agentの移動速度を設定
            m_navMeshAgent.speed = m_moveSpeed;
        }
        m_cnt = m_wanderCnt;
    }

    void Update()
    {
        m_cnt += Time.deltaTime;

        if (m_cnt > m_wanderCnt)
        {
            Vector3 newPos = RandomNavSphere(transform.position, m_moveSpeed, -1);
            m_navMeshAgent.SetDestination(newPos);
            m_cnt = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float speed, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * speed;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, speed, layermask);
        return navHit.position;
    }

    private void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.RemoveEnemy(gameObject);
        }
    }
}
