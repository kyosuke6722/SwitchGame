using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    public GameObject effectPrefab;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jirai")
        {
           // GameOver.StartGameOver();
            //GameClear.StartGameClear();
            Destroy(gameObject, 0.2f);
            Destroy(collision.gameObject, 0.2f);
            GameObject effect=Instantiate(effectPrefab,transform.position,Quaternion.identity);

            Destroy(effect,2.0f);

        }
    }
}
