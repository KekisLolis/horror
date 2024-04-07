using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    private bool inReach;

    public GameObject pickUpText;
    private GameObject flashlight;

    public AudioSource pickUpSound;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        flashlight = GameObject.Find("flashlight");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            flashlight.GetComponent<FlashlightAdvanced>().batteries += 3;
            pickUpSound.Play();
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }
    }
}
