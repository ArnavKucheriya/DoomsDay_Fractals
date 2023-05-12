using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDropdown : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

            resolutionDropdown.value = PlayerPrefs.GetInt("resolution", currentResolutionIndex);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("resolution", resolutionDropdown.value);
    }
}
