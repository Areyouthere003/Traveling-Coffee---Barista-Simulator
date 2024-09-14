using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoSequence : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;
    [SerializeField] private GameObject elevatorObj;
    [SerializeField] private GameObject elevatorCanvas;
    // [SerializeField] private GameObject thermometerObj;
    [SerializeField] private GameObject grindMachine;
    [SerializeField] private GameObject dispenserObj;
    private int currentMenuIndex = 0;

    [SerializeField] private GameObject PlayerObj;
    [SerializeField] private GameObject targetObject;

    //Position Contextual
    [SerializeField] private float distance = 0.5f;
    [SerializeField] private float verticalOffset = -0.5f;
    [SerializeField] private Transform positionSource;
    [SerializeField] private Transform olletaPosition;

    private bool triggerGrindMachine, grindIntroducctionShowed,
     olletaDinstanceTrigger, firstInteractionRecipeMachine,
     firstInteractionButtons, elevatorTrigger, firstInteractionOlleta, dispenserTrigger;

    void Start()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        ShowMenu(currentMenuIndex);
    }

    // public void ShowMachineHilighed()
    // {
    //     if (materials.Length > 0) {
    //         materials[0].SetFloat("_Outline", 0.01f);
    //         HideMenu(currentMenuIndex);
    //     };
    // }
    private void ShowMenu(int index)
    {
        if(currentMenuIndex > 0){
            Vector3 direction = positionSource.forward;
            direction.y = 0;
            direction.Normalize();

            Vector3 targetPosition = positionSource.position + direction * distance + Vector3.up * verticalOffset;
            transform.position= targetPosition; 

            transform.LookAt(positionSource.position);
            transform.Rotate(Vector3.up, 90.0f);
        }
    

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
    public void HideCustomAuto(int index){

        StartCoroutine(DesactiveAutoMenu(index));
    }
    public void HideCustomMenu(int index){
        // currentMenuIndex = index;
        HideMenu(index);
    }
    IEnumerator DesactiveAutoMenu(int index)
    {
        yield return new WaitForSeconds(6f);
        HideMenu(index);
    }

    public void TriggerOlletaGrip(){
        if(!firstInteractionOlleta){
            currentMenuIndex = 5;
            ShowMenu(currentMenuIndex);
            HideCustomAuto(currentMenuIndex);
            currentMenuIndex += 1;
        }
    }
    public void TriggerRecipeGrindMchine(){
        if (!firstInteractionRecipeMachine)
        {    
            firstInteractionRecipeMachine = true;
            OnNextButtonPressed();
        }
    }
    public void TriggerMachineBtnPressed(){
        if (!firstInteractionButtons)
        {    
            firstInteractionButtons = true;
            OnNextButtonPressed();
        }
    }

    void Update()
    {
        Vector3 playerPosition = PlayerObj.transform.position;
        Vector3 staticObjectPosition = grindMachine.transform.position;
        Vector3 objectPosition = targetObject.transform.position;

        float distanceRecipe = Vector3.Distance(staticObjectPosition, objectPosition);
        float distancePlayerToGrind = Vector3.Distance(PlayerObj.transform.position,staticObjectPosition);
        float distancePlayerToElavator = Vector3.Distance(PlayerObj.transform.position, elevatorObj.transform.position);
        float distanceOlletaToDispenser = Vector3.Distance(olletaPosition.position, dispenserObj.transform.position);
        if(distancePlayerToGrind < 1.2 && !grindIntroducctionShowed)
        {
            grindIntroducctionShowed = true;
            currentMenuIndex = 1;
            ShowMenu(currentMenuIndex);
        }
        if(distancePlayerToElavator < 2.3 && !elevatorTrigger){
            LeanTween.scale(elevatorCanvas, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutExpo);
            StartCoroutine(HideElevatorCanvas());
        }

        // if(distanceOlletaToPlayer < .8 && !olletaDinstanceTrigger)
        // {
        //     currentMenuIndex = 4;
        //     ShowMenu(currentMenuIndex);
        //     HideCustomAuto(currentMenuIndex);
        //     currentMenuIndex += 1;
        // } 

        // Debug.Log("This is the disntance :" + distanceOlletaToDispenser);
        if(distanceOlletaToDispenser < .4 && !dispenserTrigger)
        {
            currentMenuIndex = 6;
            ShowMenu(currentMenuIndex);
        } 
        if (distanceRecipe < .8 && !triggerGrindMachine)
        {
            currentMenuIndex = 2;
            triggerGrindMachine = true;
            ShowMenu(currentMenuIndex);
            // Debug.Log("TRUEEEE");
            StartCoroutine(DesactiveAutoMenu(currentMenuIndex));
        }
    }
    IEnumerator HideElevatorCanvas()
    {
        yield return new WaitForSeconds(6f);
        LeanTween.scale(elevatorCanvas, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInExpo).setOnComplete(() =>
        {
            elevatorCanvas.SetActive(false);
        });
    }
  
}