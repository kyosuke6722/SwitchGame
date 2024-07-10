using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyDeviation : MonoBehaviour
{
    private KoEnemyManager enemyManager;

    //ヘッドの回転速度
    [SerializeField]
    private float m_rotateSpeed = 30.0f;
    //弾のプレハブ
    [SerializeField]
    private GameObject m_bulletPrefab = null;
    //弾の発射位置
    [SerializeField]
    private Transform m_cannonTips = null;
    //弾の発射速度
    [SerializeField]
    private float m_bulletSpeed = 3.0f;
    //反動
    [SerializeField]
    private float m_recoilTime = 1.0f;
    private float m_recoil = 0.0f;
    //弾の発射頻度
    [SerializeField]
    private float m_intervalTime = 5.0f;
    private float m_interval;

    //ターゲット
    [SerializeField]
    private GameObject target;

    Vector3 targetPrePosition;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<KoEnemyManager>();
        enemyManager.AddEnemy(gameObject);
        m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f);
    }

    public Vector3 LinePrediction(Vector3 shotPosition,Vector3 targetPosition,Vector3 targetPrePosition,float bulletSpeed)
    {
        bulletSpeed = bulletSpeed * Time.fixedDeltaTime;

        //ターゲットの移動方向
        Vector3 targetMove = targetPosition - targetPrePosition;
        //ターゲットの移動量
        float targetSpeed = (targetPosition - targetPrePosition).magnitude;

        //射撃位置からターゲットの現在位置までのベクトル
        Vector3 vec = targetPosition - shotPosition;

        float frame=0.0f;
        //ターゲットが動き続けると仮定して現在の位置と1フレーム毎の移動量から弾がターゲットに追いつくまでの時間を算出
        if(targetSpeed!=bulletSpeed)
        {
            frame =Mathf.Abs((vec.magnitude) / (targetSpeed - bulletSpeed));
        }

        Vector3 predictionPos = shotPosition+vec + targetMove * frame;

        return predictionPos;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        m_recoil -= Time.deltaTime;
        m_interval -= Time.deltaTime;

        Vector3 targetPosition=target.transform.position;

        ////弾を撃った反動がなければ
        if (m_recoil < 0)
        {
            targetPosition = LinePrediction(transform.position, target.transform.position, targetPrePosition, m_bulletSpeed);
            targetPrePosition = target.transform.position;

            //プレイヤーまでのベクトルを算出
            Vector3 forward = targetPosition - transform.parent.position;
            //Lerp関数で徐々に予測位置の方向に向く
            transform.forward += forward * m_rotateSpeed * Time.deltaTime;
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
                bulletrb.AddForce((targetPosition-transform.position).normalized*m_bulletSpeed,ForceMode.VelocityChange);
            }
            m_recoil = m_recoilTime;
            m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f);
        }
    }

    private void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.RemoveEnemy(gameObject);
        }

        GameObject body = transform.parent.gameObject;
        Destroy(body);
    }
}
