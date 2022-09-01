using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitInGame : MonoBehaviour
{
	public float limit_time;
	public float conten_time;
	public AudioSource audioSource;
	public bool ia = false;
	// Use this for initialization
	void Start()
	{

	}
	//SOY HACKER-MAN XD
	// Update is called once per frame
	void Update()
	{
		if (audioSource.isPlaying == false && ia == true)
		{

			Debug.Log("QUIT!");
			Application.Quit();
		}

		if (ia == true)
			return;

		if (audioSource.isPlaying == false && ia == false)
		{
			ia = true;
			audioSource.Play();
		}
		
			
		
	}
}
