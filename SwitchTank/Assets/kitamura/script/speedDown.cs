using System.Collections;
using UnityEngine;

public class speedDown : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 100), ForceMode.VelocityChange);
    }
}
