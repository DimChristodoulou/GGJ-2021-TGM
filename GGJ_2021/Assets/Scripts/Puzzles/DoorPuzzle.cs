using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorPuzzle : MonoBehaviour, IPointerDownHandler{
    public bool isIncrementing = false;
    public GameObject digit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData){
        string currentDigitStr = digit.GetComponent<TextMeshPro>().text;
        int currentDigit = Int32.Parse(currentDigitStr);
        Debug.Log(currentDigit);
        if (isIncrementing){
            if (currentDigit < 9 && currentDigit >= 0){
                currentDigit++;
                digit.GetComponent<TextMeshPro>().text = currentDigit.ToString();
            }
        }
        else{
            if (currentDigit < 10 && currentDigit > 0){
                currentDigit--;
                digit.GetComponent<TextMeshPro>().text = currentDigit.ToString();
            }
        }

        GameObject door = GameObject.FindGameObjectWithTag("ObservatoryDoor");
        
        if (door && door.activeSelf){
            string digit1 = GameObject.Find("Digit1").GetComponent<TextMeshPro>().text;
            string digit2 = GameObject.Find("Digit2").GetComponent<TextMeshPro>().text;
            string digit3 = GameObject.Find("Digit3").GetComponent<TextMeshPro>().text;
            string currentCode = digit1 + digit2 + digit3;

            //Debug.Log(currentCode + "-2");
            
            if (currentCode == "317"){
                door.SetActive(false);
            }
        }
        

        string radigit1 = GameObject.Find("RADigit1").GetComponent<TextMeshPro>().text;
        string radigit2 = GameObject.Find("RADigit2").GetComponent<TextMeshPro>().text;
        string radigit3 = GameObject.Find("RADigit3").GetComponent<TextMeshPro>().text;
        string radigit4 = GameObject.Find("RADigit4").GetComponent<TextMeshPro>().text;
        string radigit5 = GameObject.Find("RADigit5").GetComponent<TextMeshPro>().text;
        string decdigit1 = GameObject.Find("DECDigit1").GetComponent<TextMeshPro>().text;
        string decdigit2 = GameObject.Find("DECDigit2").GetComponent<TextMeshPro>().text;
        string decdigit3 = GameObject.Find("DECDigit3").GetComponent<TextMeshPro>().text;
        string decdigit4 = GameObject.Find("DECDigit4").GetComponent<TextMeshPro>().text;
        string decdigit5 = GameObject.Find("DECDigit5").GetComponent<TextMeshPro>().text;
        string decdigit6 = GameObject.Find("DECDigit6").GetComponent<TextMeshPro>().text;

        string observatoryCode = radigit1 + radigit2 + radigit3 + radigit4 + radigit5 + 
                                 decdigit1 + decdigit2 + decdigit3 + decdigit4 + decdigit5 + decdigit6;

        if (observatoryCode == "33128425435"){
            Player.hasFinishedGame = true;
        }
    }
}
