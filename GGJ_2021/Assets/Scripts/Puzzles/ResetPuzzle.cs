using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetPuzzle : MonoBehaviour, IPointerDownHandler{
    public DotsPuzzle puzzle;

    public void OnPointerDown(PointerEventData eventData){
        puzzle.lineRendererForCurrentPuzzle.GetComponent<LineRenderer>().positionCount = 0;
        puzzle.CountCorrectDots = 0;
        puzzle.dots.Clear();
    }
}
