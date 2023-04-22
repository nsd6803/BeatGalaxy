using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, attackPower;
    public float moveSpeed;

    public Animator animator;
    public float attackInterval;

    void Update()
    {
        Move();
    }

    //Moving forward
    void Move()
    {
        transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
    }

    public void LoseHealth()
    {
        health--;
        if (health <= 0)
            Destroy(gameObject);
    }

}