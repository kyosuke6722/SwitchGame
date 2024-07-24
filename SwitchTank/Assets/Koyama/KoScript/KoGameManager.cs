using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoGameManager : MonoBehaviour
{
    private static KoGameManager ms_instance=null;

    public static KoGameManager instance { get { return ms_instance; } }

    //残機
    public const int DefaultLife = 3;
    private static int m_life = DefaultLife;

    public int GetLife()
    {
        return m_life;
    }

    public void SetLife(int life)
    {
        m_life = life;
    }

    public enum GameState
    {
        State_Game,
        State_GameClear,
        State_GameOver
    }

    private static GameState m_state;

    public GameState GetGameState()
    {
        return m_state;
    }

    public void SetGameState(GameState gameState)
    {
        m_state = gameState;
    }

    private void Awake()
    {
        SetGameState(GameState.State_Game);
        if (ms_instance == null)
        {
            ms_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //カーソルをロック&非表示
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
