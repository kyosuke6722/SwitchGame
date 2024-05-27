using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoGameOver : MonoBehaviour
{
    //[SerializeField]
    //private GameObject m_player;

    private static KoGameOver ms_instance = null;
    //�c�@
    public int m_remaining;

    public static void StartGameOver()
    {
        ms_instance.gameObject.SetActive(true);
    }

    private void Awake()
    {
        if (ms_instance == null)
        {
            ms_instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        ////�v���C���[�����Ȃ��Ȃ����Ƃ�
        //if(!m_player)
        //{
        //    //�Q�[���I�[�o�[
        //    //Invoke("GameOver", 2.0f);
        //}
    }
}
