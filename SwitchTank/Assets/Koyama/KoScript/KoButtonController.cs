using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoButtonController : MonoBehaviour
{
    public List<Button> m_buttons;
    private int m_selectedButtonIndex=0;
    private MPFT_NTD_MMControlSystem m_controlSystem = null;

    private void Awake()
    {
        UpdateButtonSelection();
        m_controlSystem = GetComponent<MPFT_NTD_MMControlSystem>();
    }

    void OnNavigateUp()
    {
        //m_selectedButtonIndex = (m_selectedButtonIndex - 1 + m_buttons.Count) % m_buttons.Count;
        m_selectedButtonIndex = Mathf.Min(m_selectedButtonIndex + 1, m_buttons.Count);
        UpdateButtonSelection();
    }

    void OnNavigateDown()
    {
        //m_selectedButtonIndex=(m_selectedButtonIndex + 1) % m_buttons.Count;
        m_selectedButtonIndex = Mathf.Max(0, m_selectedButtonIndex - 1);
        UpdateButtonSelection();
    }

    void OnSelect()
    {
        m_buttons[m_selectedButtonIndex].onClick.Invoke();
    }

    void UpdateButtonSelection()
    {
        //全てのボタンの選択状態をリセット
        foreach(var button in m_buttons)
        {
            button.GetComponent<Image>().color = Color.white;
        }

        //現在選択されているボタンをハイライト
        m_buttons[m_selectedButtonIndex].GetComponent<Image>().color = Color.yellow;
    }

    private void Update()
    {
        if (m_controlSystem.MMGamePad[1].MM_Analog_X > 0)
        {
            OnNavigateUp();
        }
        else if (m_controlSystem.MMGamePad[1].MM_Analog_X < 0)
        {
            OnNavigateDown();
        }

        if (m_controlSystem.MMGamePad[1].MM_Right_A)
        {
            OnSelect();
        }
    }
}
