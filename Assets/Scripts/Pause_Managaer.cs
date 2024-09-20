using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Managaer : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isPaused = false;
    private GameObject pauseMenu;
    private GameObject deadScreen;
    void Start()
    {
        deadScreen = GameObject.Find("DeadScreen");
        pauseMenu = GameObject.Find("PauseMenu");    
        pauseMenu.SetActive(false); // Start with the menu hidden    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !deadScreen.activeSelf){ // If pressed Esc
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
        if(Input.GetKeyDown(KeyCode.Q) && (isPaused || deadScreen.activeSelf)){
            Application.Quit();
        }

        // manage deadscreen as well, why the fuck not
        if(Input.GetKeyDown(KeyCode.R) && deadScreen.activeSelf){
            // restart scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
