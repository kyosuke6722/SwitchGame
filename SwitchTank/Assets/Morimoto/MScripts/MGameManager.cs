using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player1 = null;
    [SerializeField]
    private GameObject m_player2 = null;
    [SerializeField]
    private Canvas m_canvaswin = null;
    [SerializeField]
    private Canvas m_canvaslose = null;

    private bool m_isPrint = false;

    private void Start()
    {
        m_canvaswin.gameObject.SetActive(false);
        m_canvaslose.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!m_isPrint && m_player1==null|| !m_isPrint && m_player2 == null)
        {
            m_isPrint = true;
            On();
        }
    }

    private void On()
    {
        if (m_player1 == null)
        {
            m_canvaslose.gameObject.SetActive(true);
        }
        else if(m_player2 == null)
        {
            m_canvaswin.gameObject.SetActive(true);
        }
    }

}
