using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public int health, attackPower;
    public float moveSpeed;
    public GameObject gameobject;
    private const float TIMER_MAX_TIME = 1f; //время таймера
    private float timerCurrentTime = TIMER_MAX_TIME;

    public Animator animator;
    public float attackInterval;
    public GameObject hitEffect;
    public PlanetHealth planetHealth;
    public CoinManager coinManager;
    private int moving_direction = 0;
    private int damage_planet = 1;

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
        if (moving_direction == 0)
        {
            transform.Translate((-transform.up * moveSpeed)/2);
            moving_direction += 1;
        }
        else if (moving_direction == 1)
        {
            transform.Translate((transform.right * moveSpeed)/2);
            moving_direction += 1;
        }
        else if (moving_direction == 2)
        {
            transform.Translate((-transform.up * moveSpeed)/2);
            moving_direction += 1;
        }
        else if (moving_direction == 3)
        {
            transform.Translate((-transform.right * moveSpeed)/2);
            moving_direction = 0;
        }
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