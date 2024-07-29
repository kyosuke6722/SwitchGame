using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KoGameOver : MonoBehaviour
{
    [SerializeField]
    Button retry_button;
    [SerializeField]
    EventSystem event_system;

    private static KoGameOver ms_instance = null;

    public AudioClip m_sound;
    AudioSource m_audioSource;

    public static KoGameOver instance { get { return ms_instance; } }

    [SerializeField]
    private KoLifePanel m_lifePanel;

    public void StartGameOver()
    {
        //有効化
        ms_instance.gameObject.SetActive(true);
        //SE再生
        m_audioSource.PlayOneShot(m_sound);
        //「リトライ」ボタンを選択状態に
        //event_system.SetSelectedGameObject(retry_button.gameObject);

        KoGameManager.instance.SetGameState(KoGameManager.GameState.State_GameOver);
        //ライフ減少
        KoGameManager.instance.SetLife(KoGameManager.instance.GetLife() - 1);
    }

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (ms_instance == null)
        {
            ms_instance = this;
            this.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        m_lifePanel.UpdateLife(KoGameManager.instance.GetLife());
    }
}
