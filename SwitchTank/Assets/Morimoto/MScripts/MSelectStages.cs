using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSelectStages : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_stagelist = new List<GameObject>();

    private void Awake()
    {
        Instantiate(m_stagelist[16], transform.position, Quaternion.identity);
    }
}
