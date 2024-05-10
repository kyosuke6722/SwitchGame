using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] _stageButton;
    private static StageSelectManager ms_instance = null;
    public static bool IsStageSelectManagerr()
    {
        return ms_instance.gameObject.activeSelf;
    }
    public static void StartStageSelectManager()
    {
        ms_instance.gameObject.SetActive(true);
    }
    void Start()
    {
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock",1);

        for(int i=0;i< _stageButton.Length;i++)
        {
            if (i < stageUnlock)
                _stageButton[i].interactable = true;
            else
                _stageButton[i].interactable = false;
        }
    }
    public void StageSelect(int stage)
    {
        SceneManager.LoadScene(stage);
    }
}
