using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }
}
