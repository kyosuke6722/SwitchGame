using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoGameClear : MonoBehaviour
{
    private static KoGameClear ms_instance=null;

    public static void StartGameClear()
    {
        ms_instance.gameObject.SetActive(true);
    }

    private void Awake()
    {
        if(ms_instance==null)
        {
            ms_instance = this;
            this.gameObject.SetActive(false);
        }
    }
}
