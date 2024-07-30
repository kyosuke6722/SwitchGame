using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MButtonManagerSlct : MonoBehaviour
{
    [SerializeField]
    private int m_stage = 0;

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
                SceneManager.LoadScene("Choices1");
                break;
            case 2:
                SceneManager.LoadScene("Choices2");
                break;
            case 3:
                SceneManager.LoadScene("Choices3");
                break;
            case 4:
                SceneManager.LoadScene("ChoicesSP");
                break;
            case 5:
                SceneManager.LoadScene("SelectGame");
                break;
        }

    }
}
