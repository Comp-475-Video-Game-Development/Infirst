using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public GameObject DoorText;
    public GameObject Door;
    public GameObject Key;
    bool isDoorOpen = false;
    bool inProximity = false;

    private void Update()
    {
        // Only open door if:
        // door is closed,
        // player is within door's collider, and
        // the player has picked up the door's corresponding key
        if (Input.GetKeyDown(KeyCode.F) && !isDoorOpen && inProximity && Key == null)
        {
            DoorText.SetActive(false);
            DoorText.GetComponent<Text>().text = "It's locked... I need to find a key";
            isDoorOpen = true;
            Destroy(Door.GetComponent<BoxCollider>());
            InvokeRepeating("OpenDoor", 0f, .001f);
            Invoke("StopDoor", 0.5f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isDoorOpen)
        {
            inProximity = true;
            DoorText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inProximity = false;
            DoorText.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        Door.transform.Rotate(Vector3.down, Time.deltaTime * 80);
    }

    private void StopDoor()
    {
        CancelInvoke("OpenDoor");
    }
}