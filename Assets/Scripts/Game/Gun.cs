using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ �������
    public float bulletSpeed = 10f; // �������� ������ �������
    public float fireRate = 5f; // �������� ����� ����������
    private float nextFireTime = 1f; // ����� ���������� ��������
    public float bulletOffset = 0.5f;
    public float maxY = 10f;
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if(bulletPrefab.transform.position.y > 50) {
                
            }
            nextFireTime = Time.time + fireRate; // ��������� ����� ���������� ��������
            Shoot(); // ����� ������ ��������
        }
    }

    private void Shoot()
    {
        Vector3 spawnPos = transform.position + transform.up * bulletOffset;

        // ������� ������ �� �������
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity, transform.parent);

        // ���������� ������ ������
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;

        // ���������, ��� ������ �� ����� �� ������� �����
        if (bullet.transform.position.y >= -maxY)
        {
            Destroy(bullet, 0.7f) ;
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