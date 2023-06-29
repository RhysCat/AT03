using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;
    public GameObject Menu;
    public PlayerControls player;
    public MouseController mouse;

    // Start is called before the first frame update
   
    void Start()
    {
        // starting/main menu 
        Menu.SetActive(true);
        gameIsPaused = true;
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        //pause menu controls 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            if (gameIsPaused == false)
            {
                Pause();
            }
        }
    }
    //What happens when Pause 
    public void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.enabled = false;
        mouse.enabled = false;
    }
    //The Polar Opposite of Pause 
    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        player.enabled = true;
        mouse.enabled = true;
    }
    //Quit Function
    public void Quit()
    {
        Application.Quit();
    }
    //Restart Game Function 
    public void Restart()
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
