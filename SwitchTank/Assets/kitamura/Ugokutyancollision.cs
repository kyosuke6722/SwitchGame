using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ugokutyanfloor")
        {
            this.gameObject.transform.parent = floor.gameObject.transform;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "ugokutyanfloor")
        {
            this.gameObject.transform.parent = null;
        }
    }
}