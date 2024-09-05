using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerTime : MonoBehaviour
{
    [SerializeField] Transform[] childrenObjects;
    [SerializeField] float setTime = 0;
    [SerializeField] int realSeconds;
    [SerializeField] bool startSound= false, timeRunning = false;

    Vector3 setRotFace= Vector3.zero;

    void Start()
    {
        childrenObjects = GetComponentsInChildren<Transform>();
    }

    void Update()
    {

        if (timeRunning)
        {
            if(startSound)
            {
                childrenObjects[4].GetComponentInChildren<AudioSource>().Play(); //tic tac sound
                startSound= false;
            }

            childrenObjects[1].Rotate(new Vector3(0, -6 * Time.deltaTime, 0));
            setTime -= Time.deltaTime;
            realSeconds = Convert.ToInt32(setTime);

            if(realSeconds == 0)
            {
                childrenObjects[4].GetComponentInChildren<AudioSource>().Stop(); //tic tac sound
                childrenObjects[7].GetComponent<AudioSource>().Play();  //chim sound
                CollidersOn();
                timeRunning = false;
            }
        }

    }

    public void StopTimerTime()
    {
        timeRunning= false;
    }

    public void SetPositionHandle()
    {
        switch (setTime)
        {
            case 15:
                SetPosRotHandle(-90);
                break;
            case 30:
                SetPosRotHandle(-179);
                break;
            case 45:
                SetPosRotHandle(-270);
                break;
            case 60:
                SetPosRotHandle(0);
                break;
        }

        startSound = true;
        timeRunning = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Timer"))
        {
            setTime += 15;
        }

        switch(setTime)
        {
            case 15:
                childrenObjects[4].GetComponent<Collider>().enabled = false;
                break;
            case 30:
                childrenObjects[5].GetComponent<Collider>().enabled = false;
                break;
            case 45:
                childrenObjects[6].GetComponent<Collider>().enabled = false;
                childrenObjects[7].GetComponent<Collider>().enabled = true;
                break;
            case 60:
                childrenObjects[7].GetComponent<Collider>().enabled = false;
                break;
        }
    }

    public void CollidersOn()
    {
        childrenObjects[4].GetComponentInChildren<AudioSource>().Stop(); //tic tac sound
        childrenObjects[4].GetComponent<Collider>().enabled = true;
        childrenObjects[5].GetComponent<Collider>().enabled = true;
        childrenObjects[6].GetComponent<Collider>().enabled = true;
        childrenObjects[7].GetComponent<Collider>().enabled = false;
        setTime= 0; setRotFace.x = 0; setRotFace.y = 0; setRotFace.z = 90;
        childrenObjects[1].transform.localRotation = Quaternion.Euler(setRotFace);
    }

    private void SetPosRotHandle(int valueX)
    {
        setRotFace = childrenObjects[1].transform.rotation.eulerAngles;
        setRotFace.x = valueX; setRotFace.y = 0; setRotFace.z = 90;
        childrenObjects[1].transform.localRotation = Quaternion.Euler(setRotFace);
        childrenObjects[1].transform.localPosition = new Vector3(-0.0427838489f, 0.0997980312f, 0);
    }

    public void MoreMin()
    {
        childrenObjects[4].GetComponent<Collider>().enabled = true;
        childrenObjects[5].GetComponent<Collider>().enabled = true;
        childrenObjects[6].GetComponent<Collider>().enabled = true;
        childrenObjects[7].GetComponent<Collider>().enabled = true;
    }
}
