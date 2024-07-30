using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSelectStages : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_stagelist = new List<GameObject>();

    public static int m_stages = 0;

    private void Awake()
    {
        Instantiate(m_stagelist[m_stages], transform.position, Quaternion.identity);
    }
}
