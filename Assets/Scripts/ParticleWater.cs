using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWater : MonoBehaviour
{
    [SerializeField] AudioSource waterFall;
    [SerializeField] bool valid = false, valid2 = false;

    void Start()
    {
        var waterOn = gameObject.GetComponent<ParticleSystem>().emission;
        waterOn.enabled = valid;
    }

    // Update is called once per frame
    void Update()
    {

        if (valid)
        {
            var waterOn = gameObject.GetComponent<ParticleSystem>().emission;
            waterOn.enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;

            if (valid2)
            {
                waterFall.Play();
                valid2 = false;
            }
        }
        else
        {
            var waterOn = gameObject.GetComponent<ParticleSystem>().emission;
            waterOn.enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            if (valid2)
            {
                waterFall.Stop();
                valid2 = false;
            }
        }
    }

    public void WaterParticlesOnOff()
    {
        if (!valid)
        {
            valid = true;
            valid2 = true;
        }
        else
        {
            valid = false;
            valid2 = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jar"))
        {
            other.GetComponent<AudioSource>().Play();
            other.GetComponent<FillWaterJar>().GetBool(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Jar"))
        {
            other.GetComponent<AudioSource>().Stop();
            other.GetComponent<FillWaterJar>().GetBool(false);
        }
    }
}
