using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptB : MonoBehaviour {

	public int currentAmmoActual = 6;
	public int currentBalasRestantesActuales = 999999999;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 6;
	public int bulletsToDeduct;

	public Revolver revolver;

    public TextMeshProUGUI textMeshProUGUIBalas;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        textMeshProUGUIBalas.text = currentAmmoActual.ToString();
		
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

	public IEnumerator Disparando()
	{
		yield return new WaitForSeconds(.125f);
		revolver.isShooting = false;
	}



}
