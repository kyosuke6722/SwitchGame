using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KoEnemyBody : MonoBehaviour
{
    //移動速度
    [SerializeField]
    private float m_moveSpeed = 1.0f;

    private Rigidbody m_rigidbody = null;

    //追跡対象
    public Transform target;

    private NavMeshAgent m_navMeshAgent=null;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        
        //NavMeshAgentコンポーネントを取得
        if(TryGetComponent(out m_navMeshAgent))
        {
            //Agentの移動速度を設定
            m_navMeshAgent.speed = m_moveSpeed;

            //最初の目標地点を設定
            m_navMeshAgent.SetDestination(target.position);
        }
    }

    void Update()
    {
        if (target == null||m_navMeshAgent==null) return;

        //プレイヤーを追いかける
        //transform.position = Vector3.MoveTowards
        //    (transform.position,
        //    new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z),
        //    m_moveSpeed * Time.deltaTime);

        m_navMeshAgent.destination = target.position;
    }
}
