using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptC : MonoBehaviour {

	public int currentAmmoActual = 3;
	public int currentBalasRestantesActuales = 15;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 3;
	public int bulletsToDeduct;

	public ShotgunTriple arma;

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
		yield return new WaitForSeconds(.4f);
		arma.isShooting = false;
	}


}
