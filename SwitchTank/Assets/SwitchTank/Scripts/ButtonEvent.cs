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
            case 8:
                SceneManager.LoadScene("PVP3");
                break;
            case 9:
                SceneManager.LoadScene("Credit");
                break;
            case 10:
                SceneManager.LoadScene("Choices1");
                break;
            case 11:
                MSelectStages.m_stages = 0;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 12:
                MSelectStages.m_stages = 1;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 13:
                MSelectStages.m_stages = 2;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 14:
                MSelectStages.m_stages = 3;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 15:
                MSelectStages.m_stages = 4;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 16:
                MSelectStages.m_stages = 5;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 20:
                SceneManager.LoadScene("Choices2");
                break;
            case 21:
                MSelectStages.m_stages = 6;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 22:
                MSelectStages.m_stages = 7;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 23:
                MSelectStages.m_stages = 8;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 24:
                MSelectStages.m_stages = 9;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 25:
                SceneManager.LoadScene("SelectPVP");
                break;
            case 26:
                MSelectStages.m_stages = 11;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 30:
                SceneManager.LoadScene("Choices3");
                break;
            case 31:
                MSelectStages.m_stages = 12;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 32:
                MSelectStages.m_stages = 13;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 33:
                MSelectStages.m_stages = 14;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 34:
                MSelectStages.m_stages = 15;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 35:
                MSelectStages.m_stages = 16;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 36:
                MSelectStages.m_stages = 17;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 40:
                SceneManager.LoadScene("ChoicesSP");
                break;
            case 41:
                MSelectStages.m_stages = 18;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 42:
                MSelectStages.m_stages = 19;
                SceneManager.LoadScene("SelectPVP");
                break;
            case 43:
                MSelectStages.m_stages = 20;
                SceneManager.LoadScene("SelectPVP");
                break;
        }
        
    }
}
