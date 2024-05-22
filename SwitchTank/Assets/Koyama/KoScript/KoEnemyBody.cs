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
    //�ǐՂ𒆎~���鋗��
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

        //NavMeshAgent�R���|�[�l���g���擾
        if (TryGetComponent(out m_navMeshAgent))
        {
            //Agent�̈ړ����x��ݒ�
            m_navMeshAgent.speed = m_moveSpeed;

            //�ŏ��̖ڕW�n�_��ݒ�
            m_navMeshAgent.SetDestination(target.position);
        }
    }

    void Update()
    {
        if (target == null || m_navMeshAgent == null) return;

        //�^�[�Q�b�g�Ǝ��g�̊Ԃɏ�Q��(�v���C���[�ȊO�̃I�u�W�F�N�g)�����邩�ǂ����𔻒�
        Vector3 vec = target.position - this.transform.position;
        float dis = vec.magnitude;
        Ray ray = new Ray(this.transform.position,vec);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Player");

        //�i�s�����ɏ�Q��������
        if (!Physics.Raycast(ray, out hit, dis, ~layerMask))
        {
            //�^�[�Q�b�g�܂ł̋������߂��Ƃ�
            if (dis <= m_stopDistance)
            {
                //��~
                m_navMeshAgent.speed = 0;
            }
            else
            {
                //�ǐՍĊJ
                m_navMeshAgent.speed = m_moveSpeed;
            }
            //���E���Ղ���͖̂���
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
