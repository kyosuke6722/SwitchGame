using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KoEnemyBody : MonoBehaviour
{
    //�ړ����x
    [SerializeField]
    private float m_moveSpeed = 1.0f;

    private Rigidbody m_rigidbody = null;

    //�ǐՑΏ�
    public Transform target;

    private NavMeshAgent m_navMeshAgent=null;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        
        //NavMeshAgent�R���|�[�l���g���擾
        if(TryGetComponent(out m_navMeshAgent))
        {
            //Agent�̈ړ����x��ݒ�
            m_navMeshAgent.speed = m_moveSpeed;

            //�ŏ��̖ڕW�n�_��ݒ�
            m_navMeshAgent.SetDestination(target.position);
        }
    }

    void Update()
    {
        if (target == null||m_navMeshAgent==null) return;

        //�v���C���[��ǂ�������
        //transform.position = Vector3.MoveTowards
        //    (transform.position,
        //    new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z),
        //    m_moveSpeed * Time.deltaTime);

        m_navMeshAgent.destination = target.position;
    }
}
