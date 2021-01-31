using UnityEngine;

public class VolumeSlider : MonoBehaviour {
    public UnityEngine.UI.Slider slider;
    public UnityEngine.Audio.AudioMixer mixer;

    void Awake(){
        //SetVolume(1); //Manually set value & volume before subscribing to ensure it is set even if slider.value happens to start at the same value as is saved
        slider.onValueChanged.AddListener((float _) => SetVolume(_)); //UI classes use unity events, requiring delegates (delegate(float _) { SetVolume(_); }) or lambda expressions ((float _) => SetVolume(_))
    }
     
    void SetVolume(float _value){
        mixer.SetFloat("MasterVol", ConvertToDecibel(_value/slider.maxValue)); //Dividing by max allows arbitrary positive slider maxValue
    }
    
    public float ConvertToDecibel(float _value){
        return Mathf.Log10(Mathf.Max(_value, 0.0001f))*20f;
    }
}