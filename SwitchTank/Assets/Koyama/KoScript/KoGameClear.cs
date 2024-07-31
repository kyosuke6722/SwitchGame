using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KoGameClear : MonoBehaviour
{
    [SerializeField]
    Button next_button;
    [SerializeField]
    EventSystem event_system;

    private static KoGameClear ms_instance=null;

    public AudioClip m_clearSound;
    AudioSource m_audioSource;

    public static KoGameClear instance { get { return ms_instance; } }

    [SerializeField]
    private KoLifePanel m_lifePanel;

    public void StartGameClear()
    {
        //有効化
        ms_instance.gameObject.SetActive(true);
        //SE再生
        m_audioSource.PlayOneShot(m_clearSound);
        //「つぎへ」ボタンを選択状態に
        event_system.SetSelectedGameObject(next_button.gameObject);

        KoGameManager.instance.SetGameState(KoGameManager.GameState.State_GameClear);
    }

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (ms_instance==null)
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
