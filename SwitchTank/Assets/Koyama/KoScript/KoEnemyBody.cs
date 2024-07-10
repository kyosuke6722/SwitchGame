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
    private Transform target;
    //�ǐՂ𒆎~���鋗��
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

        //NavMeshAgent�R���|�[�l���g���擾
        if (TryGetComponent(out m_navMeshAgent))
        {
            //Agent�̈ړ����x��ݒ�
            m_navMeshAgent.speed = m_moveSpeed;

            if (target)
            {
                //�ŏ��̖ڕW�n�_��ݒ�
                m_navMeshAgent.SetDestination(target.position);
            }
        }
    }

    void Update()
    {
        if (target == null) return;

        m_Visibility = true;

        //�^�[�Q�b�g�Ǝ��g�̊Ԃɏ�Q��(�v���C���[�ȊO�̃I�u�W�F�N�g)�����邩�ǂ����𔻒�
        Vector3 vec = target.position - this.transform.position;
        float dis = vec.magnitude;
        Ray ray = new Ray(this.transform.position, vec);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Player");

        //�i�s�����ɏ�Q��������
        if (!Physics.Raycast(ray, out hit, dis, ~layerMask))
        {
            if (m_navMeshAgent)
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
            }
        }
        else
        {
            //�󂹂�ǈȊO�̏�Q��������Ύ��E�͎Ղ���
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
