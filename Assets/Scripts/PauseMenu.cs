using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject PlayerController;

    private void Start()
    {
        ResumeGame();
    }

    private void Update()
    {
        if (DoorInteraction.isGameOver)
        {
            GameOverPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !DoorInteraction.isGameOver)
        {
            if (!PausePanel.activeInHierarchy)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        PlayerController.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        PlayerController.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}