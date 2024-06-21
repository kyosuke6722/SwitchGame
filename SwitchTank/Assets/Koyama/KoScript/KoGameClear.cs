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

    public static KoGameClear instance { get { return ms_instance; } }

    [SerializeField]
    private KoLifePanel m_lifePanel;

    public void StartGameClear()
    {
        ms_instance.gameObject.SetActive(true);
        event_system.SetSelectedGameObject(next_button.gameObject);
        KoGameManager.instance.SetGameState(KoGameManager.GameState.State_GameClear);
    }

    private void Awake()
    {
        if(ms_instance==null)
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
