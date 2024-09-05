using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FuntionalEvents : MonoBehaviour
{
    [SerializeField] MeshRenderer ButtonSwitch;
    Material myMaterial;

    public int validSwicth = 0;
    Color colorBase = new Color(2, 34, 191);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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

}
