using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject bookPanel, leftPageText, rightPageText, leftPageButton, rightPageButton;
    private int _currentPage = 0, _numberOfPages = 0;
    private Book _currentBook;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartReadingBook(int maximumNumberOfPages, Book book){
        bookPanel.SetActive(true);
        _currentBook = book;
        _numberOfPages = maximumNumberOfPages;
        UpdatePages();
    }
    
    /*
     * Move back one page
     */
    public void OnLeftButtonPress(){
        _currentPage--;
        UpdatePages();
    }
    
    /*
     * Move forward one page
     */
    public void OnRightButtonPress(){
        _currentPage++;
        UpdatePages();
    }

    private void UpdatePages()
    {
        if (_currentPage * 2 < _numberOfPages){
            leftPageText.GetComponent<TextMeshProUGUI>().text = _currentBook.content[_currentPage * 2];
            leftPageButton.SetActive(true);
        }
        else{
            leftPageText.GetComponent<TextMeshProUGUI>().text = "";
            leftPageButton.SetActive(false);
        }

        if ((_currentPage * 2) + 1 < _numberOfPages){
            rightPageText.GetComponent<TextMeshProUGUI>().text = _currentBook.content[_currentPage * 2 + 1];
            rightPageButton.SetActive(true);
        }
        else{
            rightPageText.GetComponent<TextMeshProUGUI>().text = "";
            rightPageButton.SetActive(false);
        }
        
        if (_currentPage == 0) {
            leftPageButton.SetActive(false);
        }
        
        if (_currentPage == _numberOfPages-1) {
            rightPageButton.SetActive(false);
        }
    }

    public void CloseBook(){
        bookPanel.SetActive(false);
        
        Player.EnablePlayerInteractions();
        FindObjectOfType<PlayerMovement>().speed = 2.6f;
        Player._isInteractingWithObject = false;
    }
}
