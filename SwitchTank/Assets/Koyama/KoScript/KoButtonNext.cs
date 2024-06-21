using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class KoButtonNext : MonoBehaviour
{
    //[SerializeField]
    //EventSystem event_system;

    //public void SetSelectedButton()
    //{
    //    event_system.SetSelectedGameObject(gameObject);
    //}

    public void OnClickEnter(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
