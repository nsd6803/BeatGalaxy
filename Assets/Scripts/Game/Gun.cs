using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // префаб снаряда
    public float bulletSpeed = 10f; // скорость полета снаряда
    public float fireRate = 5f; // задержка между выстрелами
    private float nextFireTime = 1f; // время следующего выстрела
    public float bulletOffset = 0.5f;
    public float maxY = 10f;
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if(bulletPrefab.transform.position.y > 50) {
                
            }
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
        if (bullet.transform.position.y >= -maxY)
        {
            Destroy(bullet, 1.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
}