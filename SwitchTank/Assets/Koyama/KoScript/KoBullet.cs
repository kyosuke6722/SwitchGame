using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoBullet : MonoBehaviour
{
    private Rigidbody m_rb = null;

    //跳ね返り上限
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
        //戦車に当たった場合
        if (tag == "Player" || tag == "Enemy")
        {
            //戦車にダメージ

            Destroy(this.gameObject);
        }
        //弾に当たった場合
        if (tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

        //跳ね返り上限を越えていれば削除
        if (m_bounce <= 0) Destroy(this.gameObject);

        //反射
        Vector3 RefVelocity = Vector3.Reflect(m_lastVec, col.contacts[0].normal);
        m_rb.velocity = RefVelocity;
        transform.LookAt(transform.position + RefVelocity);
        m_bounce--;
    }
}
