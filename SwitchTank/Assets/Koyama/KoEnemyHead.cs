using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyHead : MonoBehaviour
{
    //�w�b�h�̉�]���x
    [SerializeField]
    private float m_rotateSpeed = 0.02f;
    //�e�̔��˕p�x
    [SerializeField]
    private float m_interval = 5.0f;

    //�^�[�Q�b�g
    public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        //�v���C���[�܂ł̃x�N�g�����Z�o
        Vector3 lookAtPos = target.transform.position;
        Vector3 forward = lookAtPos - transform.parent.position;
        forward.y = 0;
        forward.Normalize();
        //Lerp�֐��ŏ��X�Ƀv���C���[�̕����Ɍ���
        transform.forward += forward*m_rotateSpeed*Time.deltaTime; //= Vector3.Lerp(transform.forward, forward, m_rotateSpeed * Time.deltaTime);
    }
}
