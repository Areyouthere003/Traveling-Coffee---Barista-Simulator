using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesActionSad : MonoBehaviour
{
    [SerializeField] bool valid = false, valid2 = false;

    //// Start is called before the first frame update
    void Start()
    {
        var particlesOn = gameObject.GetComponent<ParticleSystem>().emission;
        particlesOn.enabled = valid;
    }

    //// Update is called once per frame
    void Update()
    {
        if (valid)
        {
            var particlesOn = gameObject.GetComponent<ParticleSystem>().emission;
            particlesOn.enabled = true;

            if (valid2)
            {
                gameObject.GetComponent<AudioSource>().Play();
                valid2 = false;
            }
        }
        else
        {
            var particlesOn = gameObject.GetComponent<ParticleSystem>().emission;
            particlesOn.enabled = false;

            if (valid2)
            {
                gameObject.GetComponent<AudioSource>().Stop();
                valid2 = false;
            }
        }
    }

    public void SetCoffeeParticlesSad(bool valida2)
    {
        valid = valida2;

        if (!valid)
        {
            valid = false;
            valid2 = false;
        }
        else
        {
            valid = true;
            valid2 = true;
        }
    }
}
