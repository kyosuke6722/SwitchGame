using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoEnemyManager : MonoBehaviour
{
    private List<GameObject> m_enemies = new List<GameObject>();
    [SerializeField]
    private string clear_scene;

    public void AddEnemy(GameObject enemy)
    {
        m_enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        m_enemies.Remove(enemy);
        CheckAllEnemiesDefeated();
    }

    private void CheckAllEnemiesDefeated()
    {
        if (m_enemies.Count == 0&&KoGameManager.instance.GetGameState()==KoGameManager.GameState.State_Game)
        {
            KoGameClear.instance.StartGameClear();
            //SceneManager.LoadScene(clear_scene);
        }
    }
}
