using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoBullet : MonoBehaviour
{
    private Rigidbody m_rb = null;

    //’µ‚Ë•Ô‚èãŒÀ
    [SerializeField]
    private int m_bounce = 1;

    private Vector3 m_lastVec;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        m_lastVec = this.m_rb.velocity;
    }

    private void OnCollisionEnter(Collision col)
    {
        string tag = col.gameObject.tag;
        //íÔ‚É“–‚½‚Á‚½ê‡
        if (tag == "Player" || tag == "Enemy")
        {
            //íÔ‚Éƒ_ƒ[ƒW

            Destroy(this.gameObject);
        }
        //’e‚É“–‚½‚Á‚½ê‡
        if (tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

        //’µ‚Ë•Ô‚èãŒÀ‚ğ‰z‚¦‚Ä‚¢‚ê‚Îíœ
        if (m_bounce <= 0) Destroy(this.gameObject);

        //”½Ë
        Vector3 RefVelocity = Vector3.Reflect(m_lastVec, col.contacts[0].normal);
        m_rb.velocity = RefVelocity;
        transform.LookAt(transform.position + RefVelocity);
        m_bounce--;
    }
}
