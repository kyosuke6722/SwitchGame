using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoPlayerHead : MonoBehaviour
{
    //[SerializeField]
    //private KoPlayer m_player;

    private static KoPlayerHead ms_instance = null;
    public static KoPlayerHead instance { get { return ms_instance; } }

    private void Update()
    {
        //m_interval -= Time.deltaTime;
        
        ////ÉwÉbÉhÇâÒì](ç∂)
        //if (Input.GetKey(KeyCode.O)||m_player.SGGamePad.MM_TL)
        //{
        //}
        ////(âE)
        //if (Input.GetKey(KeyCode.P)||m_player.SGGamePad.MM_TR)
        //{
        //}

        ////íeÇî≠éÀ
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)||m_player.SGGamePad.Y)
        //{
        //    Shot();
        //}
    }

    //private void HeadRotationLeft()
    //{
    //    transform.Rotate(new Vector3(0, -m_rotateSpeed * Time.deltaTime, 0));
    //}

    //private void HeadRotateRight()
    //{
    //    transform.Rotate(new Vector3(0, m_rotateSpeed * Time.deltaTime, 0));
    //}

    //private void Shot()
    //{
    //    if (m_interval < 0)
    //    {
    //        GameObject BulletObj = Instantiate
    //            (m_bulletPrefab,
    //            m_cannonTips.position,
    //            this.transform.rotation);
    //        BulletObj.transform.forward = this.transform.forward;

    //        //íeÇÃRigidbodyÇéÊìæ
    //        Rigidbody bulletrb = BulletObj.GetComponent<Rigidbody>();
    //        if (bulletrb != null)
    //        {
    //            //íeî≠éÀ
    //            bulletrb.AddForce(transform.forward * m_pow, ForceMode.Impulse);
    //        }
    //        m_interval = m_intervalTime;
    //    }
    //}

    private void OnDestroy()
    {
        GameObject body = transform.parent.gameObject;
        Destroy(body);
    }
}
