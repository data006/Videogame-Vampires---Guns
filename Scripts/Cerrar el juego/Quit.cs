using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public float limit_time;
    public float conten_time;
    // Use this for initialization
    void Start()
    {

    }
    //SOY HACKER-MAN XD
    // Update is called once per frame
    void Update()
    {
		Time.timeScale = 1f;
        conten_time += Time.deltaTime;
        if (conten_time >= limit_time)
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}
