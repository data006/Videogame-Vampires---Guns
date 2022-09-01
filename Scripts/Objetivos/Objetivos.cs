using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{

	public float entradaObjetivo;
	public float salidaObjetivo;
	public float tiempoTranscurrido = 0;

	public bool mostrarObjetivo = false;
	public bool fueraObjetivo = false;

	public bool win = false;
	public bool lose = false;

	public AudioSource sonidoObjetivo;
	public AudioSource cancion;
	public AudioSource sonidoWin;

	public GameObject killemAll;

	public GameObject Canvas;
	public GameObject CanvasWin;
	public GameObject CanvasPause;

	public TomarMunicion tomarMunicion;
	public WeaponSwitching weaponSwitching;
	public bool shotgunDobleTomada;
	public bool shotgunTripleTomada;
	public bool minigunTomada;
	public bool crossbowTomada;
	public bool chainsawTomada;
	public bool crosstakeTomada;
	public bool raygunTomada;

	public GameObject letreroShotgunDoble;
	public GameObject letreroShotgunTriple;
	public GameObject letreroMinigun;
	public GameObject letreroCrossbow;
	public GameObject letreroChainsaw;
	public GameObject letreroCrosstake;
	public GameObject letreroRaygun;

	void Start()
	{

	}

	void Update()
	{


		if (mostrarObjetivo == false)
		{
			tiempoTranscurrido += Time.deltaTime;
			if (tiempoTranscurrido >= entradaObjetivo)
			{
				killemAll.SetActive(true);
				sonidoObjetivo.Play();
				tiempoTranscurrido = 0;
				mostrarObjetivo = true;
			}
		}

		if (fueraObjetivo == false)
		{
			tiempoTranscurrido += Time.deltaTime;
			if (tiempoTranscurrido >= salidaObjetivo)
			{
				killemAll.SetActive(false);
				fueraObjetivo = true;
				tiempoTranscurrido = 0;
			}
		}


		if(win == true && lose == false)
		{
			
			cancion.Stop();
			sonidoWin.Play();
			

			weaponSwitching.ToPause();
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			this.enabled = false;
		}

		if (win == false && lose == true)
		{
			
			sonidoWin.Play();//////////////////////////////////cambiar a sonidoLose


			weaponSwitching.ToPause();
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			this.enabled = false;
		}

	}

	

}