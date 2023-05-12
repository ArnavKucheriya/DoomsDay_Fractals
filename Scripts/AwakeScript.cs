using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScript : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonKeys;

    void Awake()
    {
        Screen.fullScreen = true;
        Screen.SetResolution(1920, 1080, true);
        QualitySettings.SetQualityLevel(5);

        buttonKeys = new Dictionary<string, KeyCode>();

        buttonKeys["Move Up"] = KeyCode.W;
        buttonKeys["Move Down"] = KeyCode.S;
        buttonKeys["Move Left"] = KeyCode.A;
        buttonKeys["Move Right"] = KeyCode.D;
        buttonKeys["Rotate Left"] = KeyCode.Q;
        buttonKeys["Rotate Right"] = KeyCode.E;
        buttonKeys["Zoom In"] = KeyCode.KeypadPlus;
        buttonKeys["Zoom Out"] = KeyCode.KeypadMinus;
        buttonKeys["Immersion Mode"] = KeyCode.F12;
        buttonKeys["Pause Game"] = KeyCode.Escape;
    }
}
