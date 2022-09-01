using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptH : MonoBehaviour {

	public int currentAmmoActual = 6;
	public int currentBalasRestantesActuales = 999999999;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 6;
	public int bulletsToDeduct;

	public Raygun revolver;

    public GameObject rayoIzquierdo;
    public GameObject rayoCentral;
    public GameObject rayoDerecho;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
        rayoIzquierdo.SetActive(true);
        rayoCentral.SetActive(true);
        rayoDerecho.SetActive(true);
        yield return new WaitForSeconds(.18f);
        rayoIzquierdo.SetActive(false);
        rayoCentral.SetActive(false);
        rayoDerecho.SetActive(false);

        yield return new WaitForSeconds(.23f);
        revolver.isShooting = false;

    }



}
