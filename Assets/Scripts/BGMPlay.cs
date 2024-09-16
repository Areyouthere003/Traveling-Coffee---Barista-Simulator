using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BGMPlay : MonoBehaviour
{

    [SerializeField] AudioSource[] bgmList;
    //[SerializeField] List<int> bgmCount;
    //[SerializeField] bool randomPlay = false;
    [SerializeField] private int currentNumberIndex = 0, pastNumber01 = 0, pastNumber02 = 0;

    private AudioSource audiosource;
    

    void Start()
    {
        currentNumberIndex = GetRandomNumber(currentNumberIndex);
        bgmList = gameObject.GetComponentsInChildren<AudioSource>();
        audiosource = bgmList[currentNumberIndex].GetComponent<AudioSource>();
        audiosource.Play();
    }

    void Update()
    {
        if(!audiosource.isPlaying)
        {
            pastNumber02 = pastNumber01;
            pastNumber01 = currentNumberIndex;
            currentNumberIndex = GetRandomNumber(currentNumberIndex);
            
            if (pastNumber01 != currentNumberIndex && pastNumber02 != currentNumberIndex)
            {
                audiosource = bgmList[currentNumberIndex].GetComponent<AudioSource>();
                audiosource.Play();
            }
            else
            {
                currentNumberIndex = GetRandomNumber(currentNumberIndex);
            }
            
        }
        else
        {

        }
    }

    private int GetRandomNumber(int number)
    {
        number = Random.Range(0, 7);
        return number;
    }

    //private AudioClip GetNextClip()
    //{
    //    return clips[(currentClipIndex + 1) % (clips.Length)];
    //}

    //private void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //}
}
