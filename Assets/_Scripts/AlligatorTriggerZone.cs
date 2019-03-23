using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlligatorTriggerZone : MonoBehaviour
{
    Patrol patrolScript;
    
    void Start(){
        patrolScript = GameObject.FindWithTag("Alligator").GetComponent<Patrol>();
    }
     void OnTriggerEnter(Collider col){
         
         if(col.tag == "Player"){
             
             patrolScript.GoToPlayer();
         }
    }
}
