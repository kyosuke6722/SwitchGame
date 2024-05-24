using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyHead : MonoBehaviour
{
    //ヘッドの回転速度
    [SerializeField]
    private float m_rotateSpeed = 30.0f;
    //弾のプレハブ
    [SerializeField]
    private GameObject m_bulletPrefab = null;
    //弾の発射位置
    [SerializeField]
    private Transform m_cannonTips=null;
    //弾の発射速度
    [SerializeField]
    private float m_bulletSpeed = 3.0f;
    //反動
    [SerializeField]
    private float m_recoilTime=1.0f;
    private float m_recoil=0.0f;
    //弾の発射頻度
    [SerializeField]
    private float m_intervalTime = 5.0f;
    private float m_interval;

    //ターゲット
    [SerializeField]
    private GameObject target;

    private void Start()
    {
        m_interval = m_intervalTime+Random.Range(-1.0f,1.0f);
    }

    void Update()
    {
        m_recoil -= Time.deltaTime;
        m_interval -= Time.deltaTime;

        //弾を撃った反動がなければ
        if (m_recoil<0)
        {
            LockOn();
        }

        if (m_interval < 0)
        {
            GameObject BulletObj = Instantiate
                (m_bulletPrefab,
                m_cannonTips.position,
                this.transform.rotation);

            //弾のRigidbodyを取得
            Rigidbody bulletrb = BulletObj.GetComponent<Rigidbody>();
            if (bulletrb != null)
            {
                //弾発射
                bulletrb.AddForce(transform.forward*m_bulletSpeed, ForceMode.Impulse);
            }
            m_recoil = m_recoilTime;
            m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f); ;
        }
    }

    public void LockOn()
    {
        //プレイヤーまでのベクトルを算出
        Vector3 lookAtPos = target.transform.position;
        Vector3 forward = lookAtPos - transform.parent.position;
        forward.y = 0;
        forward.Normalize();
        //Lerp関数で徐々にプレイヤーの方向に向く
        transform.forward += forward * m_rotateSpeed * Time.deltaTime; ;
    }
}
