using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dot : MonoBehaviour, IPointerDownHandler{
    public DotsPuzzle puzzle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData){
        //Push the star to the stack
        puzzle.dots.Add(gameObject);

        puzzle.lineRendererForCurrentPuzzle.GetComponent<LineRenderer>().positionCount = puzzle.dots.Count;
        puzzle.lineRendererForCurrentPuzzle.GetComponent<LineRenderer>().SetPosition(puzzle.dots.Count-1, puzzle.dots[puzzle.dots.Count-1].transform.localPosition);
        
        if (puzzle.dots.Count == puzzle.correctDots.Count){
            foreach (GameObject dot in puzzle.dots){
                if (puzzle.correctDots[puzzle.dots.IndexOf(dot)] == dot){
                    puzzle.CountCorrectDots++;
                }
            }

            if (puzzle.CountCorrectDots == puzzle.correctDots.Count){
                puzzle.IsSolutionCorrect = true;
            }
        }

        if (puzzle.IsSolutionCorrect){
            puzzle.correctNumberPopUpText.SetActive(true);
        }
    }
}
