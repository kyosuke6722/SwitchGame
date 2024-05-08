using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoBullet : MonoBehaviour
{
    private Rigidbody m_rb = null;

    //���˕Ԃ���
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
        //��Ԃɓ��������ꍇ
        if (tag == "Player" || tag == "Enemy")
        {
            //��ԂɃ_���[�W

            Destroy(this.gameObject);
        }
        //�e�ɓ��������ꍇ
        if (tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

        //���˕Ԃ������z���Ă���΍폜
        if (m_bounce <= 0) Destroy(this.gameObject);

        //����
        Vector3 RefVelocity = Vector3.Reflect(m_lastVec, col.contacts[0].normal);
        m_rb.velocity = RefVelocity;
        transform.LookAt(transform.position + RefVelocity);
        m_bounce--;
    }
}
