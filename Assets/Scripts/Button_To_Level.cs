using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button_To_Level : MonoBehaviour
{
    public void Level()
    {
        Debug.Log("Level");
        SceneManager.LoadScene("Level_1");
    }
}
