using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Rendering;
using UnityEngine;

public class MNozzleControllerVS : MonoBehaviour
{
    [SerializeField]
    private float m_rotationSpeed = 3f;

    [SerializeField]
    private GameObject m_bullet;

    [SerializeField]
    private GameObject m_core;

    [SerializeField]
    private int m_player = 1;

    private float m_intervaltime = 0.1f;
    private float m_interval = 0.0f;


    private float m_angle;

    private int m_time = 0;

    public static int m_count = 0;

    public static int m_countVS = 0;
    
    public MPFT_NTD_MMControlSystem m_controlSystem = null;

    private void Start()
    {
        m_count = 5;
        m_countVS = 5;
        //MPFT_NTD_MMControlSystem m_controlSystem;
    }

    private void Update()
    {
        m_interval -= Time.deltaTime;
        m_time++;
        switch (m_player)
        {
            case 1:
                if (m_angle < 0.4f) m_angle += m_rotationSpeed;
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftShift))
                {

                }
                if (Input.GetKey(KeyCode.Q) || m_controlSystem.MMGamePad[1].MM_Up_B)
                {
                    this.transform.Rotate(new Vector3(0f, -m_angle, 0f));
                }
                if (Input.GetKey(KeyCode.E) || m_controlSystem.MMGamePad[1].MM_Down_X)
                {
                    this.transform.Rotate(new Vector3(0f, m_angle, 0f));
                }
                if (Input.GetKeyDown(KeyCode.R) || m_controlSystem.MMGamePad[1].MM_Right_A)
                {
                    if (m_count > 0 && m_interval < 0.0f && m_count <= Mzandan.m_maxP1bullet)
                    {
                        m_count--;
                        Mzandan.m_isP1Shot = true;
                        Instantiate
                            (
                                m_bullet,
                                m_core.transform.position,
                                this.transform.rotation
                            );
                        m_bullet.transform.forward = this.transform.forward;
                        m_interval = m_intervaltime;
                    }
                }
                break;
            case 2:
                if (m_angle < 0.4f) m_angle += m_rotationSpeed;
                if (Input.GetKey(KeyCode.RightShift) || m_controlSystem.MMGamePad[2].MM_Up_B)
                {
                    this.transform.Rotate(new Vector3(0f, -m_angle, 0f));
                }
                if (Input.GetKey(KeyCode.End) || m_controlSystem.MMGamePad[2].MM_Down_X)
                {
                    this.transform.Rotate(new Vector3(0f, m_angle, 0f));
                }
                if (Input.GetKeyDown(KeyCode.Backslash) || m_controlSystem.MMGamePad[2].MM_Left_Y)//]
                {
                    if (m_countVS > 0 && m_interval < 0.0f && m_count <= Mzandan.m_maxP2bullet)
                    {
                        m_countVS--;
                        Mzandan.m_isP2Shot = true;
                        Instantiate
                            (
                                m_bullet,
                                m_core.transform.position,
                                this.transform.rotation
                            );
                        m_bullet.transform.forward = this.transform.forward;
                        m_interval = m_intervaltime;
                    }
                }
                break;
            case 3:
                if (m_time%600==0)//]
                {
                    if (m_count > 0)
                    {
                        m_count--;
                        Instantiate
                            (
                                m_bullet,
                                m_core.transform.position,
                                this.transform.rotation
                            );
                        m_bullet.transform.forward = this.transform.forward;
                    }
                }
                break;
            case 4:
                if (m_angle < 0.4f) m_angle += m_rotationSpeed;
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftShift))
                {

                }
                if (Input.GetKey(KeyCode.Q) || m_controlSystem.SGGamePad.MM_UTL)
                {
                    this.transform.Rotate(new Vector3(0f, -m_angle, 0f));
                }
                if (Input.GetKey(KeyCode.E) || m_controlSystem.SGGamePad.MM_UTR)
                {
                    this.transform.Rotate(new Vector3(0f, m_angle, 0f));
                }
                if (Input.GetKeyDown(KeyCode.R) || m_controlSystem.SGGamePad.A)
                {
                    if (m_count > 0 && m_interval < 0.0f)
                    {
                        m_count--;
                        Instantiate
                            (
                                m_bullet,
                                m_core.transform.position,
                                this.transform.rotation
                            );
                        m_bullet.transform.forward = this.transform.forward;
                    }
                    m_interval = m_intervaltime;
                }
                break;
        }
    }
}

