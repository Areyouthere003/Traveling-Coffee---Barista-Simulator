using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int posObject = 0;

    //[SerializeField] AudioSource firstAudio, middleAudio, finishAudio;
    //bool t_Event01 = false, t_Event02 = false, t_Event03 = false, t_EventMain = false;
    //int statePos = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if(t_EventMain)
        //{
        //    if (!firstAudio.isPlaying && statePos == 0)
        //    {
        //        statePos++;
        //        t_Event02 = true;
        //    }
        //    else if (!middleAudio.isPlaying && statePos == 1)
        //    {
        //        statePos++;
        //        t_Event03 = true;
        //    }
        //    else if (!finishAudio.isPlaying && statePos == 2)
        //    {
        //        statePos++;
        //    }



        //    if (t_Event01 && statePos == 0)
        //    {
        //        firstAudio.Play();

        //        if (firstAudio.isPlaying)
        //        {
        //            t_Event01 = false;
        //        }
        //    }
        //    else if (t_Event02 && statePos == 1)
        //    {
        //        middleAudio.Play();

        //        if (middleAudio.isPlaying)
        //        {
        //            t_Event02 = false;
        //        }
        //    }
        //    else if (t_Event03 && statePos == 2)
        //    {
        //        finishAudio.Play();

        //        if (finishAudio.isPlaying)
        //        {
        //            t_Event03 = false;
        //            t_EventMain = false;
        //        }
        //    }
        //}

    }

    public void GeneratorObject(string name)
    {
        GameObject prefab = Resources.Load(name) as GameObject;
        
        GameObject create = Instantiate(prefab) as GameObject;

        create.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + posObject, player.transform.position.z);
    }

    //public void PlayStopSound()
    //{
    //    if(statePos == 1) 
    //    {
    //        firstAudio.Stop();
    //        middleAudio.Stop();
    //        //statePos = 2;
    //        t_Event03 = true;
    //    }
    //    else
    //    {
    //        t_EventMain = true;
    //        t_Event01 = true;
    //        statePos = 0;
    //    }
        
    //}
}
