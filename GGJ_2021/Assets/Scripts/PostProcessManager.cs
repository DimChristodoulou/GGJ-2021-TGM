using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.HighDefinition;
using UnityEngine.Rendering.HighDefinition;

public class PostProcessManager : MonoBehaviour{
    public GameObject volume;

    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.C)){
            ColorAdjustments colorGrading;
            Volume globalPostProcessingVolume = volume.GetComponent<Volume>();

            if (globalPostProcessingVolume.profile.TryGet(out colorGrading)){
                if (colorGrading.saturation.value == 0f){
                    colorGrading.saturation.Override(-100f);
                }
                else if (colorGrading.saturation.value == -100f){
                    colorGrading.saturation.Override(0f);
                }
            }
        }
    }
}