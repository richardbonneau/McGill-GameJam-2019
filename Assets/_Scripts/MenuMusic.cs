using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip menuMusic;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(menuMusic, 0.3f);;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
