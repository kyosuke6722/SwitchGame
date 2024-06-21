using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoButtonTitle : MonoBehaviour
{
    public void OnClickEnter(string titleName)
    {
        KoGameManager.instance.SetLife(KoGameManager.DefaultLife);
        SceneManager.LoadScene(titleName);
    }
}
