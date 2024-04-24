using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoPlayer : MonoBehaviour
{
    //�ړ����x
    [SerializeField]
    private float m_moveSpeed = 2.0f;

    //�ړ��p����������
    private float m_horizontalKeyInput = 0.0f;
    //�ړ��p�c��������
    private float m_verticalKeyInput = 0.0f;

    private Camera m_mainCamera = null;
    private Rigidbody m_rigidbody = null;

    void Start()
    {
        m_mainCamera = Camera.main;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    //�ړ��x�N�g�����Z�o
    private Vector3 CalcMoveDir(float moveX,float moveZ)
    {
        //�w�肳�ꂽ�ړ��l����ړ��x�N�g�������߂�
        Vector3 moveVec = new Vector3(moveX, 0f, moveZ).normalized;

        //�J�����̌����ɍ��킹�Ĉړ�����x�N�g���ɕϊ����ĕԂ�
        Vector3 moveDir = m_mainCamera.transform.rotation * moveVec;
        moveDir.y = 0f;

        return moveDir.normalized;
    }

    private void Update()
    {
        //�ړ��L�[���͎擾
        m_horizontalKeyInput = Input.GetAxis("Horizontal");
        m_verticalKeyInput = Input.GetAxis("Vertical");

        //�ړ��L�[�����͂���Ă��邩
        bool isKeyInput = m_horizontalKeyInput != 0f || m_verticalKeyInput != 0f;
        if(isKeyInput)
        {
            //�v���C���[���ړ������Ɍ�����
            Vector3 moveDir = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput);
            transform.forward = moveDir.normalized;
        }
    }

    private void FixedUpdate()
    {
        //�L�[���͂ɂ��ړ��ʂ����߂�
        Vector3 move = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput) * m_moveSpeed;
        //���݂̈ړ��ʂ��擾
        Vector3 current = m_rigidbody.velocity;
        current.y = 0f;

        //���݂̈ړ��ʂƂ̍��������v���C���[�ɗ͂�������
        m_rigidbody.AddForce(move - current, ForceMode.VelocityChange);
    }
}
