using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoPlayerHead : MonoBehaviour
{
    [SerializeField]
    private KoPlayer m_player;

    //ƒwƒbƒh‚Ì‰ñ“]‘¬“x
    [SerializeField]
    private float m_rotateSpeed = 30.0f;
    //’e‚ÌƒvƒŒƒnƒu
    [SerializeField]
    private GameObject m_bulletPrefab = null;
    //’e‚Ì”­Ë‘¬“x
    [SerializeField]
    private float m_pow = 3.0f;
    //’e‚Ì”­ËˆÊ’u
    [SerializeField]
    private Transform m_cannonTips = null;
    //ƒŠƒ[ƒhŠÔ
    [SerializeField]
    private float m_intervalTime = 5.0f;
    private float m_interval = 0.0f;

    private void Update()
    {
        m_interval -= Time.deltaTime;

        //ƒwƒbƒh‚ğ‰ñ“](¶)
        if (Input.GetKey(KeyCode.O)||m_player.SGGamePad.MM_UTL)
        {
            transform.Rotate(new Vector3(0, -m_rotateSpeed * Time.deltaTime, 0));
        }
        //(‰E)
        if (Input.GetKey(KeyCode.P)||m_player.SGGamePad.MM_UTR)
        {
            transform.Rotate(new Vector3(0, m_rotateSpeed * Time.deltaTime, 0));
        }

        //’e‚ğ”­Ë
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)||m_player.SGGamePad.Y)
        {
            if (m_interval < 0)
            {
                GameObject BulletObj = Instantiate
                    (m_bulletPrefab,
                    m_cannonTips.position,
                    this.transform.rotation);
                BulletObj.transform.forward = this.transform.forward;

                //’e‚ÌRigidbody‚ğæ“¾
                Rigidbody bulletrb = BulletObj.GetComponent<Rigidbody>();
                if (bulletrb != null)
                {
                    //’e”­Ë
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
