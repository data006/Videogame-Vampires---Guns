using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAudio : MonoBehaviour {

	public AudioSource cancion;

	public float inicio = 0f;
	public float fin = 1f;

	public void Start () {
		

		
	}
	

	
	void Update () {

			if (cancion.time >= fin)
			{
				Debug.Log("LOOP! " + cancion.time);
				cancion.time = inicio;
			}

		
	}
	
	

}
