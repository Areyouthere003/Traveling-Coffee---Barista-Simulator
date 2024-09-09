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
    [SerializeField] public GameObject switchObject;
    [SerializeField] public GameObject nextMenus;
    private Material outlineMaterial;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
        individualLight = GetComponentsInChildren<Transform>();
        Renderer renderer = switchObject.GetComponent<Renderer>();

        // Ensure the object has a material
        if (renderer != null)
        {
            outlineMaterial = renderer.material;
        };
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
        outlineMaterial.SetFloat("_Outline", 0.0f);
        if (!nextMenus.activeSelf) nextMenus.SetActive(true);
    }
}
