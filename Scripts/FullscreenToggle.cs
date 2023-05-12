using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public Toggle fullscreenToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Toggle", 1) == 1)
        {
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fullscreenToggle.isOn == true)
        {
            PlayerPrefs.SetInt("Toggle", 1);
        }
        else 
        {
            PlayerPrefs.SetInt("Toggle", 0);
        }
        
    }
}
