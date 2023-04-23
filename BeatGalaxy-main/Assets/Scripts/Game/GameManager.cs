using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { instance = this; }

    public Spawner spawner;

    void Start()
    {


        StartCoroutine(WaveStartDelay());
    }

    IEnumerator WaveStartDelay()
    {
        //Wait for X seconds
        yield return new WaitForSeconds(2f);
        //Start the enemy spawning
       // GetComponent<EnemySpawner>().StartSpawning();
    }

}