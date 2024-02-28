using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMovement : MonoBehaviour
{
    [SerializeField] List<Transform> positions = new List<Transform>();
   float speed = 30f;
    
    
    void Update()
    {
      //  int a = getMoney.Positions .Count - 1;

        for (int i = 1; i < 38; i++)
        {
            Vector3 targetPos = positions[i-1].transform.position;
            targetPos.z = positions [i].transform.position.z;
            positions [i].transform.position = Vector3.Lerp(positions [i].transform.position, targetPos,  speed* Time.deltaTime );
        }
    }
}
