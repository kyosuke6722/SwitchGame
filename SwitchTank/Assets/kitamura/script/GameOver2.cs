using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver2 : MonoBehaviour
{
    private GameObject[] PlayerBox;
    void Update()
    {
        PlayerBox = GameObject.FindGameObjectsWithTag("Player");

        print("ÉvÉåÉCÉÑÅ[:" + PlayerBox.Length);

        if (PlayerBox.Length == 0)
        {
            SceneManager.LoadScene("GameClear");
            //Scene scene = SceneManager.GetActiveScene();
            // StartGameClear();

        }

    }
}
