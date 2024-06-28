using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class KoButtonNext : MonoBehaviour
{
    public void OnClickEnter(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
