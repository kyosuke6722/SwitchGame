using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
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
                SceneManager.LoadScene("Title");
                break;
            case 1:
                SceneManager.LoadScene("NPCVS1");
                break;
            case 2:
                SceneManager.LoadScene("NPCVS2");
                break;
            case 3:
                SceneManager.LoadScene("NPCVS3");
                break;
            case 4:
                SceneManager.LoadScene("PVP");
                break;
            case 5:
                SceneManager.LoadScene("GameClear");
                break;
            case 6:
                SceneManager.LoadScene("GameOver");
                break;
            case 7:
                SceneManager.LoadScene("PVP2");
                break;
        }
        
    }
}
