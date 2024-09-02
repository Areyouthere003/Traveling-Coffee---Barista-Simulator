using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] GameObject platform;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform finalPoint;
    
    Vector3 moveTo;
    bool valid = false;
    float valid2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (valid) //up & down
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, moveTo, speed * Time.deltaTime);
            
        }

        if(platform.transform.position == finalPoint.transform.position)
        {
            valid = false;
        }

        if (platform.transform.position == startPoint.transform.position)
        {
            valid = false;
        }

    }
    
    public void GetUpDown()
    {
        switch(valid2)
        {
            case 0:
                moveTo = finalPoint.position;
                valid = true;
                valid2++;
                break;
            case 1:
                moveTo = startPoint.position;
                valid = true;
                valid2--;
                break;
            default:
                valid = false;
                valid2 = 0;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            other.transform.parent = platform.transform;
         }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}

