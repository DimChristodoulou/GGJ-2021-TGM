using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour{
    public GameObject activeName;
    public GameObject activeText;

    public GameObject interactionText;
    
    // Start is called before the first frame update
    void Start()
    {
        activeName.SetActive(false);
        activeText.SetActive(false);
        interactionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other){
        if (other.GetComponent<DialogueTrigger>()){
            interactionText.SetActive(true);
            interactionText.GetComponent<TextMeshProUGUI>().text = "Press F to talk to " + other.GetComponent<DialogueTrigger>().dialogue.activeCharacterName;
            
            if (Input.GetKeyDown(KeyCode.F)){
                activeName.SetActive(true);
                activeText.SetActive(true);
                gameObject.GetComponent<PlayerMovement>().speed = 0;
            }
        }
    }

    public void OnTriggerExit(Collider other){
        interactionText.GetComponent<TextMeshProUGUI>().text = "";
        interactionText.SetActive(false);
        activeName.SetActive(false);
        activeText.SetActive(false);
    }
}
