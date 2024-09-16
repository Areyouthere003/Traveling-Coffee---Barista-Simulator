using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class Thermometer : MonoBehaviour
{
    float tempRecivided = 0;
    [SerializeField] TMP_Text text2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButton()
    {
        text2.text = Convert.ToString(tempRecivided + " C°");
    }

    public void GetTemp(float number)
    {
        tempRecivided = number;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Jar"))
        {
            other.GetComponent<FillWaterJar>().SetFloat(tempRecivided);
            //Debug.Log(tempRecivided);
        }
    }

}
