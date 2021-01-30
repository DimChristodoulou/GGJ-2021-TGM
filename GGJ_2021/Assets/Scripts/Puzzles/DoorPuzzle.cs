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
            GameObject[] digits = GameObject.FindGameObjectsWithTag("Digits");
            string doorCode = "";

            foreach (GameObject digit in digits){
                string digitStr = digit.GetComponent<TextMeshPro>().text;
                doorCode += digitStr;
            }

            if (doorCode == "317"){
                door.SetActive(false);
            }
        }
        

        GameObject[] observatoryDigits = GameObject.FindGameObjectsWithTag("ObservatoryDigits");
        string observatoryCode = "";
        foreach (GameObject digit in observatoryDigits){
            string obsDigitStr = digit.GetComponent<TextMeshPro>().text;
            observatoryCode += obsDigitStr;
            Debug.Log(observatoryCode);
        }

        if (observatoryCode == "33128425435"){
            Player.hasFinishedGame = true;
        }
    }
}
