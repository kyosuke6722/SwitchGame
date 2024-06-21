using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class KoButtonRetry : MonoBehaviour
{
    [SerializeField]
    EventSystem event_system;
    [SerializeField]
    Button title_button;

    Button m_button;

    private void Awake()
    {
        m_button = gameObject.GetComponent<Button>();
    }

    private void Update()
    {
        //残機が無ければボタンを押せなくする
        if(KoGameManager.instance.GetLife()<=0)
        {
            m_button.interactable = false;
            event_system.SetSelectedGameObject(title_button.gameObject);
        }
    }

    public void OnClickEnter()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
