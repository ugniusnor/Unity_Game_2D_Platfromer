using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
 public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Scene_GameOver");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Scene_Menu");
        Time.timeScale = 1;
    }
}
