using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartEvr : MonoBehaviour
{
    private void Start()
    {
        GameObject sliderGameObject = GameObject.Find("VolumeSlider");
        SliderVolume slider = sliderGameObject.GetComponent<SliderVolume>();

        Debug.Log(StartMenu.count);
        if (SceneManager.GetActiveScene().buildIndex == 0 && StartMenu.count == 0)
        {
            slider.slider.value = 1;
        }
            
        StartMenu.count++;
    }
}
