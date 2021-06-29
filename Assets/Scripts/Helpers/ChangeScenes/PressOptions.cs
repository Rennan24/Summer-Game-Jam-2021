using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressOptions : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Options");
    }
}
