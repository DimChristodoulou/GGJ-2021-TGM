using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour{
    public GameObject interactionText;
    public bool IsInDialog = false;
    
    // Start is called before the first frame update
    void Start()
    {
        interactionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other){
        if (other.GetComponent<DialogueTrigger>()){
            SetInteractionText("Press F to talk to " + other.gameObject.name);
            
            if (Input.GetKeyDown(KeyCode.F) && IsInDialog == false){
                IsInDialog = true;
                gameObject.GetComponent<PlayerMovement>().speed = 0;
                DisablePlayerInteractions();
                other.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
        else if (other.GetComponent<Readable>()){
            SetInteractionText("Press F to read the " + other.gameObject.name);
            
            if (Input.GetKeyDown(KeyCode.F)){
                gameObject.GetComponent<PlayerMovement>().speed = 0;
                DisablePlayerInteractions();
                other.GetComponent<Readable>().StartInteraction();
            }
        }
    }

    private void SetInteractionText(String text){
        interactionText.SetActive(true);
        interactionText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void OnTriggerExit(Collider other){
        interactionText.GetComponent<TextMeshProUGUI>().text = "";
        interactionText.SetActive(false);
    }

    public static void EnablePlayerInteractions(){
        Cursor.lockState = CursorLockMode.Locked;
        Camera.main.gameObject.GetComponent<MouseLook>().enabled = true;
    }
    
    public static void DisablePlayerInteractions(){
        Cursor.lockState = CursorLockMode.None;
        Camera.main.gameObject.GetComponent<MouseLook>().enabled = false;
    }
}
