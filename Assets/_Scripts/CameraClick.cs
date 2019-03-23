using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClick : MonoBehaviour
{
    bool isCameraInCooldown;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isCameraInCooldown){
            transform.GetChild(0).gameObject.SetActive(true);
            isCameraInCooldown = true;
            StartCoroutine(InCooldown(2f));
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    
    IEnumerator InCooldown(float waitTime){
        yield return new WaitForSeconds(waitTime);
        isCameraInCooldown=false;

    }
}
