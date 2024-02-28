using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
public class Particle : MonoBehaviour
{
   ParticleSystem destroyFX;
    //Destroy destroy;
    // Destroy destroy;
    [SerializeField] private GameObject prefab;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();
    public static Particle Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool(1);
    }
    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            GrowPool(5);
        }

        var instance = availableObjects.Dequeue();
        return instance;
    }

    private void GrowPool(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var instantiatedObj = Instantiate(prefab, transform);
            AddToPool(instantiatedObj);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
        instance.transform.SetParent(transform);
    }

    /* void Start()
     {
        destroyFX = GetComponent<ParticleSystem>();
        // destroy = FindObjectOfType<Destroy>();
        // destroy = FindObjectOfType<Destroy>();
     }*/
    /*void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Destroy"))
        {


            //Instantiate(destroyFX, transform.position, transform.rotation);


            StartCoroutine(Stop(destroyFX));

            // destroyFX.Stop();



        }

        /*else if (other.gameObject.CompareTag("Destroy")  )
         {

             destroyFX.Play();
            destroyFX.Stop();
             //destroyFX.GetComponent<ParticleSystem>().loop = false;
           //StartCoroutine(Stop(destroyFX));
         }

     }*/


    /* IEnumerator Stop(ParticleSystem particle)
     {
         destroyFX.Play();

         yield return new WaitForSeconds(0.2f);

         particle.Stop();


     }
 */

}
