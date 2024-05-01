using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyBody : MonoBehaviour
{
    //移動速度
    [SerializeField]
    private float m_moveSpeed = 0.1f;

    private Rigidbody m_rigidbody = null;

    public GameObject target;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //プレイヤーを追いかける
        transform.position = Vector3.MoveTowards
            (transform.position,
            new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z),
            m_moveSpeed * Time.deltaTime);
    }
}
