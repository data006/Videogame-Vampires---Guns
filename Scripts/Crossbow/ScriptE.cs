using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptE : MonoBehaviour {

	public int currentAmmoActual = 1;
	public int currentBalasRestantesActuales = 10;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 1;
	public int bulletsToDeduct;

	public Crossbow arma;

    public TextMeshProUGUI textMeshProUGUIFlechas;
    public TextMeshProUGUI textMeshProUGUICarcaj;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        textMeshProUGUIFlechas.text = currentAmmoActual.ToString();
        textMeshProUGUICarcaj.text = "/" + currentBalasRestantesActuales.ToString();

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
		arma.isShooting = false;
	}


}
