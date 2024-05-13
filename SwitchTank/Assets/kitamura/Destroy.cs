using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject effectPrefab;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tama")
        {

            Destroy(gameObject, 0.2f);
           // GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            
           // Destroy(effect, 2.0f);

        }
    }
}
