using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public void OnClickPlay()
    {
        Debug.Log("Play");
    }
    public void OnClickTutorial()
    {
        Debug.Log("Tutorial");
    }
    public void OnClickSettings()
    {
        Debug.Log("Settings");
    }
    public void OnClickQuit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
