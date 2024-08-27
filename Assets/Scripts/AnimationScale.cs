using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScale : MonoBehaviour
{
    [SerializeField] Animator Ascale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateAnimation() 
    {
        Ascale.SetBool("Mon", true);
    }

    public void DesactivateAnimation()
    {
        Ascale.SetBool("Mon", false);
    }   
}
