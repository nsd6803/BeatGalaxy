using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlanetHealth : MonoBehaviour
{

    public int pl_health = 5;

    public void Damage(int damage)
    {
        
        pl_health -= damage;

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
