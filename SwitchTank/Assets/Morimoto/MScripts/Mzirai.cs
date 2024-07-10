using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mzirai : MonoBehaviour
{
    [SerializeField]
    private GameObject m_effect = null;
    [SerializeField]
    private GameObject m_ziraicol = null;
    [SerializeField]
    private BoxCollider m_bcol = null;
    [SerializeField]
    private MeshRenderer m_meshr = null;

    private bool m_isOn = false;
    private bool m_isCnt = false;
    private bool m_isBom = false;
    private bool m_isColor = false;
    private bool m_isSetBom = false;

    private float m_time = 0.0f;
    private float m_runtime = 0.0f;
    private float m_timer = 1.0f;
    private float m_maxtime = 7.0f;
    private float m_intervaltime = 1.0f;

    private int m_cnt = 0;
    private int m_colorcnt = 0;
    private const int m_minzirai = 0;

    private void Start()
    {
        m_isOn = false;
        m_isCnt = false;
        m_timer = 1.0f;
        m_maxtime = 5.0f;
        m_intervaltime = 1.0f;
        m_bcol.isTrigger = true;
        m_isBom = false;
        m_isColor = false;
        m_isSetBom = false;
    }

    private void OnTriggerExit(Collider other)
    {
        m_isOn = true;
        m_isCnt = true;
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.tag == "Bullet")
            {
                Instantiate(m_effect, transform.position, Quaternion.identity);
                Instantiate(m_ziraicol, transform.position, Quaternion.identity);
                m_bcol.isTrigger = false;
                m_isColor = false;
                if (MPlayerControllerVS.m_p1ziraicnt > m_minzirai)
                    MPlayerControllerVS.m_p1ziraicnt--;
                Destroy(this.gameObject);
                Destroy(col.gameObject);
            }
            if (m_isBom)
            {
                m_runtime = m_timer;
                m_isColor = true;
                m_isSetBom = true;
            }
        }
    }

    private void Update()
    {
        if (m_maxtime < m_timer)
        {
            m_isColor = true;
        }

        if (m_isColor)
        {
            m_cnt++;
            if (m_cnt % 40 == 0)m_colorcnt++;
            if (m_colorcnt%2==0)
            {
                m_meshr.material.color = Color.red;
            }
            else
            {
                m_meshr.material.color = Color.yellow;
            }
            m_runtime -= Time.deltaTime;
            m_maxtime -= Time.deltaTime;
        }
        else
        {
            m_cnt = 0;
            m_colorcnt = 0;
            m_runtime -= Time.deltaTime;
            m_maxtime -= Time.deltaTime;
        }
        
        //m_maxtime -= Time.deltaTime;
        m_intervaltime -= Time.deltaTime;

        if (m_maxtime < m_time)
        {
            timeover();
        }
        if (m_time > m_intervaltime)
        {
            m_bcol.isTrigger = false;
            m_isBom = true;
        }
        if (m_time > m_runtime && m_isSetBom)
        {
            Instantiate(m_effect, transform.position, Quaternion.identity);
            Instantiate(m_ziraicol, transform.position, Quaternion.identity);
            m_bcol.isTrigger = false;
            m_isColor = false;
            if (MPlayerControllerVS.m_p1ziraicnt > m_minzirai)
                MPlayerControllerVS.m_p1ziraicnt--;
            Destroy(this.gameObject);
        }
    }

    private void timeover()
    {
        Instantiate(m_effect, transform.position, Quaternion.identity);
        Instantiate(m_ziraicol, transform.position, Quaternion.identity);
        m_isColor = false;
        if (MPlayerControllerVS.m_p1ziraicnt > m_minzirai)
            MPlayerControllerVS.m_p1ziraicnt--;
        Destroy(this.gameObject);
        m_maxtime = 5.0f;
    }
}
