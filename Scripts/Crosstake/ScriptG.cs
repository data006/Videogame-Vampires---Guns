using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptG : MonoBehaviour {

	Ray ray;

	public int currentAmmoActual = 999999999;
	public int currentBalasRestantesActuales = 999999999;
	public int diferenciaDeBalasEntreElMaximoYElReloading = 0;
	public int maxAmmoPorCartucho = 999999999;
	public int bulletsToDeduct;

	public Crosstake arma;

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
		yield return new WaitForSeconds(.12f);

		arma.muzzleFlash.Play();
		arma.muzzleLight.Play();

		RaycastHitRenderer hit;
		ray = new Ray(arma.fpsCam.transform.position, arma.fpsCam.transform.forward);

		if (SuperRaycast.Raycast(ray, out hit, arma.range, ~((1 << 2) | (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12))))
		{
			Debug.Log(hit.gameObject.name);


			VidaEnemiga vidaEnemiga = hit.gameObject.GetComponentInParent<VidaEnemiga>();
			if (vidaEnemiga != null)
			{
				vidaEnemiga.TakeDamage(arma.damage);
			}

			if (hit.gameObject.layer == 9)
			{
				Debug.Log("Si es un enemigo");
			}


			GameObject impactGO = Instantiate(arma.impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, .15f);
		}

		yield return new WaitForSeconds(.38f);

		arma.isShooting = false;
	}


}
