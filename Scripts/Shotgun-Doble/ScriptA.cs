using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptA : MonoBehaviour {

	public int currentAmmoActual = 2;
	public int currentBalasRestantesActuales = 20;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 2;
	public int bulletsToDeduct;

	public ShotgunDoble arma;

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
		yield return new WaitForSeconds(.135f);
		arma.isShooting = false;
	}


}
