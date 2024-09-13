using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaticleSystemOnOff : MonoBehaviour
{
    [Header("Particles for Coffee")]
    [Tooltip("Here is the object with the particle system for the grinding Machine")]
    
    [SerializeField] bool valid = false;

    GrindingMachine grindingMachine;
    bool valid2 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(valid2);

        //valid2 = grindingMachine.GetGrinOn(valid2);

        if(valid /*&& valid2*/)
        {
            var coffeOn = gameObject.GetComponent<ParticleSystem>().emission;
            coffeOn.enabled = valid;
        }
        else
        {
            var coffeOn = gameObject.GetComponent<ParticleSystem>().emission;
            coffeOn.enabled = valid;
        }

    }

    public void CoffeeParticlesOnOff(bool thisValid)
    {
        valid = thisValid;
        if(valid)
        {
            valid = false;
        }
        else
            valid = true;
    }
}
