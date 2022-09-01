using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparecer : MonoBehaviour {
    public float limit_time;
    public float conten_time;
    public GameObject instan;
	// Use this for initialization
	void Start () {
		
	}
                                            //SOY HACKER-MAN XD
    // Update is called once per frame
    void Update() {
        conten_time += Time.deltaTime;
        if (conten_time >= limit_time)
        {
            instan.SetActive(true);
        }
	}
}
