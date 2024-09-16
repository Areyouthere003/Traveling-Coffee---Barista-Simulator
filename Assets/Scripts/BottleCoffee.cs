using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCoffee : MonoBehaviour
{
    [SerializeField] GameObject grindingMachine;
    [SerializeField] bool valid01 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (valid01)
        {
            if (gameObject.transform.rotation.eulerAngles.x > 85 || gameObject.transform.rotation.eulerAngles.z > 250 && gameObject.transform.rotation.eulerAngles.z < 297)
            {
                grindingMachine.GetComponent<GrindingMachine>().FillMachine(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GrindingMachine"))
        {
            valid01 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GrindingMachine"))
        {
            valid01 = false;
        }
    }
}
