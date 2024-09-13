using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class HandAnimatorController : MonoBehaviour
{
    [SerializeField] InputActionProperty triggerAction;
    [SerializeField] InputActionProperty gripAction;
    [SerializeField] InputActionProperty pointingAction; 
    // [SerializeField] Transform interactor;
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

        // if(triggerValue == 1f && gripValue == 1f)
        // {  
        //             interactor.transform.localPosition = Vector3.zero;                    
        // }
        // else
        // {
        //             interactor.transform.localPosition = new Vector3 (3, interactor.transform.localPosition.y, interactor.transform.localPosition.z);
        // }

        anim.SetFloat("Trigger", triggerValue);
        anim.SetFloat("Grip", gripValue);
    }

}
