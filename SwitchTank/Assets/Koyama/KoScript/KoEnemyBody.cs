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
    //追跡を中止する距離
    [SerializeField]
    private float m_stopDistance = 5.0f;

    private NavMeshAgent m_navMeshAgent = null;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        //NavMeshAgentコンポーネントを取得
        if (TryGetComponent(out m_navMeshAgent))
        {
            //Agentの移動速度を設定
            m_navMeshAgent.speed = m_moveSpeed;

            //最初の目標地点を設定
            m_navMeshAgent.SetDestination(target.position);
        }
    }

    void Update()
    {
        if (target == null || m_navMeshAgent == null) return;

        //ターゲットと自身の間に障害物(プレイヤー以外のオブジェクト)があるかどうかを判定
        Vector3 vec = target.position - this.transform.position;
        float dis = vec.magnitude;
        Ray ray = new Ray(this.transform.position,vec);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Player");

        //障害物が無ければ
        if (!Physics.Raycast(ray, out hit, dis, ~layerMask)&& dis <= m_stopDistance)
        {
            //ターゲットとの距離が近いとき
                m_navMeshAgent.speed = 0;
        }
        else
        {
            m_navMeshAgent.speed = m_moveSpeed;
        }

        Debug.DrawRay(this.transform.position, ray.direction*dis);

        m_navMeshAgent.destination = target.position;
    }
}
