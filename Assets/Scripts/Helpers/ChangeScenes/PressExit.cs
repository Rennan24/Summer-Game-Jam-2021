using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressExit : MonoBehaviour
{
    public void ChangeScene()
    {
        Application.Quit();
    }
}
