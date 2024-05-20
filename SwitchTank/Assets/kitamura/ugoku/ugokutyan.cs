using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ugokutyan : MonoBehaviour
{
    float x = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Swith2", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = new Vector3(x, 0, 0);
        transform.Translate(p);
    }
    void Swith()
    {
        x = 0.03f;
        Invoke("Swith2", 5.0f);
    }
    void Swith2()
    {
        x = -0.03f;
        Invoke("Swith", 5.0f);
    }
}
