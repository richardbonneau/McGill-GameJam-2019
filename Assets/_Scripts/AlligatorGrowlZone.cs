using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlligatorGrowlZone : MonoBehaviour
{
    public AudioClip closeGrowlOne;
    public AudioClip closeGrowlTwo;
    AudioSource audioSource;
    bool isGrowlInCooldown;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player") && !isGrowlInCooldown) {
            float chooseAudio = Random.Range(0f, 2f);
            if(chooseAudio <1.5f) audioSource.PlayOneShot(closeGrowlOne,1f);
            else audioSource.PlayOneShot(closeGrowlTwo,1f);
            
            isGrowlInCooldown = true;
            StartCoroutine(GrowlCooldown(5f));
        }
    }
    IEnumerator GrowlCooldown(float waitTime){
        yield return new WaitForSeconds(waitTime);
        isGrowlInCooldown = false;
    }
}
