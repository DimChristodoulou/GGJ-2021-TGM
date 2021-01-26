﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private CharacterController thisController;
    public float speed = 6;

    // Start is called before the first frame update
    void Start(){
        thisController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;

        thisController.Move(move * speed * Time.deltaTime);
    }
}
