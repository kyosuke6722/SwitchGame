using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MNozzleController : MonoBehaviour
{
    [SerializeField]
    private float m_rotationSpeed = 0.1f;

    [SerializeField]
    private GameObject m_bullet;

    [SerializeField]
    private GameObject m_core;

    private float m_angle;

    public static int m_count = 5;

    private void Update()
    {
        if (m_angle < 0.4f) m_angle += m_rotationSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
    }
}
