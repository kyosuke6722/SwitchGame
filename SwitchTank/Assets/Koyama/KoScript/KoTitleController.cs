using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoTitleController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Koyama");
        }
    }
}
