using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject resume;
    public GameObject quit;
    public AudioSource pause;

    public bool on;
    public bool off;

    void Start()
    {
        menu.SetActive(false);
        off = true;
        on = false;
    }
    
    void Update()
    {
        if (off && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 0;
            pause.Play();
            menu.SetActive(true);
            off = false;
            on = true;
        }

        else if (on && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1;
            pause.Pause();
            menu.SetActive(false);
            off = true;
            on = false;
        }
    }

    public void Resume()
    {
            Time.timeScale = 1;
            pause.Pause();
            menu.SetActive(false);
            off = true;
            on = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}