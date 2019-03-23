using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantGrowl : MonoBehaviour
{

    public AudioClip distantGrowlOne;
    public AudioClip distantGrowlTwo;
    AudioSource audioSource;
    bool audioHasPlayed;
    GameManager gameManager;
    Patrol patrolScript;
    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        patrolScript = GameObject.FindWithTag("Alligator").GetComponent<Patrol>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player") && this.gameObject.CompareTag("FirstGrowl") && !gameManager.distantGrowlHasPlayed){
            audioSource.PlayOneShot(distantGrowlOne, 1f);
            gameManager.distantGrowlHasPlayed = true;
            patrolScript.points = GameObject.FindGameObjectsWithTag("PatrolPointB");
        }
    }
}
