using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingMachine : MonoBehaviour
{

    [Header("Machine Grinding Action Settings")]
    [SerializeField] GameObject coffeBeans;
    [SerializeField] Transform[] childList;
    [SerializeField] int velocityGrind = 30;
    [SerializeField] float VelocityConsume = 0.01f;

    [Header("Machine Grinding Sound Settings")]
    [Tooltip("Initial Audio Source, in start sequence")]
    [SerializeField] AudioSource startAudio; [SerializeField] AudioSource middleAudio; [SerializeField] AudioSource finishAudio;

    //bools associated to action movement
    bool grindOn = false, fillMachine = false;

    //bools associated to the sounds
    bool eventStart = false, eventMiddle= false, eventFinish = false, eventMain = false;
    int statePos = 3;

    // Start is called before the first frame update
    void Start()
    {
        childList = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundGMC();
    }

    private void SoundGMC()
    {
        if (eventMain)
        {
            if (!startAudio.isPlaying && statePos == 0)
            {
                statePos++;
                eventMiddle = true;
            }
            else if (!middleAudio.isPlaying && statePos == 1)
            {
                statePos++;
                eventFinish = true;
            }
            else if (!finishAudio.isPlaying && statePos == 2)
            {
                statePos++;
            }

            if (eventStart && statePos == 0)
            {
                startAudio.Play();

                if (startAudio.isPlaying)
                {
                    eventStart = false;
                }
            }
            else if (eventMiddle && statePos == 1)
            {
                middleAudio.Play();

                if (middleAudio.isPlaying)
                {
                    eventMiddle = false;
                }
            }
            else if (eventFinish && statePos == 2)
            {
                finishAudio.Play();

                if (finishAudio.isPlaying)
                {
                    eventFinish = false;
                    eventMain = false;
                }
            }
        }
    }

    public void PlayStopSound()
    {
        if (statePos == 1)
        {
            startAudio.Stop();
            middleAudio.Stop();
            //statePos = 2;
            eventFinish = true;
        }
        else
        {
            eventMain = true;
            eventStart = true;
            statePos = 0;
        }

    }

    public void FillMachine()
    {
        fillMachine = true;
    }

    public void GrindOn(int number)
    {
        if(!grindOn)
        {
            velocityGrind = number;
            grindOn = true;
        }
        else
        grindOn = false;
    }

    public void VConsume(float number)
    {
        VelocityConsume = number;
    }
}
