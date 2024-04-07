using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class FlashlightAdvanced : MonoBehaviour
{
    public new Light light;
    public GameObject batteryCharge;
    public GameObject battery100;
    public GameObject battery80;
    public GameObject battery50;
    public GameObject battery25;
    public GameObject battery0;
    public TMP_Text text;
    public TMP_Text batteryText;

    public float lifetime = 100;
    public float batteries = 0;

    public AudioSource flashOn;
    public AudioSource flashOff;

    public bool on;
    public bool off;
    
    void Start()
    {
        light = GetComponent<Light>();
        off = true;
        light.enabled = false;
    }

    void Update()
    {
        text.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();

        if(Input.GetButtonDown("flashlight") && off)
        {
            flashOn.Play();
            light.enabled = true;
            on = true;
            off = false;
        }

        else if (Input.GetButtonDown("flashlight") && on)
        {
            flashOff.Play();
            light.enabled = false;
            on = false;
            off = true;
        }

        if (on)
        {
            lifetime -= 1 * Time.deltaTime;
        }

        if(lifetime <= 0)
        {
            battery0.SetActive(true);
            light.enabled = false;
            on = false;
            off = true;
            lifetime = 0;
        }

        if (lifetime >= 100)
        {
            battery100.SetActive(true);
            lifetime = 100;
        }
        else if (lifetime >= 75)
        {
            battery100.SetActive(false);
            battery80.SetActive(true);
        }
        else if (lifetime >= 40)
        {
            battery80.SetActive(false);
            battery50.SetActive(true);
        }
        else if (lifetime >= 15)
        {
            battery50.SetActive(false);
            battery25.SetActive(true);
        }

        if (Input.GetButtonDown("reload") && batteries >= 1)
        {
            batteries -= 1;
            lifetime += 99;
        }

        if (Input.GetButtonDown("reload") && batteries == 0)
        {
            return;
        }

        if(batteries <= 0)
        {
            batteries = 0;
            batteryCharge.SetActive(false);
        }
        else
        {
            batteryCharge.SetActive(true);
        }
    }
}