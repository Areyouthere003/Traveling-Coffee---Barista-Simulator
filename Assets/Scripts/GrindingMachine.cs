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
    [SerializeField] bool grindOn = false, fillMachine = false;

    //bools associated to the sounds
    bool eventStart = false, eventMiddle= false, eventFinish = false, eventMain = false;
    int statePos = 3;

    [Header("Recipient coffee")]
    [SerializeField] GameObject recipientCoffee;
    Vector3 desirePos = new Vector3(4.292993068695068f, 0.8756742477416992f, -1.034999966621399f);
    bool valid = false;

    // Start is called before the first frame update
    void Start()
    {
        childList = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundGMC();

        if (grindOn)
        {

            childList[1].GetComponent<Transform>().Rotate(new Vector3(0, velocityGrind * Time.deltaTime, 0));
            coffeBeans.transform.localPosition = Vector3.MoveTowards(coffeBeans.transform.localPosition, childList[18].transform.localPosition, VelocityConsume * Time.deltaTime);
            
        
            if (recipientCoffee.transform.position == desirePos)
            {
                
                if (recipientCoffee.transform.localScale.y < 1)
                {
                    recipientCoffee.transform.localScale = new Vector3(recipientCoffee.transform.localScale.x, recipientCoffee.transform.localScale.y + 0.07f * Time.deltaTime, recipientCoffee.transform.localScale.z);
                }

            }

            if (coffeBeans.transform.localPosition.y <= childList[18].transform.localPosition.y)
            {
                grindOn = false;
                coffeBeans.transform.localPosition = new Vector3(0.003f, 0, 0);
            }

        }

        if (fillMachine)
        {

            if (coffeBeans.transform.localPosition.y < -0.08f)
            {
                coffeBeans.transform.localPosition =
                Vector3.MoveTowards(coffeBeans.transform.localPosition, childList[17].transform.localPosition, 0.3f * Time.deltaTime);

                if (coffeBeans.transform.localPosition.y == -0.08f)
                {
                    fillMachine = false;
                }
            }
            else if (coffeBeans.transform.localPosition.y >= -0.08f && coffeBeans.transform.localPosition.y < 0)
            {
                coffeBeans.transform.localPosition =
                Vector3.MoveTowards(coffeBeans.transform.localPosition, new Vector3(0.003f, 0, 0), 0.3f * Time.deltaTime);

                if (coffeBeans.transform.localPosition.y == 0)
                {
                    fillMachine = false;
                }
            }

        }
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

    public bool GetGrinOn(bool thisValid)
    {
        thisValid = grindOn;

        return thisValid;
    }
}

//public class ParticleSystemOnOFF : PlaticleSystemOnOff
//{

//    //ParticleSystem 
//    PlaticleSystemOnOff coffeParticle;

//    private void Update()
//    {
//        coffeParticle.CoffeeParticlesOnOff(true);

//    }


//}
