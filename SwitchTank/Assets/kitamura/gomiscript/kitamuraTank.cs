using System.Collections;
using System.Collections.Generic;
using nn.hid;
using UnityEngine;

public class KitamuraTank : MonoBehaviour
{
    //移動速度
    [SerializeField]
    private float m_moveSpeed = 3.0f;

    //移動用横方向入力
    private float m_horizontalKeyInput = 0.0f;
    //移動用縦方向入力
    private float m_verticalKeyInput = 0.0f;

    private Camera m_mainCamera = null;
    private Rigidbody m_rigidbody = null;

    [SerializeField]
    public struct NTD_SGGamePad
    {
        public string ModeName;
        public float L_Analog_X;
        public float L_Analog_Y;
        public float R_Analog_X;
        public float R_Analog_Y;
        public bool Up;
        public bool Down;
        public bool Right;
        public bool Left;
        public bool B;
        public bool X;
        public bool A;
        public bool Y;
        public bool Plus;
        public bool Minus;
        public bool MM_TL;
        public bool MM_TR;
        public bool MM_UTL;
        public bool MM_UTR;
    }
    [SerializeField]
    public NTD_SGGamePad SGGamePad = new NTD_SGGamePad();

    [SerializeField]
    public struct NTD_MMGamePad
    {
        public string ModeName;
        public float MM_Analog_X;
        public float MM_Analog_Y;
        public bool MM_Up_B;
        public bool MM_Down_X;
        public bool MM_Right_A;
        public bool MM_Left_Y;
        public bool MM_Plus_Minus;
        public bool MM_SL;
        public bool MM_SR;
        public bool MM_T;
        public bool MM_UT;
    };
    [SerializeField]
    public NTD_MMGamePad[] MMGamePad = new NTD_MMGamePad[4];

    //コントロール格納
    private ControllerSupportArg controllerSupportArg = new ControllerSupportArg();
    //nnリクエスト
    private nn.Result result = new nn.Result();

    private NpadId[] npadIds =
    {
        NpadId.Handheld,
        NpadId.No1,
        NpadId.No2
    };

    public NpadState npadState = new NpadState();

    void Start()
    {
        //パッド初期化
        Npad.Initialize();
        //パッドサポートタイプはid群
        Npad.SetSupportedIdType(npadIds);
        ///パッドのタイプは【横向き型】
        NpadJoy.SetHoldType(NpadJoyHoldType.Horizontal);

        //パッドサポートタイプ
        Npad.SetSupportedStyleSet(
            NpadStyle.FullKey |     ///スイッチ合体型
            NpadStyle.Handheld |    ///ハンドヘルド
            NpadStyle.JoyDual |     ///別枠合体型コントローラー
            NpadStyle.JoyLeft |     ///お裾分け左パッド
            NpadStyle.JoyRight);    ///お裾分け右パッド

        ///全てのパッドをシングルモードに変更
        foreach (NpadId NP in npadIds)
        {
            NpadJoy.SetAssignmentModeSingle(NP);
        }

        m_mainCamera = Camera.main;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    //移動ベクトルを算出
    private Vector3 CalcMoveDir(float moveX, float moveZ)
    {
        //指定された移動値から移動ベクトルを求める
        Vector3 moveVec = new Vector3(moveX, 0f, moveZ).normalized;

        //カメラの向きに合わせて移動するベクトルに変換して返す
        Vector3 moveDir = m_mainCamera.transform.rotation * moveVec;
        moveDir.y = 0f;

        return moveDir.normalized;
    }

    private void Update()
    {
        //PadCheck();

        //移動キー入力取得
        m_horizontalKeyInput = Input.GetAxis("Horizontal");
        //m_horizontalKeyInput = SGGamePad.L_Analog_X;
        m_verticalKeyInput = Input.GetAxis("Vertical");
        //m_verticalKeyInput = SGGamePad.L_Analog_Y;

        NpadButton onButtons = 0;
        if ((onButtons & (NpadButton.Plus | NpadButton.Minus)) != 0)
        {
            ShowControllerSupport();
        }

        //横移動
        if (m_horizontalKeyInput != 0f)
        {
            m_rigidbody.velocity += new Vector3(m_horizontalKeyInput * m_moveSpeed, 0, 0);
        }
        //縦移動
        if (m_verticalKeyInput != 0f)
        {
            m_rigidbody.velocity += new Vector3(0, 0, m_verticalKeyInput * m_moveSpeed);
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

    private void OnDestroy()
    {
       // if (KoGameManager.instance.GetGameState() == KoGameManager.GameState.State_Game)
           // KoGameOver.instance.StartGameOver();
        //SceneManager.LoadScene(gameover_scene);
    }

    void PadCheck()
    {
        for (int i = 0; i < npadIds.Length; i++)
        {
            //パッドIdを取得
            NpadId npadId = npadIds[i];

            //パッドの現在のスタイルを獲得
            NpadStyle npadStyle = Npad.GetStyleSet(npadId);

            //パッドが存在してない
            if (npadStyle == NpadStyle.None) continue;

            //パッドの状態を獲得
            Npad.GetState(ref npadState, npadId, npadStyle);

            //パッドのスタイルによるボタン入力状況チェック
            switch (npadStyle)
            {
                ///左パッド
                case NpadStyle.JoyLeft:
                    JoyNullSet(i);
                    JoyLeftSet(npadState, i);
                    break;
                ///右パッド
                case NpadStyle.JoyRight:
                    JoyNullSet(i);
                    JoyRightSet(npadState, i);
                    break;
                case NpadStyle.Handheld:
                    JoySGNullSet();
                    JoySingleSet(npadState);
                    break;
            }
        }
    }

    void JoySGNullSet()
    {
        SGGamePad.L_Analog_X = 0.0f;
        SGGamePad.L_Analog_Y = 0.0f;
        SGGamePad.R_Analog_X = 0.0f;
        SGGamePad.R_Analog_Y = 0.0f;

        SGGamePad.Up = false;
        SGGamePad.Down = false;
        SGGamePad.Right = false;
        SGGamePad.Left = false;
        SGGamePad.B = false;
        SGGamePad.X = false;
        SGGamePad.A = false;
        SGGamePad.Y = false;
        SGGamePad.Plus = false;
        SGGamePad.Minus = false;
        SGGamePad.MM_TL = false;
        SGGamePad.MM_TR = false;
        SGGamePad.MM_UTL = false;
        SGGamePad.MM_UTR = false;
    }

    void JoySingleSet(NpadState NS)
    {
        SGGamePad.L_Analog_X = NS.analogStickL.x;
        SGGamePad.L_Analog_X /= AnalogStickState.Max;
        SGGamePad.L_Analog_Y = NS.analogStickL.y;
        SGGamePad.L_Analog_Y /= AnalogStickState.Max;

        SGGamePad.R_Analog_X = NS.analogStickR.x;
        SGGamePad.R_Analog_X /= AnalogStickState.Max;
        SGGamePad.R_Analog_Y = NS.analogStickR.y;
        SGGamePad.R_Analog_Y /= AnalogStickState.Max;

        SGGamePad.Up = NS.GetButton(NpadButton.Up);
        SGGamePad.Down = NS.GetButton(NpadButton.Down);
        SGGamePad.Right = NS.GetButton(NpadButton.Right);
        SGGamePad.Left = NS.GetButton(NpadButton.Left);

        SGGamePad.B = NS.GetButton(NpadButton.B);
        SGGamePad.X = NS.GetButton(NpadButton.X);
        SGGamePad.A = NS.GetButton(NpadButton.A);
        SGGamePad.Y = NS.GetButton(NpadButton.Y);

        SGGamePad.Plus = NS.GetButton(NpadButton.Plus);
        SGGamePad.Minus = NS.GetButton(NpadButton.Minus);
        SGGamePad.MM_TL = NS.GetButton(NpadButton.ZL);
        SGGamePad.MM_TR = NS.GetButton(NpadButton.ZR);
        SGGamePad.MM_UTL = NS.GetButton(NpadButton.L);
        SGGamePad.MM_UTR = NS.GetButton(NpadButton.R);
    }
    void JoyNullSet(int No)
    {
        MMGamePad[No].MM_Analog_X = 0.0f;
        MMGamePad[No].MM_Analog_Y = 0.0f;

        MMGamePad[No].MM_Up_B = false;
        MMGamePad[No].MM_Down_X = false;
        MMGamePad[No].MM_Left_Y = false;
        MMGamePad[No].MM_Right_A = false;

        MMGamePad[No].MM_Plus_Minus = false;
        MMGamePad[No].MM_SL = false;
        MMGamePad[No].MM_SR = false;
        MMGamePad[No].MM_T = false;
        MMGamePad[No].MM_UT = false;
    }

    void JoyLeftSet(NpadState NS, int No)
    {
        MMGamePad[No].MM_Analog_X = 0.0f;
        MMGamePad[No].MM_Analog_Y = 0.0f;

        MMGamePad[No].MM_Analog_X = -NS.analogStickL.y;
        MMGamePad[No].MM_Analog_X /= AnalogStickState.Max;

        MMGamePad[No].MM_Analog_Y = NS.analogStickL.x;
        MMGamePad[No].MM_Analog_Y /= AnalogStickState.Max;

        MMGamePad[No].MM_Up_B = NS.GetButton(NpadButton.Up);
        MMGamePad[No].MM_Down_X = NS.GetButton(NpadButton.Down);
        MMGamePad[No].MM_Left_Y = NS.GetButton(NpadButton.Left);
        MMGamePad[No].MM_Right_A = NS.GetButton(NpadButton.Right);

        MMGamePad[No].MM_Plus_Minus = NS.GetButton(NpadButton.Minus);
        MMGamePad[No].MM_SL = NS.GetButton(NpadButton.LeftSL);
        MMGamePad[No].MM_SR = NS.GetButton(NpadButton.LeftSR);
        MMGamePad[No].MM_T = NS.GetButton(NpadButton.ZL);
        MMGamePad[No].MM_UT = NS.GetButton(NpadButton.L);
    }

    void JoyRightSet(NpadState NS, int No)
    {
        MMGamePad[No].MM_Analog_X = 0.0f;
        MMGamePad[No].MM_Analog_Y = 0.0f;

        MMGamePad[No].MM_Analog_X = NS.analogStickR.y;
        MMGamePad[No].MM_Analog_X /= AnalogStickState.Max;

        MMGamePad[No].MM_Analog_Y = -NS.analogStickR.x;
        MMGamePad[No].MM_Analog_Y /= AnalogStickState.Max;

        MMGamePad[No].MM_Up_B = NS.GetButton(NpadButton.B);
        MMGamePad[No].MM_Down_X = NS.GetButton(NpadButton.X);
        MMGamePad[No].MM_Left_Y = NS.GetButton(NpadButton.Y);
        MMGamePad[No].MM_Right_A = NS.GetButton(NpadButton.A);


        MMGamePad[No].MM_Plus_Minus = NS.GetButton(NpadButton.Plus);
        MMGamePad[No].MM_SL = NS.GetButton(NpadButton.RightSL);
        MMGamePad[No].MM_SR = NS.GetButton(NpadButton.RightSR);
        MMGamePad[No].MM_T = NS.GetButton(NpadButton.ZR);
        MMGamePad[No].MM_UT = NS.GetButton(NpadButton.R);
    }

    void ShowControllerSupport()
    {
        controllerSupportArg.SetDefault();
        controllerSupportArg.playerCountMax = (byte)(npadIds.Length - 1);

        //識別色を有効化
        controllerSupportArg.enableIdentificationColor = true;
        nn.util.Color4u8 color = new nn.util.Color4u8();
        //赤
        color.Set(255, 128, 128, 255);
        controllerSupportArg.identificationColor[0] = color;
        //青
        color.Set(128, 128, 255, 255);
        controllerSupportArg.identificationColor[1] = color;
        //緑
        color.Set(128, 255, 128, 255);
        controllerSupportArg.identificationColor[2] = color;
        //黄
        color.Set(224, 224, 128, 255);
        controllerSupportArg.identificationColor[3] = color;

        //説明用テキスト
        controllerSupportArg.enableExplainText = true;
        ControllerSupport.SetExplainText(ref controllerSupportArg, "Red", NpadId.No1);
        ControllerSupport.SetExplainText(ref controllerSupportArg, "Blue", NpadId.No2);
        ControllerSupport.SetExplainText(ref controllerSupportArg, "Green", NpadId.No3);
        ControllerSupport.SetExplainText(ref controllerSupportArg, "Yellow", NpadId.No4);

        Debug.Log(controllerSupportArg);
        result = ControllerSupport.Show(controllerSupportArg);
        if (!result.IsSuccess())
        {
            Debug.Log(result);
        }
    }
}
