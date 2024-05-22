using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyDeviation : MonoBehaviour
{
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
    private float m_pow = 3.0f;
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
    Vector3 targetPrePosition2;

    public Vector3 LinePrediction(Vector3 shotPosition,Vector3 targetPosition,Vector3 targetPrePosition,float bulletSpeed)
    {
        bulletSpeed = bulletSpeed * Time.fixedDeltaTime;
        //標的の1フレームの移動速度
        Vector3 targetSpeed = targetPosition - targetPrePosition;
        //射撃位置から見た標的の位置
        Vector3 targetVec = targetPosition - shotPosition;

        float A = Vector3.SqrMagnitude(targetSpeed) - bulletSpeed * bulletSpeed;
        float B = Vector3.Dot(targetVec, targetSpeed);
        float C = Vector3.SqrMagnitude(targetVec);

        //0割禁止
        if (A == 0 && B == 0) return targetPosition;
        if (A == 0) return targetPosition + targetSpeed * (-C / B / 2);

        float D = Mathf.Sqrt(Mathf.Abs(B * B - A * C));
        return targetPosition + targetSpeed * PlusMin((-B-D)/A,(-B+D)/A);
    }

    public float PlusMin(float a, float b)
    {
        if (a < 0 && b < 0) return 0;
        if (a < 0) return b;
        if (b < 0) return a;
        return a < b ? a : b;
    }

    public Vector3 CirclePrediction(Vector3 shotPosition,Vector3 targetPosition,Vector3 targetPrePosition,Vector3 targetPrePosition2,float bulletSpeed)
    {
        //3点の角度変化が小さい場合は線形予測に切り替え
        if(Mathf.Abs(Vector3.Angle(targetPosition-targetPrePosition,targetPrePosition-targetPrePosition2))<0.03)
        {
            return LinePrediction(shotPosition, targetPosition, targetPosition,bulletSpeed);
        }

        //Unityの物理はm/sなのでm/flameにする
        bulletSpeed = bulletSpeed * Time.fixedDeltaTime;

        //3点から円の中心点(三角形の外心)を出す
        Vector3 CenterPosition = Circumcenter(targetPosition, targetPrePosition, targetPrePosition2);

        //中心点から見た1フレームの角速度と軸を出す
        Vector3 axis = Vector3.Cross(targetPrePosition - CenterPosition, targetPosition - CenterPosition);
        float angle = Vector3.Angle(targetPrePosition - CenterPosition, targetPosition - CenterPosition);

        //現在位置での弾の到達時間を出す
        float PredictionFlame = Vector3.Distance(targetPosition, shotPosition) / bulletSpeed;
    
        //到達時間分を移動した予測位置で再計算して到達時間を補正する
        for(int i=0;i<3;++i)
        {
            PredictionFlame = Vector3.Distance(RotateToPosition(targetPosition, CenterPosition, axis, angle * PredictionFlame), shotPosition/bulletSpeed);
        }
        return RotateToPosition(targetPosition, CenterPosition, axis, angle * PredictionFlame);
    }

    //三角形の頂点、三点の位置から外心の位置を返す
    public Vector3 Circumcenter(Vector3 posA,Vector3 posB,Vector3 posC)
    {
        //三辺の長さの二乗を出す
        float edgeA = Vector3.SqrMagnitude(posB - posC);
        float edgeB = Vector3.SqrMagnitude(posC - posA);
        float edgeC = Vector3.SqrMagnitude(posA - posB);

        //重心座標系で計算する
        float a = edgeA * (-edgeA + edgeB + edgeC);
        float b = edgeB * (edgeA - edgeB + edgeC);
        float c = edgeC * (edgeA + edgeB - edgeC);

        if (a + b + c == 0) return (posA + posB + posC) / 3;
        return (posA * a + posB * b + posC * c) / (a + b + c);
    }

    //目標位置をセンター位置で軸と角度で回転させた位置を返す
    public Vector3 RotateToPosition(Vector3 v3_target,Vector3 v3_center,Vector3 v3_axis,float f_angle)
    {
        return Quaternion.AngleAxis(f_angle, v3_axis) * (v3_target - v3_center) + v3_center;
    }

    private void Update()
    {
        m_recoil -= Time.deltaTime;
        m_interval -= Time.deltaTime;

        Vector3 targetPosition;

        ////弾を撃った反動がなければ
        //if (m_recoil < 0)
        {
            targetPosition = CirclePrediction(transform.position, target.transform.position, targetPrePosition, targetPrePosition2, m_pow);
            targetPrePosition2 = targetPrePosition;
            targetPrePosition = target.transform.position;

            //プレイヤーまでのベクトルを算出
            Vector3 forward = targetPosition - transform.parent.position;
            forward.y = 0;
            //forward.Normalize();
            //Lerp関数で徐々に予測位置の方向に向く
            transform.forward += forward * Time.deltaTime; //* m_rotateSpeed * Time.deltaTime;
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
                bulletrb.AddForce((targetPosition-transform.position).normalized*m_pow,ForceMode.VelocityChange);
            }
            m_recoil = m_recoilTime;
            m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f); ;
        }
    }
}
