using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] Material stoveLD; [SerializeField] Material stoveLU; [SerializeField] Material stoveRD; [SerializeField] Material stoveRU;

    Color stoveMaterialOn = new Color(214, 23, 23, 172); Color stoveMaterialOff = new Color(214, 23, 23, 0);
    int stovePos = 0;
    bool valid01 = false, valid02 = false;

    void Start()
    {
        ButtonSwitch.sharedMaterial.SetColor("_EmissionColor", colorBase * 0.12f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(stoveLD.color.a);
        //start stove visality on/off
        if (valid01)
        {
            StoveOn();
        }

        if (valid02)
        {
            StoveOff();
        }
    }

    private void StoveOn()
    {
        if (valid01 && stovePos == 0)
        {
            if (stoveLD.color.a >= 0 && stoveLD.color.a < 172)
            {
                stoveLD.SetColor("_Color", stoveMaterialOn * 0.15f * Time.deltaTime);

                if (stoveLD.color.a == 172)
                {
                    valid01 = false;
                }
            }
        }
        else if (valid01 && stovePos == 1)
        {
            if (stoveLU.color.a >= 0 && stoveLU.color.a < 172)
            {
                stoveLU.SetColor("_Color", stoveMaterialOn * 0.15f * Time.deltaTime);

                if (stoveLU.color.a == 172)
                {
                    valid01 = false;
                }
            }
        }
        else if (valid01 && stovePos == 2)
        {
            if (stoveRD.color.a >= 0 && stoveRD.color.a < 172)
            {
                stoveRD.SetColor("_Color", stoveMaterialOn * 0.15f * Time.deltaTime);

                if (stoveRD.color.a == 172)
                {
                    valid01 = false;
                }
            }
        }
        else if (valid01 && stovePos == 3)
        {
            if (stoveRU.color.a >= 0 && stoveRU.color.a < 172)
            {
                stoveRU.SetColor("_Color", stoveMaterialOn * 0.15f * Time.deltaTime);

                if (stoveRU.color.a == 172)
                {
                    valid01 = false;
                }
            }
        }
    }

    private void StoveOff()
    {
        if (valid02)
        {
            if (valid02 && stovePos == 0)
            {
                if (stoveLD.color.a <= 172 && stoveLD.color.a >= 0)
                {
                    stoveLD.SetColor("_Color", stoveMaterialOff * 0.15f * Time.deltaTime);

                    if (stoveLD.color.a == 0)
                    {
                        valid02 = false;
                    }
                }
            }
            else if (valid02 && stovePos == 1)
            {
                if (stoveLU.color.a >= 0 && stoveLU.color.a < 172)
                {
                    stoveLU.SetColor("_Color", stoveMaterialOff * 0.15f * Time.deltaTime);

                    if (stoveLU.color.a == 0)
                    {
                        valid02 = false;
                    }
                }
            }
            else if (valid02 && stovePos == 2)
            {
                if (stoveRD.color.a >= 0 && stoveRD.color.a < 172)
                {
                    stoveRD.SetColor("_Color", stoveMaterialOff * 0.15f * Time.deltaTime);

                    if (stoveRD.color.a == 0)
                    {
                        valid02 = false;
                    }
                }
            }
            else if (valid02 && stovePos == 3)
            {
                if (stoveRU.color.a >= 0 && stoveRU.color.a < 172)
                {
                    stoveRU.SetColor("_Color", stoveMaterialOff * 0.15f * Time.deltaTime);

                    if (stoveRU.color.a == 0)
                    {
                        valid02 = false;
                    }
                }
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
            valid02 = false;
        }
        else
        {
            valid01= false;
            valid02 = true;
        }
    }


}
