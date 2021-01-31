using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour{
    public GameObject pauseMenuPanel;
    private bool _isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenuPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused){
            Resume();
        }
    }

    public void Resume(){
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuPanel.SetActive(false);
    }

    public void Quit(){
        SceneManager.LoadScene("MainMenu");
    }
}
