using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadVolume : MonoBehaviour
{

    private static readonly string volPref = "VolumePref";
    private float volFloat;
    public new AudioSource audio;

    void Awake(){
        loadVolumeSettings();
    }

    private void loadVolumeSettings(){
        volFloat = PlayerPrefs.GetFloat(volPref);
        audio.volume = volFloat;
    }
}
