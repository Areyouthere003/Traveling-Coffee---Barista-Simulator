using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FuntionalEvents : MonoBehaviour
{
    [Header("rendering Switch settings")]
    [Tooltip("Change the emissor texture to 0 in the Electric Switch")]
    [SerializeField] MeshRenderer ButtonSwitch;
    
    //Material associated with the Electric Switch
    Material myMaterial;
    int validSwicth = 0;
    Color colorBase = new Color(2, 34, 191);

    [Header("Rendering Stove Settings")]
    [Tooltip("Select the object from stove model")]
    [SerializeField] Material stoveDL, stoveUL, stoveDR, stoveUR;

    Color stoveMaterial = new Color(214, 23, 23, 172);
    int stovePos = 0;
    bool valid01 = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (valid01 && stovePos == 0)
        {
            if (stoveDL.color.a == 0)
            {
                stoveDL.SetColor("_Color", stoveMaterial * 0.15f * Time.deltaTime);

                if (stoveDL.color.a == 172)
                {
                    valid01 = false;
                }
            }
        }
        else if(valid01 && stovePos == 1)
        {
                if(stoveDR.color.a == 0)
                {
                    stoveDR.SetColor("_Color", stoveMaterial * 0.15f * Time.deltaTime);
                }
        }
    }

    public void TurnEmissionButtonOnOff()
    {
        switch (validSwicth)
        {
            case 0:
                ButtonSwitch.sharedMaterial.SetColor("_EmissionColor", Color.black);
                validSwicth++;
                break;
            case 1:
                ButtonSwitch.sharedMaterial.SetColor("_EmissionColor", colorBase * 0.12f);

                validSwicth--;
                break;
            default:
                validSwicth = 5;
                break;
        }
    }

    public void PushButtonStove(int number)
    {
        if (!valid01)
        {
            //stovePrefab = gameObject;
            valid01 = true;
        }
        else
        {
            valid01= false;
        }
    }


}
