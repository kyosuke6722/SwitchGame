using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owari : MonoBehaviour
{
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jirai")
        {
            //GameOver.StartGameOver();
            GameClear.StartGameClear();
            Destroy(gameObject, 0.2f);

        }
    }
}
