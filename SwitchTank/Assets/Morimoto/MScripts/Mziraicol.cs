using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mziraicol : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        Destroy(col.gameObject);
            Destroy(this.gameObject);
    }
}
