using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListener : MonoBehaviour
{
    public enum SceneID
    {
        LOADING_SCENE = 0,
        MAIN_MENU,
        GAME_PLAY
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)SceneID.LOADING_SCENE);
        SceneManager.LoadSceneAsync((int)SceneID.MAIN_MENU);
    }

    public void LoadGamePlay()
    {
        SceneManager.LoadScene((int)SceneID.LOADING_SCENE);
        SceneManager.LoadSceneAsync((int)SceneID.GAME_PLAY);
    }

    public void LoadExitScreen()
    {
        
    }
    
}
