using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{
    
    public GameObject activeName;
    public GameObject activeText;

    public Queue<Tuple<String, String>> sentences;

    private string talkingCharacterName;
    
    // Start is called before the first frame update
    void Start()
    {
        activeName.SetActive(false);
        activeText.SetActive(false);

        sentences = new Queue<Tuple<String, String>>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(List<Dialogue> dialogue){
        Debug.Log("started");
        
        activeName.SetActive(true);
        activeText.SetActive(true);
        
        foreach (Dialogue sentence in dialogue){
            sentences.Enqueue(new Tuple<string, string>(sentence.activeCharacterName, sentence.sentence));
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        Debug.Log("hi");
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        Tuple<String, String> sentence = sentences.Dequeue();
        activeName.GetComponent<TextMeshProUGUI>().text = sentence.Item1;
        activeText.GetComponent<TextMeshProUGUI>().text = sentence.Item2;
    }

    public void EndDialogue(){
        activeName.GetComponent<TextMeshProUGUI>().text = "";
        activeText.GetComponent<TextMeshProUGUI>().text = "";
        activeName.SetActive(false);
        activeText.SetActive(false);
        Player.EnablePlayerInteractions();
        FindObjectOfType<PlayerMovement>().speed = 2.6f;
    }
}
