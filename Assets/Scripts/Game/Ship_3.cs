using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_3 : MonoBehaviour
{

    public bool collidedWithShip3 = false;

    GameObject sh3;

    public Vector3 ship3_pos;


    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.CompareTag("Ship_2"))
        {
            Debug.Log("Red+Yellow");
            sh3 = other.gameObject;
            collidedWithShip3 = true;
            ship3_pos = other.transform.position;
        }
    }
}
