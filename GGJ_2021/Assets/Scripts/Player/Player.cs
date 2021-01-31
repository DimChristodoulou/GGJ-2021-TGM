using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Player : MonoBehaviour{
    public GameObject interactionText;
    public bool IsInDialog = false;
    public GameObject volume;

    private Transform _cameraInitialTransform;
    private Vector3 _cameraInitialPos;
    private Quaternion _cameraInitialRot;

    public static bool _isInteractingWithObject = false;
    public static bool hasFinishedGame = false;
    
    private bool _isMovingCamera = false;
    private Transform _cameraLookAt;
    private bool _isInteractingWithPuzzle = false;

    private GameObject imageIncompleteGame, imageCompleteGame, telescopeBackground;

    private void Awake(){
        _cameraInitialPos = Camera.main.transform.position;
        _cameraInitialRot = Camera.main.transform.rotation;
        imageIncompleteGame = GameObject.Find("imageIncompleteGame");
        imageCompleteGame = GameObject.Find("imageCompleteGame");
        telescopeBackground = GameObject.Find("TelescopeBackground");
        telescopeBackground.SetActive(false);
        imageCompleteGame.SetActive(false);
        imageIncompleteGame.SetActive(false);
    }

    // Start is called before the first frame update
    void Start(){
        _cameraInitialTransform = Camera.main.transform;
        interactionText.SetActive(false);
        DisableCursor();
    }

    // Update is called once per frame
    void Update(){
        if (_isMovingCamera){
            Camera.main.transform.LookAt(_cameraLookAt);
            
            if (_cameraLookAt.gameObject.CompareTag("DoorPuzzle")){
                Camera.main.transform.position = Vector3.Lerp(_cameraInitialTransform.position, _cameraLookAt.position - new Vector3(0, 0, -0.5f), 1 * Time.deltaTime);
            }
            else if (_cameraLookAt.gameObject.CompareTag("ObservatoryPanel")){
                /*Debug.Log(_cameraLookAt.gameObject.name);
                Camera.main.transform.position = Vector3.Lerp(_cameraInitialTransform.position, _cameraLookAt.position - new Vector3(0f, 0f, 0f), 1 * Time.deltaTime);*/
            }
            else if (_cameraLookAt.transform.rotation.eulerAngles.y == 0){
                Camera.main.transform.position = Vector3.Lerp(_cameraInitialTransform.position, _cameraLookAt.position - new Vector3(0, 0, 0.75f), 1 * Time.deltaTime);
            }
            else if (_cameraLookAt.transform.rotation.eulerAngles.y == 90){
                Camera.main.transform.position = Vector3.Lerp(_cameraInitialTransform.position, _cameraLookAt.position - new Vector3(0.75f, 0, 0), 1 * Time.deltaTime);
            }
            else if (_cameraLookAt.transform.rotation.eulerAngles.y == 270){
                Camera.main.transform.position = Vector3.Lerp(_cameraInitialTransform.position, _cameraLookAt.position - new Vector3(-0.75f, 0, 0), 1 * Time.deltaTime);
            }

            if (Camera.main.transform.position == _cameraLookAt.position){
                _isMovingCamera = false;
            }
        }

        if (_isInteractingWithPuzzle && Input.GetKeyDown(KeyCode.E)){
            //Delegate control back to player - also move camera back
            _isMovingCamera = false;
            _isInteractingWithObject = false;
            _isInteractingWithPuzzle = false;
            
            Camera.main.transform.position = _cameraInitialPos;
            Camera.main.transform.localRotation = _cameraInitialRot;
            gameObject.GetComponent<PlayerMovement>().speed = 2.6f;
            EnablePlayerInteractions();
            DisableCursor();
        }
    }

    public void OnTriggerStay(Collider other){
        if (other.GetComponent<DialogueTrigger>()){
            if (!_isInteractingWithObject){
                SetInteractionText("Press F to talk to " + other.gameObject.name);
            }

            if (Input.GetKeyDown(KeyCode.F) && IsInDialog == false){
                IsInDialog = true;
                HandlePlayerInteractionWithObject();
                other.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
        else if (other.GetComponent<Readable>()){
            if (!_isInteractingWithObject){
                SetInteractionText("Press F to read the " + other.gameObject.name);
            }

            if (Input.GetKeyDown(KeyCode.F)){
                HandlePlayerInteractionWithObject();
                other.GetComponent<Readable>().StartInteraction();
            }
        }
        else if (other.GetComponent<DotsPuzzle>() || other.gameObject.CompareTag("DoorPuzzle") || other.gameObject.CompareTag("ObservatoryPanel")){
            if (!_isInteractingWithObject){
                SetInteractionText("Press F to inspect");
            }

            if (Input.GetKeyDown(KeyCode.F)){
                HandlePlayerInteractionWithObject();
                
                _cameraInitialPos = Camera.main.transform.position;
                _cameraInitialRot = Camera.main.transform.rotation;

                _isInteractingWithPuzzle = true;
                _cameraLookAt = other.transform;
                _isMovingCamera = true;
            }
        }
        else if (other.gameObject.CompareTag("Door")){
            SetInteractionText("Press F to open the door");

            if (Input.GetKeyDown(KeyCode.F)){
                other.gameObject.GetComponent<Animator>().SetTrigger("OpenDoor");
            }
            
        }
        else if (other.gameObject.CompareTag("Telescope")){
            SetInteractionText("Press F to look inside the telescope");

            if (Input.GetKeyDown(KeyCode.F)){
                ToggleTelescopeImage();
            }
            else if (Input.GetKeyDown(KeyCode.E)){
                DisableTelescopeImages();
            }
        }
    }

    private void ToggleTelescopeImage(){
        telescopeBackground.SetActive(true);
        
        if (hasFinishedGame){
            imageCompleteGame.SetActive(true);
            imageIncompleteGame.SetActive(false);
            
            Volume globalPostProcessingVolume = volume.GetComponent<Volume>();
            ColorAdjustments colorGrading;

            if (globalPostProcessingVolume.profile.TryGet(out colorGrading)){
                if (colorGrading.saturation.value == -100f){
                    colorGrading.saturation.Override(0f);
                }
            }
            
        }
        else{
            imageCompleteGame.SetActive(false);
            imageIncompleteGame.SetActive(true);
        }
    }

    private void DisableTelescopeImages(){
        telescopeBackground.SetActive(false);
        imageCompleteGame.SetActive(false);
        imageIncompleteGame.SetActive(false);
    }

    private void HandlePlayerInteractionWithObject(){
        _isInteractingWithObject = true;
        UnsetInteractionText();
        gameObject.GetComponent<PlayerMovement>().speed = 0;
        DisablePlayerInteractions();
    }

    private void SetInteractionText(String text){
        interactionText.SetActive(true);
        interactionText.GetComponent<TextMeshProUGUI>().text = text;
    }
    
    private void UnsetInteractionText(){
        interactionText.GetComponent<TextMeshProUGUI>().text = "";
        interactionText.SetActive(false);
    }

    public void OnTriggerExit(Collider other){
        UnsetInteractionText();
    }

    public static void EnablePlayerInteractions(){
        DisableCursor();
        Camera.main.gameObject.GetComponent<MouseLook>().enabled = true;
    }
    
    public static void DisablePlayerInteractions(){
        EnableCursor();
        Camera.main.gameObject.GetComponent<MouseLook>().enabled = false;
    }

    public static void EnableCursor(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public static void DisableCursor(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
