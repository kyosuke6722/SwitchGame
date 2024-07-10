using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mtexttest : MonoBehaviour
{
    [SerializeField]
    private Text m_textP1;
    [SerializeField]
    private Text m_textP2;
    [SerializeField]
    private int m_type = 0;

    private void Update()
    {
        switch (m_type)
        {
            case 1:
                m_textP1.text = "m_count   : " + MNozzleControllerVS.m_count;
                break;
            case 2:
                m_textP2.text = "m_countVS : " + MNozzleControllerVS.m_countVS;
                break;
        }
    }
}
