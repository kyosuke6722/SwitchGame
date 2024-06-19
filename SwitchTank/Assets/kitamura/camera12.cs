using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject target; // ターゲットへの参照
    public float speed = 5f; // 回転速度

    void Start()
    {
        if (target == null)
        {
            // ターゲットが指定されていない場合は、自分自身をターゲットにする
            target = this.gameObject;
        }
    }

    void Update()
    {
        // ターゲットの周りを回転する
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
