using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSetting : MonoBehaviour
{

    // private new AudioSource audio;
    private static readonly string firstOption = "FirstOption";
    private static readonly string volPref = "VolumePref";
    private int volumeUpdate;
    private float volFloat;
    
    public Slider volSlider;
    public new AudioSource audio;

    void Start()
    {
        volumeUpdate = PlayerPrefs.GetInt(firstOption);

        if(volumeUpdate == 0){
            volFloat = .125f;
            volSlider.value = volFloat;
            PlayerPrefs.SetFloat(volPref, volFloat);
            PlayerPrefs.SetInt(firstOption, -1);
        } else {
            volFloat = PlayerPrefs.GetFloat(volPref);
            volSlider.value = volFloat;
        }
    }

    void Update()
    {
        audio.volume = volSlider.value;
    }

    public void set(){
        PlayerPrefs.SetFloat(volPref, volSlider.value);
    }

    void onFocus(bool focus){
        if(!focus){
            set();
        }
    }
}
