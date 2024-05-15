using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class StageManager:MonoBehaviour{
    private static StageManager ms_instance = null;
    public static bool IsStageManager()
    {
        return ms_instance.gameObject.activeSelf;
    }
    public static void StartStageManager()
    {
        ms_instance.gameObject.SetActive(true);
    }
    public void nextStage()
{
    int StageUnlock = PlayerPrefs.GetInt("StageUnlock");
    int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
    if(NextScene<5)
    {
            if(StageUnlock<NextScene)
            {
                PlayerPrefs.SetInt("StageUnlock", NextScene);
            }
            SceneManager.LoadScene(NextScene);
    }
    else
            SceneManager.LoadScene(0);
}
}
