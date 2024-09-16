using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PorcelainCupFill : MonoBehaviour
{
    [SerializeField] Transform[] childList;
    [SerializeField] bool valid1 = false, valid2 = false, validMix = false, validPlayer = false, validEmittingA = false, validEmittingB = false, validMix2 = false;
    Color waterColor = new Color(0.64f, 0.64f, 1, 0.36f), coffeeColor = new Color(0.24f, 0.13f, 0.07f, 1f);
    [SerializeField] float tempRecivided = 0;

    // Start is called before the first frame update
    void Start()
    {
        childList = gameObject.GetComponentsInChildren<Transform>();
        childList[7].GetComponent<MeshRenderer>().material.color = waterColor;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r);

        GrowUpCoffee();

        GrowUPWater();

        if (validMix2)
        {
            MixLiquids();
        }


        if (tempRecivided < 92 && validMix)
        {
            validMix = false;
            UndrinkableCoffee();

        }

        if (tempRecivided > 91 && validMix)
        {
            PerfectCoffee();
            validMix = false;
        }

        if (validPlayer)
        {
            if (childList[6].transform.localScale.y > 0)
            {
                childList[6].transform.localScale = new Vector3(childList[6].transform.localScale.x, childList[6].transform.localScale.y - 0.07f * Time.deltaTime, childList[6].transform.localScale.z);
            }
            else
            {
                childList[6].transform.localScale = new Vector3(childList[6].transform.localScale.x, 0, childList[6].transform.localScale.z);
                validPlayer = false;
            }
        }

    }

    private void GrowUpCoffee()
    {
        if (valid1)
        {
            if (childList[4].transform.localScale.y < 1)
            {
                childList[4].transform.localScale = new Vector3(childList[4].transform.localScale.x, 1, childList[4].transform.localScale.z);
            }
            else
            {
                childList[4].transform.localScale = new Vector3(childList[4].transform.localScale.x, 1, childList[4].transform.localScale.z);
                valid1 = false;
            }
        }
    }

    private void GrowUPWater()
    {
        if (valid2)
        {
            if (childList[6].transform.localScale.y < 1)
            {
                childList[6].transform.localScale = new Vector3(childList[6].transform.localScale.x, childList[6].transform.localScale.y + 0.07f * Time.deltaTime, childList[6].transform.localScale.z);
            }
            else
            {
                childList[6].transform.localScale = new Vector3(childList[6].transform.localScale.x, 1, childList[6].transform.localScale.z);
                valid2 = false;
            }

        }
    }

    private void MixLiquids()
    {
        if (childList[4].transform.localScale.y >= 1 && childList[6].transform.localScale.y >= 1)
        {
            if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r > 0.24f)
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r - 0.5f * Time.deltaTime, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b));
            }
            else
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(0.2399999f, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b));
            }

            if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g > 0.13f)
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g - 0.5f * Time.deltaTime, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b));
            }
            else
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r, 0.1299999f, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b));
            }


            if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b > 0.07f)
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b - 0.5f * Time.deltaTime));
            }
            else
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g, 0.0699999f));
            }


            if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b < 1)
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.a + 0.5f * Time.deltaTime));
            }
            else
            {
                childList[7].GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", new Color(childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g, childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b, 1.00001f));
            }

            if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.r < coffeeColor.r)
            {
                if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.g < coffeeColor.g)
                {
                    if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.b < coffeeColor.b)
                    {
                        if (childList[7].GetComponent<MeshRenderer>().sharedMaterial.color.a > coffeeColor.a)
                        {
                            validMix2 = false;
                            validMix = true;
                        }
                    }
                }
            }
        }



    }

    private void PerfectCoffee()
    {
        childList[8].GetComponent<ParticlesActionHappy>().SetCoffeeParticlesHappy(true);
        validMix = false;
    }

    private void UndrinkableCoffee()
    {
        childList[10].GetComponent<ParticlesActionSad>().SetCoffeeParticlesSad(true);
        validMix = false;
    }

    public void GetInt(float number)
    {
        tempRecivided = number;
    }

    public void GetBool(bool valida2)
    {
        valid1 = valida2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jar"))
        {
            valid2 = true;
            other.GetComponent<FillWaterJar>().SetFloat(tempRecivided);
            validMix2 = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            validPlayer = true;

            if (childList[10].GetComponent<ParticleSystem>().isEmitting)
            {
                validEmittingA = true;
                childList[10].GetComponent<ParticlesActionSad>().SetCoffeeParticlesSad(false);
            }

            if (childList[8].GetComponent<ParticleSystem>().isEmitting)
            {
                validEmittingB = true;
                childList[8].GetComponent<ParticlesActionHappy>().SetCoffeeParticlesHappy(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Jar"))
        {
            valid2 = false;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            validPlayer = false;

            if (childList[6].transform.localScale.y <= 0)
            {
                if (validEmittingA)
                {
                    childList[10].GetComponent<ParticlesActionSad>().SetCoffeeParticlesSad(false);
                }

                if (validEmittingB)
                {
                    childList[8].GetComponent<ParticlesActionHappy>().SetCoffeeParticlesHappy(false);
                }
            }
            else
            {
                if (validEmittingA)
                {
                    childList[10].GetComponent<ParticlesActionSad>().SetCoffeeParticlesSad(true);
                }

                if (validEmittingB)
                {
                    childList[8].GetComponent<ParticlesActionHappy>().SetCoffeeParticlesHappy(true);
                }
            }
        }
    }
}
