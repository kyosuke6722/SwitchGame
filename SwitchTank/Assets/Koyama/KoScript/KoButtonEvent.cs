using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoButtonEvent : MonoBehaviour
{
    //enum scene
    //{
    //}

    [SerializeField]
    private int m_loadScene;

    public void OnClickEnter()
    {
        switch (m_loadScene)
        {
            case 0:
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                break;
            case 1:
                SceneManager.LoadScene("KoTitle");
                break;
        }
    }
};
