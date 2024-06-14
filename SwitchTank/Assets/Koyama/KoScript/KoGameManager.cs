using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoGameManager : MonoBehaviour
{
    public enum GameState
    {
        State_Game,
        State_GameClear,
        State_GameOver
    }

    private GameState m_state = GameState.State_Game;

    private GameObject m_player;
    private GameObject[] m_enemies;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        if (m_state != GameState.State_Game) return;

        if (!m_player)
        {
            KoGameOver.StartGameOver();
            m_state = GameState.State_GameOver;
        }
        else if(m_enemies.Length<=0)
        {
            KoGameClear.StartGameClear();
            m_state = GameState.State_GameClear;
        }
    }
}
