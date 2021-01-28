using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    public GameObject activePanel;
    public GameObject activeName;
    public GameObject activeText;
    public GameObject displayNextSentenceButton;

    public Queue<Tuple<String, String>> sentences;

    private string talkingCharacterName;
    
    // Start is called before the first frame update
    void Start()
    {
        activePanel.SetActive(false);
        activeName.SetActive(false);
        activeText.SetActive(false);

        sentences = new Queue<Tuple<String, String>>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(List<Dialogue> dialogue){
        activePanel.SetActive(true);
        activeName.SetActive(true);
        activeText.SetActive(true);
        displayNextSentenceButton.SetActive(true);
        
        foreach (Dialogue sentence in dialogue){
            sentences.Enqueue(new Tuple<string, string>(sentence.activeCharacterName, sentence.sentence));
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        Tuple<String, String> sentence = sentences.Dequeue();
        activeName.GetComponent<TextMeshProUGUI>().text = sentence.Item1;
        activeName.GetComponent<TextMeshProUGUI>().color = Color.cyan;
        activeText.GetComponent<TextMeshProUGUI>().text = sentence.Item2;
        activeText.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void EndDialogue(){
        activeName.GetComponent<TextMeshProUGUI>().text = "";
        activeText.GetComponent<TextMeshProUGUI>().text = "";
        activeName.SetActive(false);
        activeText.SetActive(false);
        activePanel.SetActive(false);
        displayNextSentenceButton.SetActive(false);
        Player.EnablePlayerInteractions();
        FindObjectOfType<PlayerMovement>().speed = 2.6f;
        Player._isInteractingWithObject = false;
    }
}
