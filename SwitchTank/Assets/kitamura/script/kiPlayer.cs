using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kiPlayer : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 0.01f;

    private Camera m_mainCamera = null;
    private Rigidbody m_rigidbody = null;

    [SerializeField]
    private int m_player = 1;

    private float velocity = 0.05f;

    [SerializeField]
    private float max_speed = 0.06f;

    [SerializeField] float speed, dashSpeed;
    [SerializeField] int maxDashCount;

    // 現在のスピードとダッシュ回数を保持しておく変数
    float currentSpeed;
    int currentDashCount;
    public Text DashCount;

    //横入力
    private float m_RightKeyInput = 0f;
    private float m_LeftKeyInput = 0f;
    //縦入力
    private float m_ForwardKeyInput = 0f;
    private float m_BackKeyInput = 0f;

    private void Awake()
    {
        m_mainCamera = Camera.main;
        //Rigidbodyコンポーネントを取得
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // 現在のスピードをスピードに設定
        currentSpeed = speed;
        // 現在のダッシュ回数を最大ダッシュ回数に設定
        currentDashCount = maxDashCount;
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
        switch (m_player)
        {
            case 1:

                float x = Input.GetAxisRaw("Horizontal");
               
                // スペースキーが押され、かつ現在のダッシュ回数が0より大きい場合
                if (Input.GetKeyDown(KeyCode.Space) && currentDashCount > 0)
                {
                    // 現在のスピードをダッシュスピードに設定
                    currentSpeed = speed*dashSpeed;
                    // ダッシュ回数を1減らす
                    currentDashCount--;
                    DashCount.text=currentDashCount.ToString();
                }
                else
                {
                    // 現在のスピードを通常スピードに設定
                    currentSpeed = speed;
                }

                // 移動させる
                transform.Translate(new Vector3(x, 0, 0) * currentSpeed * Time.deltaTime);
                
                if (Input.GetKey(KeyCode.W))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(0, 0, velocity);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(0, 0, velocity);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(velocity, 0, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(velocity, 0, 0);
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(0, 0, velocity);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(0, 0, velocity);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity += new Vector3(velocity, 0, 0);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (velocity < max_speed) m_rigidbody.velocity -= new Vector3(velocity, 0, 0);
                }
                break;
            case 3:

                break;
        }
    }
}

