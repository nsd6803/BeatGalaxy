using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlanetHealth : MonoBehaviour
{

    public int pl_health = 0;

    void Update()
    {
        if(pl_health == 0)
        {
            Defeat();
        }
    }

    public void Defeat()
    {
        SceneManager.LoadScene("Defeat");
    }
}
