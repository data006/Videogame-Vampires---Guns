using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSelectLevel : MonoBehaviour {
	public float limit_time;
	public float conten_time = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		conten_time += Time.deltaTime;
		if (conten_time >= limit_time)
		{
			SceneManager.LoadScene("00 Select Level");
		}
	}
}
