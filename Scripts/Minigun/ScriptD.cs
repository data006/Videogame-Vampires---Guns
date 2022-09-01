using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptD : MonoBehaviour {

	public int currentAmmoActual = 100;
	public int currentBalasRestantesActuales = 100;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 100;
	public int bulletsToDeduct;

	public Minigun arma;

    public TextMeshProUGUI textMeshProUGUIBalas;
    public TextMeshProUGUI textMeshProUGUICartucho;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        textMeshProUGUIBalas.text = currentAmmoActual.ToString();
        textMeshProUGUICartucho.text = "/" + currentBalasRestantesActuales.ToString();

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
