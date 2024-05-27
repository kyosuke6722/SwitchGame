using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver2 : MonoBehaviour
{
    
    private static GameOver2 ms_instance = null;

    /*public static bool IsGameOver()
   {
        return ms_instance.gameObject.activeSelf;
    }
    public static void StartGameOver()
    {
        ms_instance.gameObject.SetActive(true);
    }

    private void Awake()
    {
        ms_instance = this;
        gameObject.SetActive(false);
    }*/
    private GameObject[] PlayerBox;
    void Update()
    {
        PlayerBox = GameObject.FindGameObjectsWithTag("Player");

        print("ÉvÉåÉCÉÑÅ[:" + PlayerBox.Length);

        if (PlayerBox.Length == 0)
        {
            SceneManager.LoadScene("GameOver");
           // Scene scene = SceneManager.GetActiveScene();
            // StartGameOver();

        }

    }
}
