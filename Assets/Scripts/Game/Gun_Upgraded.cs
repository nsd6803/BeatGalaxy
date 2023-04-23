using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Upgraded : MonoBehaviour
{
    public GameObject bulletPrefab_1; // ������ �������
    public GameObject bulletPrefab_2;
    public float bulletSpeed = 10f; // �������� ������ �������
    public float fireRate = 20f; // �������� ����� ����������
    private float nextFireTime = 0f; // ����� ���������� ��������
    public float bulletOffset = 0.5f;
    public float maxY = 10f;
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // ��������� ����� ���������� ��������
            Shoot(); // ����� ������ ��������
        }
    }

    private void Shoot()
    {
        Vector3 spawnPos_1 = transform.position + transform.up * bulletOffset + -transform.right * bulletOffset;
        Vector3 spawnPos_2 = transform.position + transform.up * bulletOffset + transform.right * bulletOffset;
        // ������� ������ �� �������
        GameObject bullet = Instantiate(bulletPrefab_1, spawnPos_1, Quaternion.identity, transform.parent);
        GameObject bullet2 = Instantiate(bulletPrefab_2, spawnPos_2, Quaternion.identity, transform.parent);
        // ���������� ������ ������
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        bullet2.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        // ���������, ��� ������ �� ����� �� ������� �����
        //if (bulletPrefab.transform.position.y > 80f)
        //{
        //    Destroy(bulletPrefab);
        //}
        if (bullet.transform.position.y >= -maxY)
        {
            Destroy(bullet, 1f);
            Destroy(bullet2, 1f);
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
