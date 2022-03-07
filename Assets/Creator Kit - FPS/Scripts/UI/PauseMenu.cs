using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }
    private MenuNavigation navigation;
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        navigation = GetComponent<MenuNavigation>();
    }

    public void Display()
    {
        gameObject.SetActive(true);
        GameSystem.Instance.StopTimer();
        Controller.Instance.DisplayCursor(true);
        NewInputs.instace.SwitchUIButtons(true);
        navigation.ResetNavigation();
    }

    public void OpenEpisode()
    {
        if(LevelSelectionUI.Instance.IsEmpty())
            return;
        
        UIAudioPlayer.PlayPositive();
        gameObject.SetActive(false);
        LevelSelectionUI.Instance.DisplayEpisode();
    }
    public void SaveGame()
    {
        Controller.Instance.SaveDatas();
        ReturnToGame();
    }
    public void ReturnToGame()
    {
        UIAudioPlayer.PlayPositive();
        GameSystem.Instance.StartTimer();
        gameObject.SetActive(false);
        Controller.Instance.DisplayCursor(false);
        NewInputs.instace.SwitchUIButtons(false);
        navigation.ExitNavigation();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
