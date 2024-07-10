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
    private Transform target;
    //追跡を中止する距離
    public float m_stopDistance = 5.0f;

    private NavMeshAgent m_navMeshAgent = null;

    private bool m_Visibility=false;

    public bool GetVisibility()
    {
        return m_Visibility;
    }

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        //NavMeshAgentコンポーネントを取得
        if (TryGetComponent(out m_navMeshAgent))
        {
            //Agentの移動速度を設定
            m_navMeshAgent.speed = m_moveSpeed;

            if (target)
            {
                //最初の目標地点を設定
                m_navMeshAgent.SetDestination(target.position);
            }
        }
    }

    void Update()
    {
        if (target == null) return;

        m_Visibility = true;

        //ターゲットと自身の間に障害物(プレイヤー以外のオブジェクト)があるかどうかを判定
        Vector3 vec = target.position - this.transform.position;
        float dis = vec.magnitude;
        Ray ray = new Ray(this.transform.position, vec);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Player");

        //進行方向に障害物が無い
        if (!Physics.Raycast(ray, out hit, dis, ~layerMask))
        {
            if (m_navMeshAgent)
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
            }
        }
        else
        {
            //壊せる壁以外の障害物があれば視界は遮られる
            if (hit.collider.tag != "DestroyWall")
                m_Visibility = false;
            if (m_navMeshAgent)
                m_navMeshAgent.speed = m_moveSpeed;
        }

        Debug.DrawRay(this.transform.position, ray.direction * dis);

        if (m_navMeshAgent&&target)
            m_navMeshAgent.destination = target.position;
    }
}
