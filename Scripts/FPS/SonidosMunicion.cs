using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosMunicion : MonoBehaviour {


	public GameObject municion1;
	public bool municion1Null = false;
	public GameObject municion2;
	public bool municion2Null = false;
	public GameObject municion3;
	public bool municion3Null = false;
	public GameObject municion4;
	public bool municion4Null = false;
	public GameObject municion5;
	public bool municion5Null = false;
	public GameObject municion6;
	public bool municion6Null = false;
	public GameObject municion7;
	public bool municion7Null = false;

	public GameObject flechas1;
	public bool flechas1Null = false;
	public GameObject flechas2;
	public bool flechas2Null = false;

	public GameObject gas1;
	public bool gas1Null = false;

	public AudioSource ammoSound;
	public AudioSource flechaSound;
	public AudioSource gasSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (municion1 == null && municion1Null == false)
		{
			municion1Null = true;
			ammoSound.Stop();
			ammoSound.Play();
		}

		if (municion2 == null && municion2Null == false)
		{
			municion2Null = true;
			ammoSound.Stop();
			ammoSound.Play();
		}

		if (municion3 == null && municion3Null == false)
		{
			municion3Null = true;
			ammoSound.Stop();
			ammoSound.Play();
		}

		if (municion4 == null && municion4Null == false)
		{
			municion4Null = true;
			ammoSound.Stop();
			ammoSound.Play();
		}

		if (municion5 == null && municion5Null == false)
		{
			municion5Null = true;
			ammoSound.Stop();
			ammoSound.Play();
		}

		if (municion6 == null && municion6Null == false)
		{
			municion6Null = true;
			ammoSound.Stop();
			ammoSound.Play();
		}

		if (municion7 == null && municion7Null == false)
		{
			municion7Null = true;
			ammoSound.Stop();
			ammoSound.Play();
		}






		if (flechas1 == null && flechas1Null == false)
		{
			flechas1Null = true;
			flechaSound.Stop();
			flechaSound.Play();
		}

		if (flechas2 == null && flechas2Null == false)
		{
			flechas2Null = true;
			flechaSound.Stop();
			flechaSound.Play();
		}







		if (gas1 == null && gas1Null == false)
		{
			gas1Null = true;
			gasSound.Stop();
			gasSound.Play();
		}
	}
}
