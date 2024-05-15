using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MEnemyStay : MonoBehaviour
{
    [SerializeField]
    public Transform m_player = null;

    [SerializeField]
    public Transform m_enemy = null;

    private void Update()
    {
        m_enemy.LookAt(m_player);
    }
}
