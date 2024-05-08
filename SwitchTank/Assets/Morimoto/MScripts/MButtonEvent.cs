using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MButtonEvent : MonoBehaviour
{
    [SerializeField]
    private Text m_label;

    private int m_conut = 0;

    void Start()
    {
        m_label.text = $"{m_conut}";
    }

    public void OnPressed()
    {
        m_conut++;
        m_label.text = $"{m_conut}";
    }
}
