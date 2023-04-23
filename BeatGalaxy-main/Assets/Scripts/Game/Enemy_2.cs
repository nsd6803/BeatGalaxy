using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public int health, attackPower;
    public float moveSpeed;

    private const float TIMER_MAX_TIME = 1f; //время таймера
    private float timerCurrentTime = TIMER_MAX_TIME;

    public Animator animator;
    public float attackInterval;

    public PlanetHealth planetHealth;

    private int moving_direction = 0;
    private int damage_planet = 1;

    void Start()
    {
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
            transform.Translate(-transform.up * moveSpeed);
            moving_direction += 1;
        }
        else if (moving_direction == 1)
        {
            transform.Translate(transform.right * moveSpeed);
            moving_direction += 1;
        }
        else if (moving_direction == 2)
        {
            transform.Translate(-transform.up * moveSpeed);
            moving_direction += 1;
        }
        else if (moving_direction == 3)
        {
            transform.Translate(-transform.right * moveSpeed);
            moving_direction = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("BOOM");
        if (collider.gameObject.name == "Planet")
        {
            Debug.Log("BOOM");
            planetHealth.Damage(damage_planet);
        }
        if (collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("BOOM");
            LoseHealth();
        }
    }

    public void LoseHealth()
    {
        health -= 10;
        if (health <= 0)
            Destroy(gameObject);
    }
}