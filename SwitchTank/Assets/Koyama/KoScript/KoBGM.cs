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
        //�Q�[���I�[�o�[���ł����
        if (KoGameManager.instance.GetGameState() == KoGameManager.GameState.State_GameOver)
        {
            //BGM���~�߂�
            m_audioSource.Stop();
        }
    }
}
