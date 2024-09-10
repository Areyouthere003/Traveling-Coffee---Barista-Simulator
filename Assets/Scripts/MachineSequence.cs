using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSequence : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;
    [SerializeField] private GameObject machineObj;
    [SerializeField] private GameObject thermometerObj;
    [SerializeField] private GameObject grindMachine;
    private int currentMenuIndex = 0;
    private Material[] materials;

    [SerializeField] private GameObject PlayerObj;
    [SerializeField] private GameObject targetObject;

    private bool triggerMachine = false;
    private bool triggerThermo = false;
    void Start()
    {
        Renderer renderer = machineObj.GetComponent<Renderer>();

        if (renderer != null)
        {
             materials = renderer.materials;
            materials[0].SetFloat("_Outline", 0.0f);
        }

        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        ShowMenu(currentMenuIndex);
    }

    public void ShowMachineHilighed()
    {
        if (materials.Length > 0) {
            materials[0].SetFloat("_Outline", 0.01f);
            HideMenu(currentMenuIndex);
        };
    }
    private void ShowMenu(int index)
    {
        if (index >= 0 && index < menus.Length)
        {
            menus[index].SetActive(true);
            LeanTween.scale(gameObject, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutExpo);
        }
    }

    private void HideMenu(int index, System.Action onComplete = null)
    {
        if (index >= 0 && index < menus.Length)
        {
            LeanTween.scale(gameObject, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInExpo).setOnComplete(() =>
            {
                menus[index].SetActive(false);
                onComplete?.Invoke();
            });
        }
    }
    public void OnNextButtonPressed()
    {
        if (currentMenuIndex < menus.Length - 1)
        {
            HideMenu(currentMenuIndex, () => {
                currentMenuIndex++;
                ShowMenu(currentMenuIndex);
            });
        }
    }
    void Update()
    {
        Vector3 playerPosition = PlayerObj.transform.position;
        Vector3 thermoPosition = thermometerObj.transform.position;
        Vector3 objectPosition = targetObject.transform.position;

        float distance = Vector3.Distance(playerPosition, objectPosition);
        float distanceThermo = Vector3.Distance(grindMachine.transform.position, thermoPosition);

        //Debug.Log("The thermo Position:" + thermoPosition);
        //Debug.Log("Distance the hermo "+ distanceThermo);
        if(distanceThermo < 1.7 && !triggerThermo)
        {
            HideMenu(menus.Length - 1);
        }
        //Debug.Log("Player position:" + playerPosition);
        //Debug.Log("Total Distanc:" + distance);
        if (distance < 3 && !triggerMachine)
        {
            triggerMachine = true;
            OnNextButtonPressed();
            //HideMenu(currentMenuIndex)

            //ShowMenu(1);

            Renderer renderer = GetComponent<Renderer>();
            Material[] newMaterials = new Material[materials.Length - 1];
            for (int i = 0; i < materials.Length; i++)
            {
            materials[0].SetFloat("_Outline", 0.0f);
                if (i != 0)
                {
                    newMaterials[0] = materials[i];
                }
            }
            renderer.materials = newMaterials;
        }
    }
  
}
