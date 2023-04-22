using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level_Selection");
    }

    public void BackButton() {
        SceneManager.LoadScene("Menu");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("Level_1");
    }
}
