using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GetMoney : MonoBehaviour
{
    //[SerializeField] Transform newParent;
    [SerializeField] List<Transform> positions = new List<Transform>();
    public List<Transform> Positions { get { return positions ; } }

    bool atm = true;
    public bool Atm { get { return atm; } }
    public bool aTm {set {atm = value; } }

    MoveToFinish moveToFinish;
    bool control = true ;
    public bool Control { get { return control; } }
    public bool cOntrol { set { control=value; } }

  
    void Start()
    {
        moveToFinish = FindObjectOfType <MoveToFinish>(); 
        
    }


    void OnCollisionEnter(Collision other)
    {
       
        

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Money") && control  ) // && !gameObject.transform.parent.CompareTag("Position"))
        {
            

          

            for (int i = 0; i < positions.Count-1; i++) {
                if (positions[i].childCount < 1)
                {
                    
                    transform.SetParent(positions[i]);
                   // transform.position = positions[i].transform.position;
                    transform.localPosition = new Vector3(0, 0.4f, 0);
                   // MoneyCounter moneyCounter;
                    moveToFinish.moneys.Add(gameObject);
                     //Debug.Log(moveToFinish.moneys.Count);

                    StartCoroutine(Scale());
                     /*for(int j = positions.Count -1;j>0;j--)
                       {
                           if(positions[j].childCount >= 1)
                           {
                               //positions[j].GetChild(0).gameObject.transform.DORewind();
                               //positions[j].GetChild(0).gameObject.transform.DOPunchScale(new Vector3(1, 1, 1), .25f);

                               // positions[j].GetChild(0).transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                               StartCoroutine(Scale());

                           }

                       }*/

                    /*for(int j = positions[i].childCount; j > 0; j--)
                    {
                        if (positions[j].childCount < 1)
                        {
                            positions[i].SetParent(positions[j]);
                            // transform.position = positions[i].transform.position;
                            transform.localPosition = new Vector3(0, 0, 0);

                        }
                    }*/

                    break;
                }/*else if(positions[i].childCount == 1)
            {
                transform.SetParent(positions[i + 1]);
                transform.position = positions[i+1].transform.position;
            }*/
            }

            //Moneys.Add(other.gameObject);
            //gameObject.transform.parent = newParent.transform;








            /*  int a = Moneys.Count - 1;

                for (int i = 0; i < a; i++)
                {
                    Vector3 targetPos = Moneys[i + 1].transform.position;
                    targetPos.z = Moneys[i].transform.position.z;
                    Moneys[i + 1].transform.position = Vector3.Lerp(Moneys[i + 1].transform.position, targetPos, 0.5f * speed);
                }*/
            //  control = false;
         control = false;
        }

        /*if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("1");
            gameObject.transform.SetParent(null);
            
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (other.gameObject.CompareTag("FinishAtm"))
        {
            
            Debug.Log("2");
            gameObject.SetActive(false);
        }*/
        //parentSequence++;
       /* for (int i = positions.Count - 1; i > 0; i--)
        {
            if (positions.)
                moneys[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            StartCoroutine(Scale(moneys[i]));
        }*/

    }
    IEnumerator Scale( )
    {
       
       
         for (int j =1;j< positions.Count - 1; j++)
         {
             if (positions[j].childCount >= 1)
             {
                 positions[j].GetChild(0).gameObject.transform.DORewind();
                 positions[j].GetChild(0).gameObject.transform.DOPunchScale(new Vector3(1, 1, 1), .25f);

                 // positions[j].GetChild(0).transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                 //  StartCoroutine(Scale());
                 yield return new WaitForSeconds(0.03f);
                
             }
            
        }
        


        //  gameObject.transform.localScale = new Vector3(1, 1, 1);

    }


}
