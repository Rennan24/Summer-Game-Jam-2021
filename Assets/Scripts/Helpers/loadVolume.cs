using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadVolume : MonoBehaviour
{

    private float volFloat;
    public new AudioSource audio;

    void Awake(){
        loadVolumeSettings();
    }

    private void loadVolumeSettings(){
        volFloat = 1f;
        audio.volume = volFloat;
    }
}
