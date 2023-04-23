using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    public int health, attackPower;
    public float moveSpeed;
    public GameObject hitEffect;
    private const float TIMER_MAX_TIME = 1f; //����� �������
    private float timerCurrentTime = TIMER_MAX_TIME;
    public GameObject gameobject;
    public Animator animator;
    public float attackInterval;
    public CoinManager coinManager;
    public PlanetHealth planetHealth;

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
            timerCurrentTime -= Time.deltaTime; //��������� ���������� ����������
        }
        else
        {
            timerCurrentTime = TIMER_MAX_TIME; //������� �������
            Move(); //��������� ��� ��������� ������ ����������
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
            Destroy(effect, 0.5f); // 
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