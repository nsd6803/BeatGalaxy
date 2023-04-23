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
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity, transform.parent);

        // Направляем снаряд вперед
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;

        // Проверяем, что снаряд не вышел за границы сцены
        if (bullet.transform.position.y > 80f)
        {
            Destroy(bullet);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<Enemy_1>().LoseHealth();
            Destroy(bulletPrefab);
        }
    }
}