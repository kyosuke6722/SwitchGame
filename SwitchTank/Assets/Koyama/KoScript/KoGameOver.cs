using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoGameOver : MonoBehaviour
{
    private static KoGameOver ms_instance = null;

    //Žc‹@
    public const int DefaultLife=3;
    private static int m_life=DefaultLife;

    [SerializeField]
    private KoLifePanel m_lifePanel;

    public static int GetLife()
    {
        return m_life;
    }

    public static void SetLife(int life)
    {
        m_life = life;
    }

    public static void StartGameOver()
    {
        m_life--;
        ms_instance.gameObject.SetActive(true);
    }

    private void Awake()
    {
        if (ms_instance == null)
        {
            ms_instance = this;
            DontDestroyOnLoad(gameObject);
            this.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        m_lifePanel.UpdateLife(m_life);
    }
}
