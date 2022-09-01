using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileGuitar : MonoBehaviour {

	public string my_Guitar;
	public int gently_Weeps;
	public bool ia = false;

	// Use this for initialization
	void Start () {






		while (my_Guitar == "Gently Weeps")
		{
			Debug.Log("I don't know why nobody told you how to unfold your love");
			my_Guitar = "I don't know how someone controlled you they bought and sold you";
		}






	}

	// Update is called once per frame
	void Update()
	{
		if (ia == true)
			return;


		if (ia == false && my_Guitar == "Gently Weeps")
		{
			ia = true;
			Start();
		}
	}

	

}
