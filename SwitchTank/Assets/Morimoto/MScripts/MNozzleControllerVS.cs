using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MNozzleControllerVS : MonoBehaviour
{
    [SerializeField]
    private float m_rotationSpeed = 0.1f;

    [SerializeField]
    private GameObject m_bullet;

    [SerializeField]
    private GameObject m_core;

    [SerializeField]
    private int m_player = 1;

    private float m_angle;

    private int m_time = 0;

    public static int m_count = 5;

    public static int m_countVS = 5;

    private void Update()
    {
        m_time++;
        switch (m_player)
        {
            case 1:
                if (m_angle < 0.4f) m_angle += m_rotationSpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftShift))
                {

                }
                if (Input.GetKey(KeyCode.Q))
                {
                    this.transform.Rotate(new Vector3(0f, -m_angle, 0f));
                }
                if (Input.GetKey(KeyCode.E))
                {
                    this.transform.Rotate(new Vector3(0f, m_angle, 0f));
                }
                if (Input.GetKeyDown(KeyCode.R))
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
            case 2:
                if (m_angle < 0.4f) m_angle += m_rotationSpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.RightShift))
                {
                    this.transform.Rotate(new Vector3(0f, -m_angle, 0f));
                }
                if (Input.GetKey(KeyCode.End))
                {
                    this.transform.Rotate(new Vector3(0f, m_angle, 0f));
                }
                if (Input.GetKeyDown(KeyCode.Backslash))//]
                {
                    if (m_countVS > 0)
                    {
                        m_countVS--;
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
        }
    }
}

