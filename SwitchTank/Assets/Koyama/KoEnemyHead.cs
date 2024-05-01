using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyHead : MonoBehaviour
{
    //ヘッドの回転速度
    [SerializeField]
    private float m_rotateSpeed = 0.02f;
    //弾の発射頻度
    [SerializeField]
    private float m_interval = 5.0f;

    //ターゲット
    public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        //プレイヤーまでのベクトルを算出
        Vector3 lookAtPos = target.transform.position;
        Vector3 forward = lookAtPos - transform.parent.position;
        forward.y = 0;
        forward.Normalize();
        //Lerp関数で徐々にプレイヤーの方向に向く
        transform.forward += forward*m_rotateSpeed*Time.deltaTime; //= Vector3.Lerp(transform.forward, forward, m_rotateSpeed * Time.deltaTime);
    }
}
