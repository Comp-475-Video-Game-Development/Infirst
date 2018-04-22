using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInteraction : MonoBehaviour
{
    public Text DoorText;
    public GameObject KeyText;
    public GameObject KeyPrefab;
    bool inProximity = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inProximity)
        {
            KeyText.SetActive(false);
            DoorText.text = "Press F to open";
            Destroy(KeyPrefab);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inProximity = true;
            KeyText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inProximity = false;
            KeyText.SetActive(false);
        }
    }
}