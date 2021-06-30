using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escOption : MonoBehaviour
{
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
         SceneManager.LoadScene("Options");
        }
    }
}
