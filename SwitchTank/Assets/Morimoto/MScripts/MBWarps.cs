using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MBWarps : MonoBehaviour
{
    [SerializeField]
    private GameObject m_End = null;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            col.transform.position = new Vector3(m_End.transform.position.x, col.transform.position.y, m_End.transform.position.z);
        }

    }
}
