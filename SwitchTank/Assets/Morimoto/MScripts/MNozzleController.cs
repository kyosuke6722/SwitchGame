using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MNozzleController : MonoBehaviour
{
    [SerializeField]
    private float m_rotationSpeed = 0.1f;

    private float m_angle;

    private void Update()
    {
        if (m_angle < 0.6f) m_angle += m_rotationSpeed * Time.deltaTime;
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
    }
}
