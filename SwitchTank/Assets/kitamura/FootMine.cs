using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMine : MonoBehaviour
{
    public GameObject myMine;

    Exploder exploder;

    private void Start()
    {
        exploder=myMine.GetComponent<Exploder>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tama")
        {
            Destroy(gameObject, 0.2f);
            exploder.enabled = true;
        }
    }

    
}
