using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private int count = 0;

    public GameObject panel;
    
    // Start is called before the first frame update
    public void Settings()
    {
        
        if (count == 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
            count = 1;
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }
        else if (count == 1)
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
            count = 0;
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Play();
            }
        }

    }
}
