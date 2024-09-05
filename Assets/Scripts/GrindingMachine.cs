using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingMachine : MonoBehaviour
{
    [SerializeField] GameObject coffeBeans;
    [SerializeField] Transform[] childList;
    [SerializeField] bool grindOn = false, fillMachine = false;
    [SerializeField] int velocityGrind = 30;
    [SerializeField] float VelocityConsume = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        childList = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grindOn)
        {

            childList[1].GetComponent<Transform>().Rotate(new Vector3(0, velocityGrind * Time.deltaTime, 0));

            coffeBeans.transform.localPosition = Vector3.MoveTowards(coffeBeans.transform.localPosition, childList[18].transform.localPosition, VelocityConsume * Time.deltaTime);
            
            if (coffeBeans.transform.localPosition.y <= childList[18].transform.localPosition.y)
            {
                grindOn= false;
                coffeBeans.transform.localPosition = new Vector3(0.003f, 0, 0);
            }

        }

        if(fillMachine)
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
