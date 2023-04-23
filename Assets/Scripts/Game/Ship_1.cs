using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_1 : MonoBehaviour
{
    public GameObject newPrefab_1;
    public GameObject newPrefab_2;
    public GameObject newPrefab_3;
    public Ship_1 ship1;
    public bool collidedWithShip2 = false;
    public bool collidedWithShip3 = false;
    public bool collidedWithShip4 = false;
    public GameObject sh1;
    public GameObject sh2;
    public GameObject sh3;
    public Vector3 ship3_pos;
    public Vector3 ship2_pos;
    public Vector3 ship4_pos;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ship_2"))
        {
            sh2 = other.gameObject;
            collidedWithShip2 = true;
            ship2_pos = other.transform.position;
            CheckCollision();
        }


        if (other.CompareTag("Ship_3"))
        {
            sh3 = other.gameObject;
            collidedWithShip3 = true;
            ship3_pos = other.transform.position;
            CheckCollision();
        }

        if (other.CompareTag("Ship")) 
        { 
           
            ship1 = other.GetComponent<Ship_1>();

            collidedWithShip4 = true;
            ship4_pos = other.transform.position;
            if (ship1 != null && ship1.collidedWithShip2)
            {
                CheckCollision();
            }
        }
    



        if (other.CompareTag("Ship_2") && collidedWithShip3 == false)
        {
            Vector3 pos1 = transform.position;
            Vector3 pos2 = other.transform.position;
            if (pos2.x > pos1.x) // если второй префаб справа от основного
            {
                // удаление старых объектов
                Destroy(gameObject);
                Destroy(other.gameObject);
                // создание нового объекта в центре между двумя старыми
                Vector3 newPos = (pos1 + pos2) / 2;
   
                Instantiate(newPrefab_1, newPos, Quaternion.identity, transform.parent);
            }
        }

    }



    private void CheckCollision()
    {
        if (collidedWithShip2 && collidedWithShip3)
        {

            Vector3 pos1 = transform.position;

            if (ship3_pos.x > pos1.x && ship2_pos.y > pos1.y)
            {

                // удаление старых объектов
                Destroy(gameObject);
                Destroy(sh3);
                Destroy(sh2);
                Destroy(sh1);
                // создание нового объекта в центре между двумя старыми
                Vector3 newPos = (pos1 + ship2_pos + ship3_pos) / 3;
                Instantiate(newPrefab_2, newPos, Quaternion.identity, transform.parent);
            }
        }

        else if (collidedWithShip3  && ship1 != null)
        {
            if (ship1.collidedWithShip2)
            {
                Vector3 pos1 = transform.position;

                if (ship1.transform.position.x > pos1.x && pos1.y < ship3_pos.y && ship1.transform.position.y < ship1.ship2_pos.y)
                {
                    Vector3 newPos = (pos1 + ship1.ship2_pos + ship3_pos + ship1.transform.position) / 4;
                    // удаление старых объектов
                    Destroy(gameObject);
                    Destroy(ship1.sh2);
                    Destroy(sh3);
                    Destroy(ship1.gameObject);
                    Destroy(sh1);
                    // создание нового объекта в центре между двумя старыми

                    Instantiate(newPrefab_3, newPos, Quaternion.identity, transform.parent);
                }
            }
        }

        
    }
}