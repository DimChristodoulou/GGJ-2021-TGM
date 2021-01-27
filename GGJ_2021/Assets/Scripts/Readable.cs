using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Readable : MonoBehaviour{
    public Book thisReadable;

    private int _numberOfPages;

    // Start is called before the first frame update
    void Start(){
        _numberOfPages = thisReadable.content.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInteraction(){
        FindObjectOfType<BookManager>().StartReadingBook(_numberOfPages, thisReadable);
    }
}
