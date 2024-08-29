using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    [SerializeField] List<Transform> lightRoomList;
    [SerializeField] Transform[] individualLight;
    [SerializeField] public bool triggerTest = true;

    // Start is called before the first frame update
    void Start()
    {
        individualLight = GetComponentsInChildren<Transform>();
        GetChildList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetChildList()
    {
        for(int i = 3; i <= individualLight.Length; i += 4)
        {            
            lightRoomList.Add(individualLight[i].GetComponentInChildren<Transform>());
        }
    }

    public void TurnOnLight()
    {
        if (triggerTest)
        {
            for (int i = 0; i < lightRoomList.Count; i++)
            {
                lightRoomList[i].gameObject.SetActive(true);
            }

            triggerTest = false;

            RenderSettings.fog = false;
        }
        else
        {
            for (int i = 0; i < lightRoomList.Count; i++)
            {
                lightRoomList[i].gameObject.SetActive(false);
            }

            triggerTest = true;

            RenderSettings.fog = true;
        }
    }
}
