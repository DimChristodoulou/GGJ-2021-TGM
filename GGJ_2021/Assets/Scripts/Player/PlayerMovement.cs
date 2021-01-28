using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private CharacterController thisController;
    public float speed = 6;
    public float gravity = -9.81f;
    private Vector3 velocity;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start(){
        thisController = GetComponent<CharacterController>();
        
        // calculate the correct vertical position:
        float correctHeight = thisController.center.y + thisController.skinWidth;
        // set the controller center vector:
        thisController.center = new Vector3(0, correctHeight, 0);
    }

    // Update is called once per frame
    void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        thisController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        thisController.Move(velocity * Time.deltaTime);
    }
}
