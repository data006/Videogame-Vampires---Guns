using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayosMenu : MonoBehaviour {


	public ParticleSystem rayoFuerte;
	public ParticleSystem rayoDerecho;
	public ParticleSystem rayoLeve;
	public ParticleSystem rayoMaso;
	public ParticleSystem rayoIzquierdo;

	public ParticleSystem rayoFuerte2;
	public ParticleSystem rayoDerecho2;
	public ParticleSystem rayoLeve2;
	public ParticleSystem rayoMaso2;
	public ParticleSystem rayoIzquierdo2;

	public float current;

	// Use this for initialization
	void Start()
	{
		//Start the coroutine we define below named ExampleCoroutine.
		StartCoroutine(ExampleCoroutine());
	}

	IEnumerator ExampleCoroutine()
	{
		rayoFuerte.Play();
		yield return new WaitForSeconds(0.17f);
		rayoFuerte.Stop();
		yield return new WaitForSeconds(0.2f);
		rayoDerecho.Play();



		yield return new WaitForSeconds(0.89f);
		rayoDerecho2.Play();
		rayoFuerte2.Play();
		rayoIzquierdo2.Play();
		yield return new WaitForSeconds(0.5f);
		rayoMaso2.Play();
		rayoLeve2.Play();
		rayoDerecho2.Play();
		yield return new WaitForSeconds(1.2f);
		rayoIzquierdo2.Play();
		rayoLeve2.Play();
		rayoDerecho2.Play();
		yield return new WaitForSeconds(2f);
		rayoLeve2.Play();
		rayoDerecho2.Play();
		rayoFuerte2.Play();
		yield return new WaitForSeconds(2f);
		rayoIzquierdo2.Play();
		rayoLeve2.Play();
		rayoDerecho2.Play();




		yield return new WaitForSeconds(1.23f);
		rayoLeve.Play();
		yield return new WaitForSeconds(0.98f);
		rayoMaso.Play();
		yield return new WaitForSeconds(1.4f);
		rayoMaso.Play();
		rayoLeve.Play();
		rayoDerecho.Play();
		rayoFuerte.Play();
		rayoIzquierdo.Play();
		yield return new WaitForSeconds(0.7f);
		rayoMaso.Play();
		rayoLeve.Play();
		rayoDerecho.Play();
		rayoFuerte.Play();
		rayoIzquierdo.Play();
		rayoMaso2.Play();
		rayoLeve2.Play();
		rayoDerecho2.Play();
		rayoFuerte2.Play();
		rayoIzquierdo2.Play();



		yield return new WaitForSeconds(1f);
		rayoDerecho2.Play();
		rayoFuerte2.Play();
		rayoIzquierdo2.Play();
		yield return new WaitForSeconds(0.5f);
		rayoMaso2.Play();
		rayoLeve2.Play();
		rayoDerecho2.Play();
		yield return new WaitForSeconds(1.2f);
		rayoIzquierdo2.Play();
		rayoLeve2.Play();
		rayoDerecho2.Play();
		yield return new WaitForSeconds(2f);
		rayoLeve2.Play();
		rayoDerecho2.Play();
		rayoFuerte2.Play();
		yield return new WaitForSeconds(2f);
		rayoIzquierdo2.Play();
		rayoLeve2.Play();
		rayoDerecho2.Play();

		//After we have waited 5 seconds print the time again.
		Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}
}
