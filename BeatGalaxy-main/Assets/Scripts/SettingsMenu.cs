using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SettingsMenu : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }
    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
