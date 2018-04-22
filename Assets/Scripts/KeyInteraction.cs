using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject KeyText;
    public GameObject KeyPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            KeyText.SetActive(false);
            Destroy(KeyPrefab);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KeyText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KeyText.SetActive(false);
        }
    }
}