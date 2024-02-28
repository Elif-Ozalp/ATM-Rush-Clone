using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveToFinish : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI  label2;
    //float horizontalInput;
     
    //public bool Control { get { return control; } }
    [SerializeField]  GameObject money;
     public List<GameObject> moneys = new List<GameObject>();
  
    Destroy destroy;
    void Start()
    {
        destroy  = FindObjectOfType<Destroy >();
    }
    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("Money") ) //&&   control )
        {

            // control = false;
            //  other.gameObject.transform.parent.SetParent(null);

            /* if(other.transform.parent.)
             {
                 other.gameObject.transform.parent.parent.SetParent(null);
             }*/
           
            StartCoroutine(ToLeft(other.gameObject));
            

           
       
        }
       if (other.gameObject.CompareTag("Player") ) //&& control )
        {
            //  control = false;
            // other.gameObject.tag = "Untagged";
            StartCoroutine(Player(other.gameObject));
            other.gameObject.GetComponent<Animator>().SetBool("sit", true);

        }
            
        
    }

    IEnumerator ToLeft(GameObject gameObject)
    {
        //gameObject.tag = "FinishMoney";
        gameObject.transform.parent.SetParent(null);
        gameObject.GetComponent<ToLeft>().enabled = true;


        yield return new WaitForSeconds(5f);


    }
    IEnumerator Player(GameObject other)
    {


        Vector3 pos = new Vector3(0, 0, 220);
        other.transform.position = Vector3.Lerp(transform.position, pos, 20f);
       // other.transform.SetPositionAndRotation(pos, other.transform.rotation);

        other.GetComponent<Animator>().SetBool("idle", true);

        other.gameObject.transform.parent.GetComponent<PlayerController>().enabled = false;
        other.transform.SetParent(null);
        // other.gameObject.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Finish(money,other.gameObject ));
        
            
            label2.text = (moneys.Count + destroy.Counter).ToString();
         






    }

    IEnumerator Finish(GameObject gameObject, GameObject player)
    {

       // player.GetComponent<Animator>().bodyRotation= new Quaternion  (0, 180, 0, 1);
      

        player.transform.rotation = new Quaternion(0, 180, 0, 1);
        Instantiate(gameObject, new Vector3(0,0.48f,245f) , gameObject.transform.rotation);
        for (int i = 1; i < moneys.Count + destroy.Counter    ; i++)
        {
           
            Vector3 pos = new Vector3(0, 0.48f*(i+0.7f)*1.53f, 245f);
            Instantiate(gameObject, pos, gameObject.transform.rotation);
           
            player.transform.SetPositionAndRotation(pos , player.transform.rotation );
            
          
            yield return new WaitForSeconds(0.038f);
        }
    }
}
