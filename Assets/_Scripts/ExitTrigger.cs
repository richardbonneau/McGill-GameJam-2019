using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitTrigger : MonoBehaviour
{
    Text UI_Escape;
    
    public bool playerCanLeave;
    GameObject youWinMenu;
    bool triggerFadeToBlack;
    Image fadeToBlack;
    float blackImageTransparency = 0f;

    // Start is called before the first frame update
    void Start(){
        UI_Escape = GameObject.FindWithTag("UI_Escape").GetComponent<Text>();
        youWinMenu = GameObject.FindWithTag("UI_YouWinMenu");
        fadeToBlack = GameObject.FindWithTag("UI_FadeToBlack").GetComponent<Image>();
    }


    void Update(){
            if(triggerFadeToBlack && blackImageTransparency != 255){
            print(blackImageTransparency);
            blackImageTransparency+=2.5f;
            fadeToBlack.color = new Color32(0,0,0,(byte)blackImageTransparency);
        } else if (blackImageTransparency >=246){
            // show restart screen
            youWinMenu.transform.GetChild(0).gameObject.SetActive(true);
            youWinMenu.transform.GetChild(1).gameObject.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindWithTag("Player").gameObject.GetComponent<vp_FPInput>().MouseCursorForced = true;
            vp_Utility.LockCursor = false;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
        
        if(col.CompareTag("Player") && playerCanLeave){
            UI_Escape.text = "Escape the sewers alive 1/1";
            UI_Escape.color = new Color32(150,150,150,255);
            triggerFadeToBlack = true;


        }

    }
}
