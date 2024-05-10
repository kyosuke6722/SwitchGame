using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MButtonEvent : MonoBehaviour
{
    [SerializeField]
    private int m_stage = 0;

    void Start()
    {
        
    }

    public void OnPressed()
    {
        SwitchScene();
    }

    public void SwitchScene()
    {
        switch (m_stage)
        {
            case 0:
                SceneManager.LoadScene("MNextScene");
                break;
            case 1:
                SceneManager.LoadScene("MSceneVS1");
                break;
            case 2:
                SceneManager.LoadScene("MSceneVS2");
                break;
        }
        
    }
}
