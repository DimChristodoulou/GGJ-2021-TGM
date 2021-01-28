using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DotsPuzzle : MonoBehaviour{
    public List<GameObject> dots;

    public List<GameObject> correctDots;
    
    public GameObject lineRendererForCurrentPuzzle;

    public GameObject correctNumberPopUpText;

    private bool _isSolutionCorrect = false;

    public bool IsSolutionCorrect
    {
        get => _isSolutionCorrect;
        set => _isSolutionCorrect = value;
    }

    private int _countCorrectDots = 0;

    public int CountCorrectDots
    {
        get => _countCorrectDots;
        set => _countCorrectDots = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        dots = new List<GameObject>();
        lineRendererForCurrentPuzzle.transform.localPosition = new Vector3(0,0, -0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(dots.Count);
        //dots[dots.Count - 1]

    }

}
