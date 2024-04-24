using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 2f;

    private Camera m_mainCamera = null;
    private Rigidbody m_rigidbody = null;

    //横入力
    private float m_horizontalKeyInput = 0f;
    //縦入力
    private float m_verticalKeyInput = 0f;

    private void Awake()
    {
        m_mainCamera = Camera.main;
        //Rigidbodyコンポーネントを取得
        m_rigidbody = GetComponent<Rigidbody>();
    }

    //移動方向ベクトルを算出
    private Vector3 CalcMoveDir(float moveX, float moveZ)
    {
        //指定された移動値から移動ベクトルを求める
        Vector3 moveVec = new Vector3(moveX, 0f, moveZ).normalized;

        //カメラの向きに合わせて移動するベクトルに変換して、返す
        Vector3 moveDir = m_mainCamera.transform.rotation * moveVec;
        moveDir.y = 0f;
        return moveDir.normalized;
    }

    private void Update()
    {
        m_horizontalKeyInput = Input.GetAxis("Horizontal");
        m_verticalKeyInput = Input.GetAxis("Vertical");

        //移動キーが入力されているかどうか
        bool isKeyInput = m_horizontalKeyInput != 0f || m_verticalKeyInput != 0f;
        if (isKeyInput)
        {
            //プレイヤーを移動方向へ向ける
            //Vector3 moveDir = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput);
            //transform.forward = moveDir.normalized;
        }
    }

    private void FixedUpdate()
    {
        //キー入力による移動量を求める
        Vector3 move = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput) * m_moveSpeed;
        //現在の移動量を取得
        Vector3 current = m_rigidbody.velocity;
        current.y = 0f;

        //現在の移動量との差分だけプレイヤーに力を加える
        m_rigidbody.AddForce(move - current, ForceMode.VelocityChange);
    }
}
