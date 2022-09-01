using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {

	public static EstadoJuego estadoJuego;
	private String rutaArchivo;



	public bool intro = false;

	public bool raygunTomada = false;

	public bool nivel1 = false;
	public bool nivel2 = false;
	public bool nivel3 = false;
	public bool nivel4 = false;
	public bool nivel5 = false;
	public bool nivel6 = false;
	public bool nivel7 = false;
	public bool nivel8 = false;
	public bool nivel9 = false;
	public bool nivel10 = false;
	public bool nivel11 = false;
	public bool nivel12 = false;
	public bool nivel13 = false;
	public bool nivel14 = false;
	public bool nivel15 = false;
	public bool nivel16 = false;
	public bool nivel17 = false;
	public bool nivel18 = false;
	public bool nivel19 = false;

	private void Awake()
	{
		rutaArchivo = Application.persistentDataPath + "/datos.dat";

		if (estadoJuego == null)
		{
			estadoJuego = this;

			DontDestroyOnLoad(gameObject);
		}
		else if (estadoJuego != this)
		{
			Destroy(gameObject);
		}
	}


	// Use this for initialization
	void Start () {
		Cargar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Guardar()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);

		DatosAGuardar datos = new DatosAGuardar();
		datos.nivel1 = nivel1;

		bf.Serialize(file, datos);

		file.Close();
	}

	void Cargar()
	{
		if (File.Exists(rutaArchivo))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);

			DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);

			nivel1 = datos.nivel1;

			file.Close();
		}
	}
}

[Serializable]
class DatosAGuardar
{
	public bool intro = false;

	public bool raygunTomada = false;

	public bool nivel1 = false;
	public bool nivel2 = false;
	public bool nivel3 = false;
	public bool nivel4 = false;
	public bool nivel5 = false;
	public bool nivel6 = false;
	public bool nivel7 = false;
	public bool nivel8 = false;
	public bool nivel9 = false;
	public bool nivel10 = false;
	public bool nivel11 = false;
	public bool nivel12 = false;
	public bool nivel13 = false;
	public bool nivel14 = false;
	public bool nivel15 = false;
	public bool nivel16 = false;
	public bool nivel17 = false;
	public bool nivel18 = false;
	public bool nivel19 = false;
}
