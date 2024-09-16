using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGrindCoffee : MonoBehaviour
{
    [SerializeField] Transform visualRecipient;
    [SerializeField] Transform[] childList;
    [SerializeField] bool valid01 = false, valid02 = false, valid03 = false;

    // Start is called before the first frame update
    void Start()
    {
        childList = gameObject.GetComponentsInChildren<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        TraspassingCoffee();


        if (valid03)
        {
            if (childList[3].transform.localScale.y < 1)
            {
                childList[3].transform.localScale = new Vector3(childList[3].transform.localScale.x, childList[3].transform.localScale.y + 0.05f * Time.deltaTime, childList[3].transform.localScale.z);
            }
            else
            {
                childList[3].transform.localScale = new Vector3(childList[3].transform.localScale.x, 1, childList[3].transform.localScale.z);
                valid03 = false;
            }

        }
    }

    private void TraspassingCoffee()
    {
        if (valid01)
        {
            if (gameObject.transform.rotation.eulerAngles.x > 85 || gameObject.transform.rotation.eulerAngles.z > 250 && gameObject.transform.rotation.eulerAngles.z < 297)
            {

                if (valid02)
                {
                    childList[3].transform.localScale = new Vector3(childList[3].transform.localScale.x, childList[3].transform.localScale.y - 0.5f * Time.deltaTime, childList[3].transform.localScale.z);

                    if (childList[3].transform.localScale.y < 0)
                    {
                        childList[3].transform.localScale = new Vector3(childList[3].transform.localScale.x, 0, childList[3].transform.localScale.z);
                        valid02 = false;
                    }
                }
                else
                {
                    childList[3].transform.localScale = new Vector3(childList[3].transform.localScale.x, 0, childList[3].transform.localScale.z);
                    valid02 = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GrindingRecipient"))
        {
            if (visualRecipient.localScale.y > 0)
            {
                visualRecipient.localScale = new Vector3(visualRecipient.localScale.x, visualRecipient.localScale.y - 0.15f, visualRecipient.localScale.z);
                valid03 = true;
            }
            else
            {
                visualRecipient.localScale = new Vector3(visualRecipient.localScale.x, 0, visualRecipient.localScale.z);
                valid03 = false;
            }

        }

        if (other.gameObject.CompareTag("Cup"))
        {
            valid01 = true;
            valid02 = true;
            other.GetComponent<PorcelainCupFill>().GetBool(valid02);
        }
    }

}
