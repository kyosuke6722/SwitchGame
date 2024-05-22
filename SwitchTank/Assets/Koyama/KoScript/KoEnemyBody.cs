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

    //public bool m_isVisibility
    //{
    //    get;
    //    private set;
    //} = true;

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

        //進行方向に障害物が無い
        if (!Physics.Raycast(ray, out hit, dis, ~layerMask))
        {
            //ターゲットまでの距離が近いとき
            if (dis <= m_stopDistance)
            {
                //停止
                m_navMeshAgent.speed = 0;
            }
            else
            {
                //追跡再開
                m_navMeshAgent.speed = m_moveSpeed;
            }
            //視界を遮るものは無い
            //m_isVisibility = true;
        }
        else
        {
            m_navMeshAgent.speed = m_moveSpeed;
            //m_isVisibility = false;
        }

        Debug.DrawRay(this.transform.position, ray.direction*dis);

        m_navMeshAgent.destination = target.position;
    }
}
