using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityDropdown : MonoBehaviour
{
    public TMPro.TMP_Dropdown qualityDropdown;

    // Start is called before the first frame update
    void Start()
    {
        qualityDropdown.value = PlayerPrefs.GetInt("quality", 5);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("quality", qualityDropdown.value);
    }
}
