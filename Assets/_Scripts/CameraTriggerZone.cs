using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTriggerZone : MonoBehaviour
{
    Text UI_AlligatorPictures;
    Text UI_FindHints;
    Text UI_NestPicture;
    Text UI_Escape;


    public int amountHintsFound = 0;
    public int amountAlligatorPictures = 0;
    public int amountNestPictures = 0;

    bool playerCanPhotographAlligator;
    ExitTrigger exitTriggerScript;

    Color32 greyedOutObjective = new Color32(150,150,150,255);
    // Start is called before the first frame update
    void Start(){
        UI_AlligatorPictures = GameObject.FindWithTag("UI_AlligatorPictures").GetComponent<Text>();
        UI_FindHints = GameObject.FindWithTag("UI_FindHints").GetComponent<Text>();
        UI_NestPicture = GameObject.FindWithTag("UI_NestPicture").GetComponent<Text>();
        UI_Escape = GameObject.FindWithTag("UI_Escape").GetComponent<Text>();

        exitTriggerScript = GameObject.FindWithTag("Exit").GetComponent<ExitTrigger>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
    
        //  The player first finds hints
        if(col.CompareTag("Hint")){
            if(amountHintsFound < 3)amountHintsFound+=1;
            if(amountHintsFound == 3) {
                UI_FindHints.color = greyedOutObjective;
                UI_AlligatorPictures.text = "Alligator Pictures "+amountAlligatorPictures+"/3";
                UI_NestPicture.text = "Alligator Nest Picture "+amountNestPictures+"/1";

                playerCanPhotographAlligator = true;
                }
            UI_FindHints.text = "Find hints "+amountHintsFound+"/3";
            Destroy(col.gameObject);

        //  The player then needs to photograph the alligator and its nest
        } else if(col.CompareTag("Alligator") && playerCanPhotographAlligator){
            if(amountAlligatorPictures < 3) amountAlligatorPictures+=1;
            if(amountAlligatorPictures == 3) UI_AlligatorPictures.color = greyedOutObjective;
            UI_AlligatorPictures.text = "Alligator Pictures "+amountAlligatorPictures+"/3";
            
        } else if(col.CompareTag("Nest") && playerCanPhotographAlligator){
            if(amountNestPictures<1) amountNestPictures+=1;
            if(amountNestPictures == 1) UI_NestPicture.color = greyedOutObjective;
            UI_NestPicture.text = "Alligator Nest Picture "+amountNestPictures+"/1";
        } 

        //Player Escape
        if(amountHintsFound == 3 && amountAlligatorPictures == 3 && amountNestPictures == 1){
            print("playercannow leave");
            UI_Escape.text = "Escape the sewers alive 0/1";
            exitTriggerScript.playerCanLeave = true;
        }
        
    }
}
