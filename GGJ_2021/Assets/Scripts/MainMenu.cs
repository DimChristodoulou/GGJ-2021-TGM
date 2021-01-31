using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    public GameObject controlsMenu, creditsMenu;
    public AudioSource audioSource, otherSource;

    private void Update(){
        if (!audioSource.isPlaying){
            audioSource = otherSource;
            audioSource.Play();
        }
    }

    public void ShowMenu(GameObject menu){
        DisableAllUI();
        menu.SetActive(true);
    }

    public void NewGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit(){
        Application.Quit();
    }

    private void DisableAllUI(){
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
}
