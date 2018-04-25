using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject ConfirmQuitPanel;

    public void LoadAsylum()
    {
        Debug.Log("Loading Asylum");
        SceneManager.LoadScene("Asylum");
    }

    public void ExitToDesktop()
    {
        ConfirmQuitPanel.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void DenyQuit()
    {
        ConfirmQuitPanel.SetActive(false);
    }
}