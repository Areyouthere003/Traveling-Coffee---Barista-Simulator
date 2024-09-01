using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mascara : MonoBehaviour
{
    [SerializeField] GameObject[] MaskObject;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < MaskObject.Length; i++)
        {
            MaskObject[i].GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
