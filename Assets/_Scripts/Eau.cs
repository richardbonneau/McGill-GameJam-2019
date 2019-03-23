using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eau : MonoBehaviour
{

    Patrol patrolScript;
    public AudioClip waterSplash;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
         patrolScript = GameObject.FindWithTag("Alligator").GetComponent<Patrol>();
         audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            audioSource.PlayOneShot(waterSplash, 0.3f);
        }
    }
    void OnTriggerStay(Collider col){
        
        if(col.CompareTag("Player")){
            patrolScript.GoToPlayer();
        }
    }

    void OnTriggerExit(Collider col){
        patrolScript.GoToLastKnownLocation(col.transform.position);
        

    }
}
