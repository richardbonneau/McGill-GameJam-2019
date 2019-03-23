using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePatrolPointsZone : MonoBehaviour
{
    // Start is called before the first frame update

    //  ontriggerenter pushes points to a list, on trigger exit removes them. every minute or so,
    //  we reset the patrol state of the alligator to those new points. Filter that list to remove
    //  any duplicates if necessary

    List<GameObject> patrolPoints;
    void Start(){
        patrolPoints = new List<GameObject>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
        if(col.CompareTag("PatrolPoint")){
            patrolPoints.Add(col.gameObject);
        }
        print("list: "+patrolPoints);
    }
    void OnTriggerExit(Collider col){
        if(col.CompareTag("PatrolPoint")){
            patrolPoints.Remove(col.gameObject);
        }
        print("list: "+patrolPoints);
    }


}
