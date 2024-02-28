using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToLeft : MonoBehaviour
{
    float speed = 30f;
 

    void Update()
    {
       
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        
    }
}
