using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject ConfirmQuitPanel;
    public GameObject LoadingPanel;

    public void LoadAsylum()
    {
        Debug.Log("Loading Asylum");
        LoadingPanel.SetActive(true);
        StartCoroutine(LoadAsylumScene());
        //SceneManager.LoadScene("Asylum");
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

    private IEnumerator LoadAsylumScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Asylum");

        while (!async.isDone)
        {
            yield return null;
        }
    }
}