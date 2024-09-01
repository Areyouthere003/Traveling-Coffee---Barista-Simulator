using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject platform;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform finalPoint;
    
    Vector3 moveTo;
    bool valid = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (valid)
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, moveTo, speed * Time.deltaTime);

        if (platform.transform.position == startPoint.position)
        {
            StartCoroutine(TiempoEspera());
            moveTo = finalPoint.position;
            valid = false;

        }

        if (platform.transform.position == finalPoint.position)
        {
            StartCoroutine(TiempoEspera());
            moveTo = startPoint.position;
            valid = false;
        }
    }
    IEnumerator TiempoEspera()
    {
        valid = false;
        yield return new WaitForSeconds(5);
        valid = true;
    }
}

