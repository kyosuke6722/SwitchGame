using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MBulletVS : MonoBehaviour
{
    [SerializeField]
    private float m_bulletSpeed = 0.02f;

    [SerializeField]
    private int m_RefNumber = 2;

    [SerializeField]
    private int m_player = 1;

    [SerializeField]
    private GameObject m_effect;

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
            Instantiate(m_effect, transform.position, Quaternion.identity);
            switch (m_player)
            {
                case 1:
                    MNozzleControllerVS.m_count++;
                    break;
                case 2:
                    MNozzleControllerVS.m_countVS++;
                    break;
            }
        }

        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            Instantiate(m_effect, transform.position, Quaternion.identity);
        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            Instantiate(m_effect, transform.position, Quaternion.identity);
        }

        Vector3 m_refrectVec = Vector3.Reflect(this.m_lastVec, col.contacts[0].normal);
        this.m_rb.velocity = m_refrectVec;

        transform.LookAt(this.transform.position + m_refrectVec);
    }
}
