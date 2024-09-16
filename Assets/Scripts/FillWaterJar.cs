using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWaterJar : MonoBehaviour
{
    [SerializeField] float tempWater = 0, maxTemp = 92f, resetTemp = 0f, setTime = 60f;

    [SerializeField] GameObject[] gameObjectList;

    [SerializeField] Transform[] childList;

    [SerializeField] bool button1 = false, button2 = false, button3 = false, button4 = false;

    bool valid = false, contactStove = false, valid02 = false;
    int stovePos = 0, realSec = 60;

    // Start is called before the first frame update
    void Start()
    {

        childList = gameObject.GetComponentsInChildren<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.rotation.eulerAngles.z);
        DetectingGO();

        if(valid)
        {
            if (childList[3].transform.localScale.y < 1)
            {
                childList[3].transform.localScale = new Vector3(childList[2].transform.localScale.x, childList[3].transform.localScale.y + 0.07f * Time.deltaTime, childList[3].transform.localScale.z);
            }

        }

        if(gameObject.transform.rotation.eulerAngles.x > 85 || gameObject.transform.rotation.eulerAngles.z > 250 && gameObject.transform.rotation.eulerAngles.z < 297)
        {
            childList[5].GetComponent<Collider>().enabled = true;

            if (childList[3].GetComponentInChildren<Transform>().transform.localScale.y > 0)
            {
                childList[3].transform.localScale = new Vector3(childList[3].transform.localScale.x, childList[3].transform.localScale.y - 0.07f * Time.deltaTime, childList[3].transform.localScale.z);
                valid02 = true;
            }
            else
            {
                childList[3].transform.localScale = new Vector3(childList[3].transform.localScale.x, 0, childList[3].transform.localScale.z);
                valid02 = false;
            }
        }
        else
            childList[5].GetComponent<Collider>().enabled = false;


        if (contactStove)
        {
            if(button1 || button2 || button3 || button4)
            {
                
                if (setTime > 0)
                {
                    setTime -= Time.deltaTime;
                    realSec = Convert.ToInt32(setTime);

                    if (tempWater < 94)
                    {
                        tempWater += 1.6f * Time.deltaTime;
                    }
                    else tempWater = maxTemp;
                }
            }
        }
    }

    private void DetectingGO()
    {
        if (gameObjectList[0].activeInHierarchy)
        {
            button1 = true;
            stovePos = 1;
        }
        else { button1 = false; }

        if (gameObjectList[1].activeInHierarchy)
        {
            button2 = true;
            stovePos = 2;
        }
        else { button2 = false; }

        if (gameObjectList[2].activeInHierarchy)
        {
            button3 = true;
            stovePos = 3;
        }
        else { button3 = false; }

        if (gameObjectList[3].activeInHierarchy)
        {
            button4 = true;
            stovePos = 4;
        }
        else { button4 = false;}


    }

    public void SetBool(bool valid2)
    {
        contactStove = valid2;
    }

    public void GetBool(bool valid2)
    {
        valid = valid2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cup"))
        {
            other.GetComponent<PorcelainCupFill>().GetInt(tempWater);
        }

        if(other.gameObject.CompareTag("Thermo"))
        {
            other.GetComponent<Thermometer>().GetTemp(tempWater);
        }

        if(other.gameObject.CompareTag("Dispensser"))
        {
            tempWater = resetTemp; 
        }
    }

    public float SetFloat(float tempNumber)
    {
        if(valid02)
        {
            tempNumber = tempWater;
            return tempNumber;
        }
        else
        {
            return tempNumber;
        }

    }
}