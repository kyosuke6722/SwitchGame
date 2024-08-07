using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitamurarHead : MonoBehaviour
{
    [SerializeField]
    private KoPlayer m_player;

    //wbhΜρ]¬x
    [SerializeField]
    private float m_rotateSpeed = 30.0f;
    //eΜvnu
    [SerializeField]
    private GameObject m_bulletPrefab = null;
    //eΜ­Λ¬x
    [SerializeField]
    private float m_pow = 3.0f;
    //eΜ­ΛΚu
    [SerializeField]
    private Transform m_cannonTips = null;
    //[hΤ
    [SerializeField]
    private float m_intervalTime = 5.0f;
    private float m_interval = 0.0f;

    private void Update()
    {
        m_interval -= Time.deltaTime;

        //wbhπρ](Ά)
        if (Input.GetKey(KeyCode.O) || m_player.SGGamePad.MM_UTL)
        {
            transform.Rotate(new Vector3(0, -m_rotateSpeed * Time.deltaTime, 0));
        }
        //(E)
        if (Input.GetKey(KeyCode.P) || m_player.SGGamePad.MM_UTR)
        {
            transform.Rotate(new Vector3(0, m_rotateSpeed * Time.deltaTime, 0));
        }

        //eπ­Λ
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || m_player.SGGamePad.Y)
        {
            if (m_interval < 0)
            {
                GameObject BulletObj = Instantiate
                    (m_bulletPrefab,
                    m_cannonTips.position,
                    this.transform.rotation);
                BulletObj.transform.forward = this.transform.forward;

                //eΜRigidbodyπζΎ
                Rigidbody bulletrb = BulletObj.GetComponent<Rigidbody>();
                if (bulletrb != null)
                {
                    //e­Λ
                    bulletrb.AddForce(transform.forward * m_pow, ForceMode.Impulse);
                }
                m_interval = m_intervalTime;
            }
        }
    }

    private void OnDestroy()
    {
        GameObject body = transform.parent.gameObject;
        Destroy(body);
    }
}
