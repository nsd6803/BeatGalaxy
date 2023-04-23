using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public int health, attackPower;
    public float moveSpeed;
    public GameObject gameobject;
    private const float TIMER_MAX_TIME = 1f; //время таймера
    private float timerCurrentTime = TIMER_MAX_TIME;

    public PlanetHealth planetHealth;
    public GameObject hitEffect;
    private int damage_planet = 1;
    public CoinManager coinManager;
    public Animator animator;
    public float attackInterval;

    void Start()
    {
        gameobject = GameObject.Find("CoinBar");
        coinManager = gameobject.GetComponentInChildren<CoinManager>();
        planetHealth = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetHealth>();

    }

    void Update()
    {
        if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime; //уменьшаем внутреннюю переменную
        }
        else
        {
            timerCurrentTime = TIMER_MAX_TIME; //рестарт таймера
            Move(); //двигаемся или выполняем другую активность
        }
        

    }

    //Moving forward
    void Move()
    {
        transform.Translate((-transform.up * moveSpeed)/2);
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Planet")
        {
            Destroy(gameObject);
            planetHealth.Damage(damage_planet);
        }

        if (collider.gameObject.CompareTag("Bullet"))
        {
            GameObject effect = Instantiate(hitEffect, collider.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f); 
            Destroy(collider.gameObject);
            LoseHealth();

        }
    }

    public void LoseHealth()
    {
        health -= 10;
        if (health <= 0)
        {
            coinManager.coinCount += 5;
            coinManager.CoinStatus();
            Destroy(gameObject);
        }
    }
}