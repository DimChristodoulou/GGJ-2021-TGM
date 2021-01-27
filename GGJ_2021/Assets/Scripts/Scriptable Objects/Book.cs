using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Book", menuName = "Books/New Book", order = 0)]
public class Book : ScriptableObject{
    
    [TextArea(4,5)]
    public List<String> content;
    
}
