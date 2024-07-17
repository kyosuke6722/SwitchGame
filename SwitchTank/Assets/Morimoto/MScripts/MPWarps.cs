using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MPWarps : MonoBehaviour
{
    [SerializeField]
    private GameObject m_End = null;

    private float distance = 1.6f;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (Vector3.Distance(transform.position, col.transform.position) > distance)
        {
            if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "Bullet")
            {
                col.transform.position = new Vector3(m_End.transform.position.x, col.transform.position.y, m_End.transform.position.z);
            }
        }
    }
}
