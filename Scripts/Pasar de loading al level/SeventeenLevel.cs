﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeventeenLevel : MonoBehaviour
{
    public float limit_time;
    public float conten_time;
    // Use this for initialization
    void Start()
    {

    }
    //Paul is alive XD
    // Update is called once per frame
    void Update()
    {
        conten_time += Time.deltaTime;
        if (conten_time >= limit_time)
        {
            SceneManager.LoadScene("17 Return to Transylvania 616");
        }
    }
}
