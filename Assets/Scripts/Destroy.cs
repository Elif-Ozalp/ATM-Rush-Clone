using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class Destroy : MonoBehaviour
{
    GetMoney getMoney;
    PlayerController playerController;
    [SerializeField] TextMeshPro label;
    MoveToFinish moveToFinish;
    bool control = true;
     Vector3 particlePosition = new Vector3();
    public Vector3 ParticlePosition { get { return particlePosition; } }

    List<GameObject> repos = new List<GameObject>();

   [SerializeField ] ParticleSystem particle;
    float jumpPower = 10;
    int numJumps = 1;
    float duration = 0.35f;
    bool snapping = true;

    GameObject newGo;

    int counter = 0;

    public int Counter { get { return counter; } }
 //   bool particle = false;
  //  public bool Particle { get { return particle; } }
   //   Particle particle;
   //[SerializeField ] ParticleSystem destroyFX;
   // public bool particle = false;
  
   //bool control = true;
    void Start()
    {
        getMoney = FindObjectOfType <GetMoney>();
        playerController = FindObjectOfType<PlayerController>();
        moveToFinish = FindObjectOfType<MoveToFinish>();
       // particle = GetComponent<Particle>();
        
       
    
       //particle = FindObjectOfType<Particle>();
       
    }
    void OnCollisionEnter(Collision other)
    {
        //destroyFX = other.gameObject.GetComponent<ParticleSystem>();
        // particle = true;
        if (other.gameObject.CompareTag("Money") && gameObject.CompareTag("Destroy")) //&& control )
        {
            int b = GetChildIndex(other.gameObject.transform.parent);
            for (int i = b; i < 39; i++)
            {
                if (getMoney.Positions[i + 1].childCount >= 1)
                {
                    // other. gameObject.GetComponent<GetMoney>().cOntrol = true;
                    
                    
                    StartCoroutine(RepositionObjects(other.gameObject, gameObject));
                    StartCoroutine(aa(0.5f));
                   
                }
                else if (getMoney.Positions[i + 1].childCount < 1)
                {
                    // particle = true;

                    particlePosition = other.transform.position;
                    Debug.Log(particlePosition);
                    /*if (control)
                    {
                        control = false;
                        Particle.Instance.GetFromPool().gameObject.SetActive(true);
                        //  Particle.Instance.GetFromPool().transform.SetParent(null);

                        
                    }
                    control = true;*/



                    if (control)
                    {
                        control = false;
                        Instantiate(particle, particlePosition, new Quaternion(0, 0, 0, 1));
                        // particle.Play();
                        //control = true;
                    }
                    moveToFinish.moneys.Remove(other.gameObject);
                    other.transform.SetParent(null);
                    other.gameObject.SetActive(false);



                    // other.gameObject.SetActive(false);
                    // particle.GetFromPool().SetActive(true);
                    //StartCoroutine(DestroyObject(other.gameObject));


                }

            }


            // control = false;
            // Debug.Log(gameObject);
            /*  int a=  GetChildIndex(other.gameObject.transform.parent);
              for (int i = a; i < getMoney.Positions.Count - 1; i++)
              {
                  if(getMoney.Positions[i+1].childCount >= 1)
                  {
                      float randomPosX = Random.Range(0, 3);
                      float randomPosZ =  Random.Range(1, 5);

                     Vector3 pos = getMoney.Positions[i + 1].GetChild(0).position + new Vector3(randomPosX, 0, randomPosZ);

                      getMoney.Positions[i + 1].GetChild(0).SetPositionAndRotation(pos, getMoney.Positions[i + 1].GetChild(0).transform.rotation);
                      getMoney.Positions[i + 1].GetChild(0).SetParent(null);
                  }else
                  {
                      break;
                  }
              }*/


            // destroyFX.transform.SetParent(null);
            //particle.destroyFX.Play();
            //other.gameObject.SetActive(false);

            //getMoney.moneys.Remove(other.gameObject);






            /*
            for (int i = a; i < getMoney.Positions.Count - 1; i++)
            {
                if (getMoney.Positions[i + 1].childCount >= 1)
                {
                    for (int j = 0; j < getMoney.Positions[i + 1].childCount - 1; j++)
                    {
                        if (getMoney.Positions[i + 1].GetChild(j).gameObject.activeInHierarchy)
                        {
                            getMoney.Positions[i + 1].GetChild(j).parent = getMoney.Positions[i];
                        }
                        else
                        {
                            break;
                        }

                    }

                }

            }*/


            //  getMoney.moneys[getMoney.moneys.Count-1].transform.SetParent(other.gameObject.transform.parent);


            /*    for (int i = 0; i < getMoney.Positions.Count - 1; i++)
               {
                   if (!getMoney.Positions[i].GetChild(0).gameObject.activeInHierarchy)
                   {
                      getMoney.moneys[getMoney.moneys.Count -1].transform.SetParent(getMoney.Positions[i]);
                   }

               }*/


            // GetChildIndex(other.transform);
            // other.transform.SetParent(null);

            /* for (int i = 1; i < 20; i++)
             {
                 if (!other.gameObject.activeInHierarchy)
                 {
                     getMoney.moneys[getMoney.moneys.Count -1].transform.SetParent(other.gameObject.transform.parent);
                     //getMoney.Positions[i + 1].GetChild(0).SetParent(getMoney.Positions[i]);
                    // getMoney.Positions[i + 1].GetChild(0).transform.position = getMoney.Positions[i].transform.position;
                 }


             }*/
            /*for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                if (!other.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    getMoney.moneys[i].transform.SetParent(getMoney.Positions[i]);
                }

            }*/

        }
        else if (other.gameObject.CompareTag("Money") && gameObject.CompareTag("Atm"))
        {
            //transform.GetChild(0).GetComponent<MoneyCounter>().enabled = true; 

            //counter = moveToFinish.moneys.Count;
            counter++;
            label.text = counter.ToString();

            //  Debug.Log(counter);

            //  Instantiate(pos, transform.position, transform.rotation);

            int c = GetChildIndex(other.gameObject.transform.parent);
            for (int i = c; i < 39; i++)
            {
                if (getMoney.Positions[i + 1].childCount >= 1)
                {
                    // other.gameObject.GetComponent<GetMoney>().cOntrol = true;
                    StartCoroutine(RepositionObjects(other.gameObject, gameObject));
                    other.gameObject.GetComponent<GetMoney>().aTm = false;
                    StartCoroutine(aa(0.5f));
                    
                    // StartCoroutine(MakeTrure(other.gameObject ));

                }

                else if (getMoney.Positions[i + 1].childCount < 1 && getMoney.Atm)
                {
                    // particle = true; 
                    other.gameObject.GetComponent<GetMoney>().aTm = true;

                    StartCoroutine(Scale(other.gameObject, gameObject));



                 //   moveToFinish.moneys.Remove(other.gameObject);


                    // StartCoroutine(DestroyObject(other.gameObject));

                }
                /*if (other.transform.parent.CompareTag("Pos1"))
                {
                    StartCoroutine(destroy2(gameObject));
                }*/
                /* other.transform.SetParent(null);
                 other.gameObject.SetActive(false);
                */

                // getMoney.moneys.Remove(other.gameObject);


                //Transform parent = other.transform.parent;
                // parent.transform.SetParent(null);


                // StartCoroutine(DestroyObject(other.gameObject));


                // destroyFX.Play();
                // Instantiate(destroyFX, other.transform.position, other.transform.rotation);
                //other.transform.SetParent(null);
                // other.gameObject.SetActive(false);
            }
        }

        else if (other.gameObject.CompareTag("Money") && gameObject.CompareTag("FinishAtm"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Money") && gameObject.CompareTag("Dispersion") && control)
        {
            control = false;
            particlePosition = other.transform.position;
            // Debug.Log(particlePosition);
            /*  if (control)
              {
                  control = false;
                  Instantiate(particle, particlePosition, new Quaternion(0, 0, 0, 1));
                  //particle.Play();
                  //control = true;
              }*/
            // StartCoroutine(RepositionObjects(other.gameObject,gameObject ));

            int a = GetChildIndex(other.gameObject.transform.parent);
              for (int i = a; i < getMoney.Positions.Count - 1; i++)
              {
                  if (getMoney.Positions[i + 1].childCount >= 1)
                  {
                      float randomPosX = Random.Range(-6, 7);
                      float randomPosZ = Random.Range(10, 20);

                      //Vector3 pos = getMoney.Positions[i + 1].GetChild(0).position + new Vector3(randomPosX, 0, randomPosZ);
                      float posZ = gameObject.transform.position.z;
                      Vector3 pos = new Vector3(randomPosX, 1f, (posZ + randomPosZ));


                     //newGo  = getMoney.Positions[i + 1].GetChild(0).gameObject;

                      moveToFinish.moneys.Remove(getMoney.Positions[i + 1].GetChild(0).gameObject);
                      getMoney.Positions[i + 1].GetChild(0).DOJump(pos, jumpPower, numJumps, duration, snapping);
                      repos.Add(getMoney.Positions[i + 1].GetChild(0).gameObject);
                      //getMoney.Positions[i + 1].GetChild(0).SetPositionAndRotation(pos, getMoney.Positions[i + 1].GetChild(0).transform.rotation);

                      // getMoney.Positions[i + 1].GetChild(0).gameObject.GetComponent<GetMoney>().cOntrol = true;     
                      getMoney.Positions[i + 1].GetChild(0).SetParent(null);

                  }
                //  newGo.GetComponent<GetMoney>().cOntrol = true;
              }
            StartCoroutine(destroy2());
           

        } 

        else if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Destroy"))
        {
            // control = false;
            other.transform.parent.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(WaitObject(other.gameObject, gameObject));



        }


    }
    IEnumerator Scale(GameObject other,GameObject atm)
    {


        other.transform.DOScale(0.5f  , 0);
        other.transform.SetParent(null);
    //  yield return  new WaitForSeconds(1);
       
        while (Vector3.Distance (atm.transform.GetChild(1).position, other.transform.position) >0.01f)
        {
            Debug.Log(Vector3.Distance(atm.transform.GetChild(1).position, other.transform.position));
            Vector3 pos = other.transform.position;
            other.transform.position = Vector3.MoveTowards(pos, atm.transform.GetChild(1).position, 1f * Time.deltaTime);
            
            
            yield return new WaitForEndOfFrame();
        }
        atm.GetComponent<ParticleSystem>().Play();
      // yield return new WaitForSeconds(0.05f);
        other.gameObject.SetActive(false);

    }
    IEnumerator RepositionObjects(GameObject  other, GameObject gameObject )
    {
       
        int a = GetChildIndex(other.gameObject.transform.parent);
        for (int i = a; i < getMoney.Positions.Count - 1; i++)
        {
            
            if (getMoney.Positions[i + 1].childCount >= 1)
            {
                float randomPosX = Random.Range(-6, 7);
                 float randomPosZ = Random.Range(10, 20);

                //Vector3 pos = getMoney.Positions[i + 1].GetChild(0).position + new Vector3(randomPosX, 0, randomPosZ);
                float posZ = gameObject.transform.position.z;
                Vector3 pos = new Vector3(randomPosX, 1f, (posZ+randomPosZ));
                
               


                moveToFinish.moneys.Remove(getMoney.Positions[i + 1].GetChild(0).gameObject);
                getMoney.Positions[i + 1].GetChild(0).DOJump(pos, jumpPower, numJumps, duration, snapping);
                repos.Add(getMoney.Positions[i + 1].GetChild(0).gameObject);
              // newGo  = getMoney.Positions[i + 1].GetChild(0).gameObject ;
                //getMoney.Positions[i + 1].GetChild(0).SetPositionAndRotation(pos, getMoney.Positions[i + 1].GetChild(0).transform.rotation);

                // getMoney.Positions[i + 1].GetChild(0).gameObject.GetComponent<GetMoney>().cOntrol = true;

                getMoney.Positions[i + 1].GetChild(0).SetParent(null);
              
                yield return new WaitForSeconds(0.3f);

                /*  if(getMoney.Positions[i+1].GetChild(0).GetChild(0).gameObject.activeInHierarchy == true)
                  {
                      getMoney.Positions[i + 1].GetChild(0).GetChild(0).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                  }else if(getMoney.Positions[i + 1].GetChild(0).GetChild(1).gameObject.activeInHierarchy == true)
                  {
                      getMoney.Positions[i + 1].GetChild(0).GetChild(1).transform.localScale = new Vector3(3f, 5f, 4.5f);
                  }else if (getMoney.Positions[i + 1].GetChild(0).GetChild(2).gameObject.activeInHierarchy == true)
                  {
                      getMoney.Positions[i + 1].GetChild(0).GetChild(2).transform.localScale = new Vector3(3, 3, 3);
                  }*/


            }
           

           
        }
    }

      /* IEnumerator MakeTrure(GameObject other)
       {


           yield return new WaitForSeconds(2f);
            other.GetComponent<GetMoney>().aTm = true;
      


       }*/
    IEnumerator aa(float second)
    {
        yield return new WaitForSeconds(second);
        foreach (GameObject Repos in repos)
        {
            Repos.GetComponent<GetMoney>().cOntrol = true;
            repos.Remove(Repos);
        }

    }
    IEnumerator WaitObject(GameObject other, GameObject gameObject )
    {
        for (int i = 0; i < 39; i++)
        {
            if (getMoney.Positions[i].childCount >= 1)
            {
                float randomPosX = Random.Range(-6, 7);
                float randomPosZ = Random.Range(8, 15);

                //Vector3 pos = getMoney.Positions[i + 1].GetChild(0).position + new Vector3(randomPosX, 0, randomPosZ);
                float posZ = gameObject.transform.position.z;
                Vector3 pos = new Vector3(randomPosX, 0.5f, (posZ + randomPosZ));


                getMoney.Positions[i].GetChild(0).DOJump(pos, jumpPower, numJumps, duration, snapping);
                getMoney.Positions[i].GetChild(0).SetParent(null);
            }
        }
        Vector3 playerNewPos = new Vector3 (other.transform.position.x, other.transform.position.y, (other.transform.position.z - 30));

       // other.transform.parent.position = Vector3.Lerp(other.transform.position, playerNewPos, 0.3f);
        other.transform.parent.DOJump(playerNewPos , 0.1f, numJumps, duration, snapping);
        other.transform.parent.GetComponent<PlayerController>().enabled = true;
        yield return new WaitForSeconds(0.5f);
       


    }
    IEnumerator destroy2 ()
    {

       
        
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject Repos in repos)
        {
            Repos.GetComponent<GetMoney>().cOntrol = true;

        }

    }
    
    int GetChildIndex(Transform  prnt)
    {
        int count = 0;
        
        for(int i = 0; i < 39; i++)
        {
            if (getMoney.Positions[i] == prnt)
            {
                count = i ;
                
            }
          
        }
        return count;
    }
}
