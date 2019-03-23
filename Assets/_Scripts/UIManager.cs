using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    bool isMenuOpen;
    void Update(){
        if(Input.GetKey(KeyCode.Escape) && !isMenuOpen){
            isMenuOpen = true;
        } else if(Input.GetKey(KeyCode.Escape) && isMenuOpen){
            isMenuOpen=false;
        }
    }
    public void RestartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame(){
       Application.Quit();
    }
}
