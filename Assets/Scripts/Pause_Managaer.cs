using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Managaer : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isPaused = false;
    private GameObject pauseMenu;
    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");    
        pauseMenu.SetActive(false); // Start with the menu hidden    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){ // If pressed Esc
            if(isPaused){
                isPaused = false;
                Time.timeScale = 1; // Restore deltaTime function
                pauseMenu.SetActive(false); // Hide Pause Menu
            }
            else{
                isPaused = true;
                Time.timeScale = 0; // Pause deltaTime (movement and animations)
                pauseMenu.SetActive(true); // Show Pause Menu
            }
        }        
    }
}
