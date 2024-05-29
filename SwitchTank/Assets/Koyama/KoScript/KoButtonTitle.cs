using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoButtonTitle : MonoBehaviour
{
    public void OnClickEnter()
    {
        KoGameOver.SetLife(KoGameOver.DefaultLife);
        SceneManager.LoadScene("KoTitle");
    }
}
