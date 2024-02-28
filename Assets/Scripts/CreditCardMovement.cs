using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCardMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float xRange = 7f;

    // Update is called once per frame
    void Update()
    {



            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x < -xRange)
            {
           
              transform.position = new Vector3((-xRange+1), transform.position.y, transform.position.z);
            speed = -speed;

            }
            else if (transform.position.x > xRange)
            {
              
               transform.position = new Vector3((xRange-1), transform.position.y, transform.position.z);
            speed = -speed;

            }

        







    }
}
