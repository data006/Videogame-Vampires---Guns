using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class EstadoSensibilidad : MonoBehaviour {
	


    public Slider sensitivitySlider;

    public float x;

   

	// Use this for initialization
	void Start () {
        sensitivitySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public void ValueChangeCheck()
    {
		x = (sensitivitySlider.value);
		GetComponent<FirstPersonController>().ChangeMouseSensitivity(x, x);
		

        Debug.Log(x);
    }

    

}
