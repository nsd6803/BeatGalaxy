using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBasic : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public float moveSpeed;
    private const float TIMER_MAX_TIME = 1f; //время таймера
    private float timerCurrentTime = TIMER_MAX_TIME;

    public HealthBar healthBarPrefab;
    public HealthBar healthBar;
    public PlanetHealth planetHealth;

    private int damage_planet = 1;
    public int attackDamage = 1;
    public int EnragedAttackDamage = 10;


    public float attackRange;
    public LayerMask attackMask;


    public Animator animator;
    private bool planetDestroyed = false;
    public float attackDuration; // длительность атаки
    private float attackTimer = 0f; // таймер для контроля длительности атаки
    private bool isAttacking = false; // флаг для определения, выполняется ли атака в данный момент

    public void Attack()
    {
        if (!isAttacking && !planetDestroyed)
        {
            isAttacking = true;
            attackTimer = attackDuration;

            // остановить движение босса
            moveSpeed = 0;

            // проиграть анимацию атаки
            animator.SetTrigger("BasicAttack");
            GameObject planet = GameObject.FindWithTag("Planet");
            planet.GetComponent<PlanetHealth>().Damage(attackDamage);

            if (planet.GetComponent<PlanetHealth>().pl_health <= 0)
            {
                planetDestroyed = true; // Устанавливаем флаг, что планета уничтожена
            }
        }
 
    }
    public void EnragedAttack()
    {
        if (!isAttacking && !planetDestroyed)
        {
            isAttacking = true;
            attackTimer = attackDuration;

            // остановить движение босса
            moveSpeed = 0;

            // проиграть анимацию атаки
            animator.SetTrigger("BasicAttack");
            GameObject planet = GameObject.FindWithTag("Planet");
            planet.GetComponent<PlanetHealth>().Damage(EnragedAttackDamage);

            if (planet.GetComponent<PlanetHealth>().pl_health <= 0)
            {
                planetDestroyed = true; // Устанавливаем флаг, что планета уничтожена
            }
        }
    }
    void Start()
    {
        currentHealth = maxHealth;
      //  healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        if (isAttacking)
        {
            // уменьшаем таймер атаки
            attackTimer -= Time.deltaTime;

            // если таймер атаки истек, завершаем атаку
            if (attackTimer <= 0f)
            {
                isAttacking = false;

                // восстановить движение босса
                
            }
        }
        else if(!planetDestroyed)
        {
            // двигаем босса, только если он не атакует
            if (timerCurrentTime > 0)
            {
                timerCurrentTime -= Time.deltaTime;
            }
            else
            {
                timerCurrentTime = TIMER_MAX_TIME;
                Move();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }

    }
    //Moving forward
    void Move()
    {
        transform.Translate(-transform.up * moveSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("damage");
        if (collider.gameObject.name == "Planet")
        {
            Debug.Log("BOOM");
            planetHealth.Damage(damage_planet);
        }

        if (collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("BOOM");
            LoseHealth(1);
        }
    }



    public void LoseHealth(int damage)
    {
        currentHealth -= damage;

        //  healthBar.SetHealth(currentHealth);

        if (currentHealth <= 25)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

      //  healthBar.SetHealth(currentHealth);

        if (currentHealth <= 25)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }
        if (currentHealth <= 0) 
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
