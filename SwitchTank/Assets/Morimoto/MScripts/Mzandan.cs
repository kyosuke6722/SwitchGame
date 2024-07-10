using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mzandan : MonoBehaviour
{
    [SerializeField]
    private GameObject[] P1bulletArray = new GameObject[5];
    [SerializeField]
    private GameObject[] P2bulletArray = new GameObject[5];
    public static int m_maxP1bullet = 5;
    public static int m_maxP2bullet = 5;
    public static int m_minP1bullet = 0;
    public static int m_minP2bullet = 0;
    public static bool m_isP1Shot = false;
    public static bool m_isP1Reload = false;
    public static bool m_isP2Shot = false;
    public static bool m_isP2Reload = false;

    private void Update()
    {
        if (m_isP1Shot && MNozzleControllerVS.m_count <= m_maxP1bullet && MNozzleControllerVS.m_count >= m_minP1bullet)
        {
            P1bulletArray[MNozzleControllerVS.m_count].SetActive(false);
            m_isP1Shot = false;
        }
        if (m_isP2Shot && MNozzleControllerVS.m_countVS <= m_maxP2bullet && MNozzleControllerVS.m_countVS >= m_minP2bullet)
        {
            P2bulletArray[MNozzleControllerVS.m_countVS].SetActive(false);
            m_isP2Shot = false;
        }

        if (m_isP1Reload && MNozzleControllerVS.m_count <= m_maxP1bullet && MNozzleControllerVS.m_count >= m_minP1bullet)
        {
            if (MNozzleControllerVS.m_count >= 1)
                P1bulletArray[MNozzleControllerVS.m_count-1].SetActive(true);
            if (MBulletVS.m_isbulletcol && MNozzleControllerVS.m_count >= 2)
            {
                P1bulletArray[MNozzleControllerVS.m_count - 2].SetActive(true);
                MBulletVS.m_isbulletcol = false;
            }
            m_isP1Reload = false;
        }
        if (m_isP2Reload && MNozzleControllerVS.m_countVS <= m_maxP2bullet && MNozzleControllerVS.m_countVS >= m_minP2bullet)
        {
            if(MNozzleControllerVS.m_countVS >= 1)
                P2bulletArray[MNozzleControllerVS.m_countVS-1].SetActive(true);
            if (MBulletVS.m_isbulletcol && MNozzleControllerVS.m_countVS >= 2)
            {
                P2bulletArray[MNozzleControllerVS.m_countVS - 2].SetActive(true);
                MBulletVS.m_isbulletcol = false;
            }
            m_isP2Reload = false;
        }
    }
}
