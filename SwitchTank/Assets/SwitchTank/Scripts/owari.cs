using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owari : MonoBehaviour
{
    public GameObject JiraiEffectPrefab;
    public GameObject BulletEffectPrefab;
    public AudioClip se;
    // public GameObject GameManager;

    // private PlayerCount PlayerCount;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jirai")
        {
            //GameOver.StartGameOver();
            //PlayerCount.StageClear();
            Destroy(gameObject, 0.2f);
            Destroy(collision.gameObject, 0.2f);
            //AudioSource.PlayClipAtPoint(se, transform.position);
            GameObject effect=Instantiate(JiraiEffectPrefab,transform.position,Quaternion.identity);

            Destroy(effect,2.0f);

        }
        if (collision.gameObject.tag == "Bullet")
        {
            
            GameObject effect = Instantiate(BulletEffectPrefab, transform.position, Quaternion.identity);

            Destroy(effect, 2.0f);

        }
    }
}
