using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    //private static GameClear ms_instane = null;
    private GameObject[] enemyBox;

   /* public static bool IsGameClear()
    {
        return ms_instane.gameObject.activeSelf;
    }
    public static void StartGameClear()
    {
        ms_instane.gameObject.SetActive(true);
    }

    private void Awake()
    {
        ms_instane = this;
        gameObject.SetActive(false);
    }*/
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        print("�G�̐�:"+enemyBox.Length);

        if(enemyBox.Length == 0 ) {
             SceneManager.LoadScene("GameClear");
            //Scene scene = SceneManager.GetActiveScene();
           // StartGameClear();

        }

    }
}
