using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyBody : MonoBehaviour
{
    //移動速度
    [SerializeField]
    private float m_moveSpeed = 0.1f;

    private Rigidbody m_rigidbody = null;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //プレイヤーを追いかける
    }
}
