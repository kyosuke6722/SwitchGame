using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManager:MonoBehaviour{
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
