using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ValorSlider : MonoBehaviour {

	public Slider sensitivitySlider;

	public EstadoSensibilidad estadoSensibilidad;

	// Use this for initialization
	void Start () {
		sensitivitySlider.value = estadoSensibilidad.x;
	}

	// Update is called once per frame
	void Update() {
		
	}
}
