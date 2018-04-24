using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public GameObject GameOverPanel;

    public void PlayAgain()
    {
        DoorInteraction.isGameOver = false;
        GameOverPanel.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}