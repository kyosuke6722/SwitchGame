using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoBGM : MonoBehaviour
{
    AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //ゲームオーバー中であれば
        if (KoGameManager.instance.GetGameState() == KoGameManager.GameState.State_GameOver)
        {
            //BGMを止める
            m_audioSource.Stop();
        }
    }
}
