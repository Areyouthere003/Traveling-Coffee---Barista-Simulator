using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontAssetChanger : MonoBehaviour
{
    [SerializeField] private Font newFont; // Assign the new font in the inspector
    [SerializeField] private Canvas targetCanvas; // Assign your target Canvas in the inspector

    void Start()
    {
        // Get all the Text components in the canvas
        Text[] allTextComponents = targetCanvas.GetComponentsInChildren<Text>();

        // Loop through each Text component and change the font
        foreach (Text textComponent in allTextComponents)
        {
            textComponent.font = newFont;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
