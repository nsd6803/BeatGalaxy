using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // префаб снаряда
    public float bulletSpeed = 10f; // скорость полета снаряда
    public float fireRate = 20f; // задержка между выстрелами
    private float nextFireTime = 0f; // время следующего выстрела
    public float bulletOffset = 0.5f;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // обновляем время следующего выстрела
            Shoot(); // вызов метода стрельбы
        }
    }

    private void Shoot()
    {
        Vector3 spawnPos = transform.position + transform.up * bulletOffset;

        // Создаем снаряд из префаба
        bulletPrefab = Instantiate(bulletPrefab, spawnPos, Quaternion.identity, transform.parent);

        // Направляем снаряд вперед
        bulletPrefab.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;

        // Проверяем, что снаряд не вышел за границы сцены
        if (bulletPrefab.transform.position.y > 80f)
        {
            Destroy(bulletPrefab);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy_1>().LoseHealth();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("BossDied");
            collision.gameObject.GetComponent<BossBasic>().LoseHealth(1);
            Destroy(gameObject);
        }
    }
}