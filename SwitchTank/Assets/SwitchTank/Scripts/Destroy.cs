using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip se;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            Destroy(gameObject, 0.2f);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(se, transform.position);
            // Destroy(effect, 2.0f);

        }
    }
}
