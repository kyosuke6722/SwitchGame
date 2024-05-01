using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    [SerializeField]
    private float m_bulletSpeed = 100.0f;

    [SerializeField]
    private int m_RefNumber = 2;

    private int m_lifeTime = 0;

    private int m_Max_lifeTime = 400;

    private int m_Refcount = 0;

    private Vector3 m_lastVec;

    private Rigidbody m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();

        m_rb.velocity = transform.forward * m_bulletSpeed;
    }

    void Update()
    {
        //if (m_lifeTime > m_Max_lifeTime)
        //{
        //    Destroy(this.gameObject);
        //    MNozzleController.m_count++;
        //    return;
        //}
        //++m_lifeTime;
        this.m_lastVec=this.m_rb.velocity;
        this.transform.position += transform.forward * m_bulletSpeed;
    }

    private void OnCollisionEnter(Collision col)
    {
        m_Refcount++;
        if (m_Refcount == m_RefNumber||col.gameObject.tag=="Bullet")
        {
            Destroy(this.gameObject);
            MNozzleController.m_count++;
        }

        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }

        Vector3 m_refrectVec = Vector3.Reflect(this.m_lastVec, col.contacts[0].normal);
        this.m_rb.velocity = m_refrectVec;

        transform.LookAt(this.transform.position + m_refrectVec);
    }
}
