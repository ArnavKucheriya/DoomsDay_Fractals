using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KeyBindControlPanel : MonoBehaviour
{
    InputManager inputManager;
    public GameObject keyItemPrefab;
    public GameObject keyList;

    string buttonToRebind = null;
    Dictionary<string, TMP_Text> buttonToLabel;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();

        // Create one "KeyListItem" per button in in inputManager

        string[] buttonNames = inputManager.GetButtonNames();
        buttonToLabel = new Dictionary<string, TMP_Text>();

        //foreach (string bn in buttonNames)
        for (int i = 0; i < buttonNames.Length; i++)
        {
            string bn;
            bn = buttonNames[i];

            GameObject go = (GameObject)Instantiate(keyItemPrefab);
            go.transform.SetParent(keyList.transform);
            go.transform.localScale = Vector3.one;

            TMP_Text buttonNameText = go.transform.Find("ButtonName").GetComponent<TMP_Text>();
            buttonNameText.text = bn;

            TMP_Text keyNameText = go.transform.Find("KeyButton/KeyName").GetComponent<TMP_Text>();
            keyNameText.text = inputManager.GetKeyNameForButton(bn);
            buttonToLabel[bn] = keyNameText;

            Button keyBindButton = go.transform.Find("KeyButton").GetComponent<Button>();
            keyBindButton.onClick.AddListener( () => { AssignNewKey(bn); } );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonToRebind != null)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode kc in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kc))
                    {
                        inputManager.SetButtonForKey(buttonToRebind, kc);
                        buttonToLabel[buttonToRebind].text = kc.ToString();
                        buttonToRebind = null;
                        break;
                    }
                }
            }
        }
    }

    void AssignNewKey(string buttonName)
    {
        Debug.Log(buttonName);
        buttonToRebind = buttonName;
    }
}
