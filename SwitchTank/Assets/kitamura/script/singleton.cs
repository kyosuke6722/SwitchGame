using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject[] playerIcons;
    private GameObject[] enemyBox;
    public int destroyCount = 1;
    public  int stageNum;


    public void Awake()
    {
        if (this != Instance)
        {
            //すでにインスタンスがあれば、削除
            Destroy(gameObject);
            return;
        }

        //シーンが変わってもゲームオブジェクトが消えないようにする
        DontDestroyOnLoad(gameObject);
    }
    public  void StageClear()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        print("敵の数:" + enemyBox.Length);

        if (enemyBox.Length == 0)
        {
            SceneManager.LoadScene("GameClear");
            stageNum++;
            Invoke(nameof(ChangeScene), 2.0f);
           

        }
    }
    public void PlayerFailed()
    {
        destroyCount--;
        if(destroyCount == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        Invoke(nameof(ChangeScene), 1.0f);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Stage" + stageNum);
    }
}
