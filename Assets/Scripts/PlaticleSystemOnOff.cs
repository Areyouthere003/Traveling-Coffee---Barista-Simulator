using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaticleSystemOnOff : MonoBehaviour
{
    [Header("Particles for Coffee")]
    [Tooltip("Here is the object with the particle system for the grinding Machine")]
    
    [SerializeField] bool valid = false;

    [SerializeField] GameObject coffeeBeans;
    Vector3 endPos = new Vector3(0f, -0.15f, 0f);
    public bool valid2 = false;

    [Header("Particle Link")]
    [SerializeField] GameObject apiGO;

    // Start is called before the first frame update
    void Start()
    {
        var coffeOn = gameObject.GetComponent<ParticleSystem>().emission;
        coffeOn.enabled = valid;
    }

    // Update is called once per frame
    void Update()
    {

        valid2 = apiGO.activeInHierarchy;

        if (coffeeBeans.transform.localPosition.y > endPos.y)
        {
            if (valid)
            {
                var coffeOn = gameObject.GetComponent<ParticleSystem>().emission;
                coffeOn.enabled = true;
            }
            else
            {
                var coffeOn = gameObject.GetComponent<ParticleSystem>().emission;
                coffeOn.enabled = false;
            }
        }
        else
        {
            var coffeOn = gameObject.GetComponent<ParticleSystem>().emission;
            coffeOn.enabled = false;
        }

        if (valid2)
        {
            valid = true;
        }
        else
        {
            valid = false;
        }
    }

    public void CoffeeParticlesOnOff()
    {
        if(!apiGO.activeInHierarchy)
        {
            //valid = false;
            apiGO.SetActive(false);
        }
        else
        {
            //valid = true;
            apiGO.SetActive(true);
        }
            
    }
}
