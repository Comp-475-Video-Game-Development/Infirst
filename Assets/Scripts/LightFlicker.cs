using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    private new Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}


    public float minFlickerSpeed;
    public float maxFlickerSpeed;

	// Update is called once per frame
	void Update () {
        flicker();
	}

    IEnumerator flicker()
    {
        light.intensity = 0;
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        light.intensity = 10;
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
    }
}
