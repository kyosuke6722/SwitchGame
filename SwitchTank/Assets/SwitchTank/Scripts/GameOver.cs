using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private static GameOver ms_instance = null;

    //public static bool IsGameOver()
    //{
    //    //return ms_instance.gameObject.activeSelf;
    //}
    //public static void StartGameOver()
    //{
    //    //ms_instance.gameObject.SetActive(true);
    //}

    private void Awake()
    {
        ms_instance = this;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
       // Scene scene=SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
       // StageSelectManager.StartStageSelectManager();
        
        }
    }
}
