using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_2 : MonoBehaviour
{
    public GameObject firstPrefab; // ссылка на первый префаб
    public GameObject newObject; // ссылка на новый объект

    private void OnTriggerEnter2D(Collider2D collider)
    {

            // создаем новый объект и удаляем два старых
        Instantiate(newObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(collider.gameObject);

    }

}
