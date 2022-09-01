using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptF : MonoBehaviour {

	public int currentAmmoActual = 100;
	public int currentBalasRestantesActuales = 0;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 100;
	public int bulletsToDeduct;

    public TextMeshProUGUI textMeshProUGUIGasolina;
    public TextMeshProUGUI textMeshProUGUIBidon;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        textMeshProUGUIGasolina.text = currentAmmoActual.ToString();
        textMeshProUGUIBidon.text = "/" + currentBalasRestantesActuales.ToString();

    }

	public void Fire()
	{
		currentAmmoActual--;
	}

	public void Reloading()
	{
		diferenciaDeBalasEntreElMaximoYElReloading = maxAmmoPorCartucho - currentAmmoActual;
		bulletsToDeduct = (currentBalasRestantesActuales >= diferenciaDeBalasEntreElMaximoYElReloading) ? diferenciaDeBalasEntreElMaximoYElReloading : currentBalasRestantesActuales;
		


		
	}


}
