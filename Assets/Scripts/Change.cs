using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    [SerializeField] GameObject money;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject diamond;
    
    
    
    void Start()
    {
       
        gold.transform.gameObject.SetActive(false);
        diamond.transform.gameObject.SetActive(false);
         
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.CompareTag("Lens") )
        {
            if (!gameObject.transform.parent.CompareTag("Pos1"))
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                StartCoroutine(Scale(gameObject));
            }
            
        


            if (money.activeInHierarchy == true)
            {
                money.transform.gameObject.SetActive(false);
                gold.transform.gameObject.SetActive(true);

            } else if(gold.activeInHierarchy == true)
            {
                gold.transform.gameObject.SetActive(false);
                diamond.transform.gameObject.SetActive(true);

            }

            //for (int i =0;i<getMoney.Positions.Count - 1; i++)
            //{
            /* if(getMoney.Positions[i].childCount >= 1 && control )
             {
                 control = false;
                 getMoney.Positions[i].GetChild(0).transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                // getMoney.Positions[i].GetChild(0).transform.localScale = new Vector3(1, 1, 1);



                 //gets the local scale of an object
                 // vector3 local = transform.localScale;

                 //sets the local scale of an object
                 // transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
             }*/
            // }

        }
        
        

    }



    IEnumerator Scale(GameObject gameObject )
    {

        yield return new WaitForSeconds(0.1f);
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

    }








    /*  [SerializeField] Mesh money;
      [SerializeField] Mesh  gold;
      [SerializeField] Mesh  diamond;

      void OnCollisionEnter(Collision other)
      {
          if (other.gameObject.GetComponent<MeshFilter>().mesh == money)
          {
              other.gameObject.GetComponent<MeshFilter>().mesh = gold;
          }
          else if (other.gameObject.GetComponent<MeshFilter>().mesh == gold)
          {
              other.gameObject.GetComponent<MeshFilter>().mesh = diamond;
          }

      }

      void Update()
      {
          Vector3 pos = new Vector3(transform.position.x, 0f, transform.position.z);
          if (Physics.Raycast(pos, transform.TransformDirection(Vector3.back), out RaycastHit hitinfo, 50f))
          {
              Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hitinfo.distance, Color.red);
              if(gameObject.GetComponent<MeshFilter  >().mesh  == money)
              {
                 gameObject.GetComponent<MeshFilter >().mesh = gold;
              }
              else if(gameObject.GetComponent<MeshFilter >().mesh == gold)
              {
                  gameObject.GetComponent<MeshFilter >().mesh = diamond;
              }
          }


      }

      */


}
