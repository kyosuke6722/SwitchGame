using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class MGameManager : MonoBehaviour
{
    [SerializeField]
    private int m_mode = 1;
    [SerializeField]
    private GameObject m_player1 = null;
    [SerializeField]
    private GameObject m_player2 = null;
    [SerializeField]
    private GameObject m_player3 = null;
    [SerializeField]
    private GameObject m_player4 = null;
    [SerializeField]
    private Canvas m_canvas = null;
    [SerializeField]
    private Button m_buttonwin = null;
    [SerializeField]
    private Text m_textwin = null;
    [SerializeField]
    private Text m_textlose = null;

    private bool m_isPrint = false;

    private void Start()
    {
        m_canvas.gameObject.SetActive(false);
        m_textwin.gameObject.SetActive(false);
        m_textlose.gameObject.SetActive(false);
        if (m_mode==2)
        {
            m_buttonwin.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(!m_isPrint && m_player1==null|| !m_isPrint && m_player2 == null && !m_isPrint && m_player3 == null && !m_isPrint && m_player4 == null)
        {
            m_isPrint = true;
            On();
        }
    }

    private void On()
    {
        switch (m_mode) {
            case 1:
                m_canvas.gameObject.SetActive(true);
                if (m_player1 == null)
                {
                    m_textlose.gameObject.SetActive(true);
                }
                else if (m_player2 == null)
                {
                    m_textwin.gameObject.SetActive(true);
                }
                break;
            case 2:
                m_canvas.gameObject.SetActive(true);
                if (m_player1 == null)
                {
                    m_textlose.gameObject.SetActive(true);
                }
                else if (m_player2 == null && m_player3 == null && m_player4 == null)
                {
                    m_textwin.gameObject.SetActive(true);
                    m_buttonwin.gameObject.SetActive(true);
                }
                break;
        }
    }

}
