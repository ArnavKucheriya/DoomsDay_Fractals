using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonKeys;

    void Start()
    {
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

        string[] keyNames = GetButtonNames();

        for (int i = 0; i < keyNames.Length; i++)
        {
            string key;
            key = keyNames[i];

            int intRepresentation = (int)buttonKeys[key];
            buttonKeys[key] = (KeyCode)PlayerPrefs.GetInt(key, intRepresentation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (string key in buttonKeys.Keys)
        {

            //cast the enum to an int
            int intRepresentation = (int)buttonKeys[key];

            //Save the key bind
            PlayerPrefs.SetInt(key, intRepresentation);
        }

        //Write the changes to disk
        PlayerPrefs.Save();
    }

    public bool GetButtonDown(string buttonName)
    {
        if (!buttonKeys.ContainsKey(buttonName))
        {
            Debug.LogError("InputManager::GetButtonDown -- No button named: " + buttonName);
            return false;
        }

        return Input.GetKeyDown(buttonKeys[buttonName]);
    }

    public bool GetButton(string buttonName)
    {
        if (!buttonKeys.ContainsKey(buttonName))
        {
            Debug.LogError("InputManager::GetButton -- No button named: " + buttonName);
            return false;
        }

        return Input.GetKey(buttonKeys[buttonName]);
    }

    public string[] GetButtonNames()
    {
        return buttonKeys.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if (!buttonKeys.ContainsKey(buttonName))
        {
            Debug.LogError("InputManager::GetKeyNameForButton -- No button named: " + buttonName);
            return "N/A";
        }

        return buttonKeys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        buttonKeys[buttonName] = keyCode;
    }
}
