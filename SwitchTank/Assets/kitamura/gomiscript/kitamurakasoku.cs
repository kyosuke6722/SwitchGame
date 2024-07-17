using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitamurakasoku : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-100, 0, 0), ForceMode.VelocityChange);
    }
}
