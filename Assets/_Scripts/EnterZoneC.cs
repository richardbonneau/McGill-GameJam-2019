using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterZoneC : MonoBehaviour
{
    // Start is called before the first frame update

    Patrol patrolScript;
    void Start()
    {
        patrolScript = GameObject.FindWithTag("Alligator").GetComponent<Patrol>();
    }

    // Update is called once per frame
        void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
  
            patrolScript.points = GameObject.FindGameObjectsWithTag("PatrolPointB");
        }
    }
}
