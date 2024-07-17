//using nn.hid;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MPlayerControllerVS : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 3f;

    private Camera m_mainCamera = null;
    private Rigidbody m_rigidbody = null;

    [SerializeField]
    private int m_player = 1;

    [SerializeField]
    private GameObject m_zirai = null;

    private int m_maxp1zirai = 2;
    private int m_maxp2zirai = 2;
    public static int m_p1ziraicnt = 0;
    public static int m_p2ziraicnt = 0;

    private float velocity = 5.0f;

    //[SerializeField]
    //private float max_speed = 10.0f;

    //������
    private float m_RightKeyInput = 0f;
    private float m_LeftKeyInput = 0f;
    //�c����
    private float m_ForwardKeyInput = 0f;
    private float m_BackKeyInput = 0f;

    //�ړ��p����������
    private float m_horizontalKeyInput = 0.0f;
    //�ړ��p�c��������
    private float m_verticalKeyInput = 0.0f;

    //public MPFT_NTD_MMControlSystem m_controlSystem = null;

    private void Awake()
    {
        m_mainCamera = Camera.main;
        //Rigidbody�R���|�[�l���g���擾
        m_rigidbody = GetComponent<Rigidbody>();
        //MPFT_NTD_MMControlSystem m_controlSystem;
        m_maxp1zirai = 2;
        m_maxp2zirai = 2;
        m_p2ziraicnt = 0;
        m_p2ziraicnt = 0;
    }

    //�ړ��x�N�g�����Z�o
    private Vector3 CalcMoveDir(float moveX, float moveZ)
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
        switch (m_player)
        {
            case 1:
                //�ړ��L�[���͎擾
                //m_horizontalKeyInput = m_controlSystem.MMGamePad[1].MM_Analog_X;
                //m_verticalKeyInput = m_controlSystem.MMGamePad[1].MM_Analog_Y;
                //m_horizontalKeyInput = Input.GetAxis("Horizontal");
                //m_verticalKeyInput = Input.GetAxis("Vertical");
                break;
            case 2:
                //�ړ��L�[���͎擾
                //m_horizontalKeyInput = m_controlSystem.MMGamePad[2].MM_Analog_X;
                //m_verticalKeyInput = m_controlSystem.MMGamePad[2].MM_Analog_Y;
                //m_horizontalKeyInput = Input.GetAxis("Horizontal");
                //m_verticalKeyInput = Input.GetAxis("Vertical");
                break;
            case 3:
                
                break;
            case 4:
                //�ړ��L�[���͎擾
                //m_horizontalKeyInput = m_controlSystem.SGGamePad.L_Analog_X;
                //m_verticalKeyInput = m_controlSystem.SGGamePad.L_Analog_Y;
                break;
            case 5:
                //Windows�p
                //�ړ��L�[���͎擾
                //if (Input.GetKey(KeyCode.W) || m_controlSystem.MMGamePad[1].MM_Analog_X > 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(0, 0, velocity);
                //}
                //if (Input.GetKey(KeyCode.S) || m_controlSystem.MMGamePad[1].MM_Analog_X < 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(0, 0, -velocity);
                //}
                //if (Input.GetKey(KeyCode.D) || m_controlSystem.MMGamePad[1].MM_Analog_Y < 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(velocity, 0, 0);
                //}
                //if (Input.GetKey(KeyCode.A) || m_controlSystem.MMGamePad[1].MM_Analog_Y > 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(-velocity, 0, 0);
                //}
                //if (Input.GetKeyDown(KeyCode.Mouse1))
                //{
                //    if (m_maxzirai > m_p1ziraicnt)
                //    {
                //        m_p1ziraicnt++;
                //        Instantiate(m_zirai, transform.position, Quaternion.identity);
                //    }
                //}

                m_horizontalKeyInput = Input.GetAxis("GamePad1_L_X");
                m_verticalKeyInput = Input.GetAxis("GamePad1_L_Y");
                if (Input.GetKeyDown("joystick 1 button 2"))
                {
                    if (m_maxp1zirai > m_p1ziraicnt)
                    {
                        m_p1ziraicnt++;
                        Instantiate(m_zirai, transform.position, Quaternion.identity);
                    }
                }
                break;
            case 6:
                //Windows�p
                //�ړ��L�[���͎擾
                //if (Input.GetKey(KeyCode.UpArrow) || m_controlSystem.MMGamePad[2].MM_Analog_X < 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(0, 0, velocity);
                //}
                //if (Input.GetKey(KeyCode.DownArrow) || m_controlSystem.MMGamePad[2].MM_Analog_X > 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(0, 0, -velocity);
                //}
                //if (Input.GetKey(KeyCode.RightArrow) || m_controlSystem.MMGamePad[2].MM_Analog_Y > 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(velocity, 0, 0);
                //}
                //if (Input.GetKey(KeyCode.LeftArrow) || m_controlSystem.MMGamePad[2].MM_Analog_Y < 0.0f)
                //{
                //    m_rigidbody.velocity = new Vector3(-velocity, 0, 0);
                //}
                m_horizontalKeyInput = Input.GetAxis("GamePad2_L_X");
                m_verticalKeyInput = Input.GetAxis("GamePad2_L_Y");
                if (Input.GetKeyDown("joystick 2 button 2"))
                {
                    if (m_maxp2zirai > m_p2ziraicnt)
                    {
                        m_p2ziraicnt++;
                        Instantiate(m_zirai, transform.position, Quaternion.identity);
                    }
                }
                break;
        }
        //�ړ��L�[�����͂���Ă��邩
        bool isKeyInput = m_horizontalKeyInput != 0f || m_verticalKeyInput != 0f;
        if (isKeyInput)
        {
            //�v���C���[���ړ������Ɍ�����
            Vector3 moveDir = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput);
            transform.forward = moveDir.normalized;
        }
    }

    private void FixedUpdate()
    {   
        //Windows�p�R�����g��
        //if (m_player != 5 && m_player != 6)
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
}
