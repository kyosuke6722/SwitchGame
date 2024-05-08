using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerControllerVS : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 0.01f;

    private Camera m_mainCamera = null;
    private Rigidbody m_rigidbody = null;

    [SerializeField]
    private int m_player = 1;

    private float velocity = 0.05f;

    [SerializeField]
    private float max_speed = 0.06f;

    //������
    private float m_RightKeyInput = 0f;
    private float m_LeftKeyInput = 0f;
    //�c����
    private float m_ForwardKeyInput = 0f;
    private float m_BackKeyInput = 0f;

    private void Awake()
    {
        m_mainCamera = Camera.main;
        //Rigidbody�R���|�[�l���g���擾
        m_rigidbody = GetComponent<Rigidbody>();
    }

    //�ړ������x�N�g�����Z�o
    private Vector3 CalcMoveDir(float moveX, float moveZ)
    {
        //�w�肳�ꂽ�ړ��l����ړ��x�N�g�������߂�
        Vector3 moveVec = new Vector3(moveX, 0f, moveZ).normalized;

        //�J�����̌����ɍ��킹�Ĉړ�����x�N�g���ɕϊ����āA�Ԃ�
        Vector3 moveDir = m_mainCamera.transform.rotation * moveVec;
        moveDir.y = 0f;
        return moveDir.normalized;
    }

    private void Update()
    {
        switch (m_player)
        {
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(0,0, velocity);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(0, 0, velocity);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(velocity,0,0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(velocity, 0, 0);
                }
            break;
            case 2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(0, 0, velocity);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(0, 0, velocity);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(velocity, 0, 0);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(velocity, 0, 0);
                }
            break;
        }
    }
}
