using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    [Header("Pause Setting")]
    public GameObject PausePanle;

    private bool pauseGame = false;
    public void StartAndRestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        pauseGame = true;
        PausePanle.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        pauseGame = false;
        PausePanle.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Shop()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
