using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PlayerController;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(true);
                PlayerController.GetComponent<FirstPersonController>().enabled = false;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                PausePanel.SetActive(false);
                PlayerController.GetComponent<FirstPersonController>().enabled = true;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}