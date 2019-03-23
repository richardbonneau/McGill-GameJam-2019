using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillZone : MonoBehaviour
{

    Image fadeToBlack;
    bool triggerFadeToBlack;

    float blackImageTransparency = 0;
    Patrol patrolScript;

    GameObject restartMenu;
    // Start is called before the first frame update
    void Start(){
        patrolScript = GameObject.FindWithTag("Alligator").GetComponent<Patrol>();
        fadeToBlack = GameObject.FindWithTag("UI_FadeToBlack").GetComponent<Image>();
        restartMenu = GameObject.FindWithTag("UI_RestartMenu");

    }

    // Update is called once per frame
    void Update(){
        
        if(triggerFadeToBlack && blackImageTransparency != 255){
            print(blackImageTransparency);
            blackImageTransparency+=2.5f;
            fadeToBlack.color = new Color32(0,0,0,(byte)blackImageTransparency);
        } else if (blackImageTransparency >=246){
            // show restart screen
            restartMenu.transform.GetChild(0).gameObject.SetActive(true);
            restartMenu.transform.GetChild(1).gameObject.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindWithTag("Player").gameObject.GetComponent<vp_FPInput>().MouseCursorForced = true;
            vp_Utility.LockCursor = false;
        }
    }
    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);
            patrolScript.StopPatrolling();
            triggerFadeToBlack = true;
        }
    }
}
