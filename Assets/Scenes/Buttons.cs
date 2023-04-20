using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }


    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
