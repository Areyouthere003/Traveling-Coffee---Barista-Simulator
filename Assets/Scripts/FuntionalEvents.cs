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

    //[Header("Rendering Stove Settings")]
    //[Tooltip("Select the object from stove model")]
    //[SerializeField] Material stoveLD; [SerializeField] Material stoveLU; [SerializeField] Material stoveRD; [SerializeField] Material stoveRU;

    //float variabableAplha = 0.0000005f, maxAlpha = 0.000005f;
    //Color stoveMaterialOn = new Color(214, 23, 23, 172); Color stoveMaterialOff = new Color(214, 23, 23, 0);
    //[SerializeField] int stovePos = 0;
    //[SerializeField] bool valid01 = false, valid02 = false, button1 = false, button2 = false, button3 = false, button4 = false;

    void Start()
    {
        ButtonSwitch.sharedMaterial.SetColor("_EmissionColor", colorBase * 0.12f);
        //AllMatsInZero();
    }

    // Update is called once per frame
    void Update()
    {

        ////start stove visality on/off
        //if (valid01)
        //{
        //    StoveOn();
        //}

        //if (valid02)
        //{
        //    StoveOff();
        //}
    }

    //private void StoveOn()
    //{
    //    if (valid01 && stovePos == 0)
    //    {
    //        if (stoveLD.color.a < 0.67f)
    //        {
    //            stoveLD.SetColor("_Color", new Color(214, 23, 23, stoveLD.color.a + variabableAplha * Time.deltaTime));

    //            if (stoveLD.color.a > maxAlpha)
    //            {
    //                valid01 = false;
    //            }
    //        }
    //    }
    //    else if (valid01 && stovePos == 1)
    //    {
    //        if (stoveLU.color.a < 0.67f)
    //        {
    //            stoveLU.SetColor("_Color", new Color(214, 23, 23, stoveLU.color.a + variabableAplha * Time.deltaTime));

    //            if (stoveLU.color.a > maxAlpha)
    //            {
    //                valid01 = false;
    //            }
    //        }
    //    }
    //    else if (valid01 && stovePos == 2)
    //    {
    //        if (stoveRD.color.a < 0.67f)
    //        {
    //            stoveRD.SetColor("_Color", new Color(214, 23, 23, stoveRD.color.a + variabableAplha * Time.deltaTime));

    //            if (stoveRD.color.a > maxAlpha)
    //            {
    //                valid01 = false;
    //            }
    //        }
    //    }
    //    else if (valid01 && stovePos == 3)
    //    {
    //        if (stoveRU.color.a < 0.67)
    //        {
    //            stoveRU.SetColor("_Color", new Color(214, 23, 23, stoveRU.color.a + variabableAplha * Time.deltaTime)); 

    //            if (stoveRU.color.a > maxAlpha)
    //            {
    //                valid01 = false;
    //            }
    //        }
    //    }
    //}

    //private void StoveOff()
    //{
    //    if (valid02)
    //    {
    //        if (valid02 && stovePos == 0)
    //        {
    //            if (stoveLD.color.a > 0)
    //            {
    //                stoveLD.SetColor("_Color", new Color(214, 23, 23, stoveLD.color.a - variabableAplha * Time.deltaTime));

    //                if (stoveLD.color.a < 0)
    //                {
    //                    valid02 = false;
    //                    stoveLD.SetColor("_Color", stoveMaterialOff);
    //                }
    //            }
    //        }
    //        else if (valid02 && stovePos == 1)
    //        {
    //            if (stoveLU.color.a > 0)
    //            {
    //                stoveLU.SetColor("_Color", new Color(214, 23, 23, stoveLU.color.a - variabableAplha * Time.deltaTime));

    //                if (stoveLU.color.a < 0)
    //                {
    //                    valid02 = false;
    //                    stoveLU.SetColor("_Color", stoveMaterialOff);
    //                }
    //            }
    //        }
    //        else if (valid02 && stovePos == 2)
    //        {
    //            if (stoveRD.color.a > 0)
    //            {
    //                stoveRD.SetColor("_Color", new Color(214, 23, 23, stoveRD.color.a - variabableAplha * Time.deltaTime));

    //                if (stoveRD.color.a < 0)
    //                {
    //                    valid02 = false;
    //                    stoveRD.SetColor("_Color", stoveMaterialOff);
    //                }
    //            }
    //        }
    //        else if (valid02 && stovePos == 3)
    //        {
    //            if (stoveRU.color.a > 0)
    //            {
    //                stoveRU.SetColor("_Color", new Color(214, 23, 23, stoveRU.color.a - variabableAplha * Time.deltaTime));

    //                if (stoveRU.color.a < 0)
    //                {
    //                    valid02 = false;
    //                    stoveRU.SetColor("_Color", stoveMaterialOff);
    //                }
    //            }
    //        }
    //    }
    //}

    //private void AllMatsInZero()
    //{
    //    stoveLD.SetColor("_Color", stoveMaterialOff);
    //    stoveLU.SetColor("_Color", stoveMaterialOff);
    //    stoveRD.SetColor("_Color", stoveMaterialOff);
    //    stoveRU.SetColor("_Color", stoveMaterialOff);
    //}

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

    //public void PushButtonStove(int number)
    //{
    //    stovePos = number;

    //    switch(stovePos)
    //    {
    //        case 0:
    //            if (!button1)
    //            {
    //                valid01 = true;
    //                valid02 = false;
    //                button1 = true;
    //            }
    //            else
    //            {
    //                valid01 = false;
    //                valid02 = true;
    //                button1 = false;
    //            }
    //            break;
    //        case 1:
    //            if (!button2)
    //            {
    //                valid01 = true;
    //                valid02 = false;
    //                button2 = true;
    //            }
    //            else
    //            {
    //                valid01 = false;
    //                valid02 = true;
    //                button2 = false;
    //            }
    //            break;
    //        case 2:
    //            if (!button3)
    //            {
    //                valid01 = true;
    //                valid02 = false;
    //                button3 = true;
    //            }
    //            else
    //            {
    //                valid01 = false;
    //                valid02 = true;
    //                button3 = false;
    //            }
    //            break;
    //        case 3:
    //            if (!button4)
    //            {
    //                valid01 = true;
    //                valid02 = false;
    //                button4 = true;
    //            }
    //            else
    //            {
    //                valid01 = false;
    //                valid02 = true;
    //                button4 = false;
    //            }
    //            break;
    //    }
    //    //if (!valid01)
    //    //{


    //    //    stovePos = number;
    //    //    valid01 = true;
    //    //    valid02 = false;
    //    //}
    //    //else
    //    //{
    //    //    stovePos = number;
    //    //    valid01= false;
    //    //    valid02 = true;
    //    //}
    //}

    //public bool GetButtonStove(bool valid1)
    //{

    //    switch (stovePos)
    //    {
    //        case 0:
    //            if (!button1)
    //            {
    //                valid1 = false;
    //                return valid01;
    //            }
    //            else
    //            {
    //                valid1 = true;
    //                return valid01;
    //            }
    //            default
    //            : return false;
            //case 1:
            //    if (!button2)
            //    {
            //        valid1 = false;
            //    }
            //    else
            //    {
            //        valid1 = true;
            //    }
            //    return valid02;
            //case 2:
            //    if (!button3)
            //    {
            //        valid3 = false;
            //    }
            //    else
            //    {
            //        valid3 = true;
            //    }
            //    return valid3;
            //case 3:
            //    if (!button4)
            //    {
            //        valid4 = false;
            //    }
            //    else
            //    {
            //        valid4 = true;
            //    }
            //    return valid4;
    //    }
    //}

}
