using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimatorController : MonoBehaviour
{
    [SerializeField] InputActionProperty triggerAction;
    [SerializeField] InputActionProperty gripAction;
    [SerializeField] InputActionProperty pointingAction; 
    [SerializeField] GameObject pokeAim;
    private Animator anim;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float triggerValue = triggerAction.action.ReadValue<float>();
        float gripValue = gripAction.action.ReadValue<float>();
        float pointingValue = pointingAction.action.ReadValue<float>(); 

        if(pointingValue == 1f)
        {
            triggerValue = 1f;
            gripValue = 1f;
            pokeAim.GetComponent<GameObject>().SetActive(true);
        }
        else
        {
            pokeAim.GetComponent<GameObject>().SetActive(false);
        }

        anim.SetFloat("Trigger", triggerValue);
        anim.SetFloat("Grip", gripValue);
    }
}
