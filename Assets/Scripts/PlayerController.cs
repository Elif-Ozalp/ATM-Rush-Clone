using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour


{
    [SerializeField] float horizontalInput;
    [SerializeField] private float xRange = 9.5f;
    [SerializeField] public float speed = 2f;
    MoveToFinish moveToFinish;
    [SerializeField] private Transform transformPlayer;
    //GetMoney getMoney;


    void Start()
    {
        moveToFinish  = FindObjectOfType <MoveToFinish >();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transformPlayer.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transformPlayer.position.x > xRange)
        {
            transformPlayer.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transformPlayer.position.x < -xRange)
        {
            transformPlayer.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        /*
       if(moveToFinish.Control == true)
       {
            gameObject.transform.parent = null;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            
       }*/

         /*int a = getMoney.moneys.Count - 1;

        for (int i = 0; i < a; i++)
        {
            Vector3 targetPos = getMoney.moneys[i + 1].transform.position;
            targetPos.z = getMoney.moneys[i].transform.position.z;
            getMoney.moneys[i + 1].transform.position = Vector3.Lerp(getMoney.moneys[i + 1].transform.position, targetPos, 0.5f * speed);
        }*/
    }
}
