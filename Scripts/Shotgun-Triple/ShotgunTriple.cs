using UnityEngine;
using System.Collections;


public class ShotgunTriple : MonoBehaviour {

	Ray ray;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmoPorCartucho = 2;
    public int currentAmmoActual;
	public int maxBalasRestantes = 20;
	public int currentBalasRestantesActuales;
	public int diferenciaDeBalasEntreElMaximoYElReloading;
	public float armaRecargando = 2f;
	public float subiendoArma = 2f;
	public float reloadTime = 5f;
	public bool isShooting = false;
	public bool isReloading = false;
	public bool sonidoRecarga = false;
	public bool sonidoRecarga1 = false;
	public bool sonidoRecarga3 = false;

	public AudioSource disparo;
	public AudioSource recarga1;
	public AudioSource recarga;
	public AudioSource recarga3;
	public AudioSource noAmmo;
	public Animator animator;

	public ScriptC scriptC;
	public WeaponSwitching Switch;


	public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleLight;
    public GameObject impactEffect;

    public float nextTimeToFire = 0f;


    void Start()
    {
        
	}


	// Update is called once per frame
	void Update ()
	{

		if (isReloading)
			return;
		if (Switch.inToRevolver == true)
			return;
		if (Switch.inToShotgunDoble == true)
			return;
		if (Switch.inToShotgunTriple == true)
			return;
		if (Switch.inToMinigun == true)
			return;
		if (Switch.inToCrossbow == true)
			return;
		if (Switch.inToChainsaw == true)
			return;
		if (Switch.inToCrosstake == true)
			return;

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta"))
		{
			animator.Play("DisparoShotgunTriple");
			StartCoroutine(scriptC.Disparando());
		}

		if (isShooting)
			return;

		if (scriptC.currentAmmoActual <= 0 && scriptC.currentBalasRestantesActuales > 0)
		{
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}



		if (Input.GetButtonDown("Reloading") && Time.time >= nextTimeToFire && scriptC.currentAmmoActual < scriptC.maxAmmoPorCartucho && scriptC.currentAmmoActual > 0 && scriptC.currentBalasRestantesActuales > 0)
		{
			nextTimeToFire = Time.time + 1f / fireRate;
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}

		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && scriptC.currentAmmoActual > 0 && Switch.pausado == false)
		{
			isShooting = true;
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();

		}

		if (Input.GetButtonDown("Fire1") && scriptC.currentAmmoActual <= 0 && scriptC.currentBalasRestantesActuales <= 0 && Switch.pausado == false)
		{
			noAmmo.Stop();
			noAmmo.Play();
		}




	}

	

	IEnumerator Reload()
	{
		if (scriptC.currentAmmoActual <= 0 && scriptC.currentBalasRestantesActuales >= 3)
		{
			yield return new WaitForSeconds(.3f);

			scriptC.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga3 = true;
			animator.Play("PosicionBaja");

			recarga3.Play();
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;

			yield return new WaitForSeconds(.5f);
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;
			yield return new WaitForSeconds(.5f);
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;
			yield return new WaitForSeconds(.18f);
			sonidoRecarga3 = false;
			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
			isReloading = false;
		}

		if (scriptC.currentAmmoActual <= 0 && scriptC.currentBalasRestantesActuales == 2)
		{
			yield return new WaitForSeconds(.3f);

			scriptC.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga = true;
			animator.Play("PosicionBaja");

			recarga.Play();
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;

			yield return new WaitForSeconds(.5f);
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;
			yield return new WaitForSeconds(.18f);
			sonidoRecarga = false;
			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
			isReloading = false;
		}

		if (scriptC.currentAmmoActual <= 0 && scriptC.currentBalasRestantesActuales == 1)
		{
			yield return new WaitForSeconds(.3f);

			scriptC.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga1 = true;
			animator.Play("PosicionBaja");

			recarga1.Play();
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;
			
			yield return new WaitForSeconds(.18f);
			sonidoRecarga1 = false;
			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
			isReloading = false;
		}


		if (scriptC.currentAmmoActual == 1 && scriptC.currentBalasRestantesActuales >= 2)
		{

			scriptC.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga = true;
			animator.Play("PosicionBaja");

			recarga.Play();
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;

			yield return new WaitForSeconds(.5f);
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;

			yield return new WaitForSeconds(.18f);
			sonidoRecarga = false;
			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
			isReloading = false;
		}

		if (scriptC.currentAmmoActual == 1 && scriptC.currentBalasRestantesActuales == 1)
		{

			scriptC.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga1 = true;
			animator.Play("PosicionBaja");

			recarga1.Play();
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;
			

			yield return new WaitForSeconds(.18f);
			sonidoRecarga1 = false;
			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
			isReloading = false;
		}

		if (scriptC.currentAmmoActual == 2 && scriptC.currentBalasRestantesActuales >= 1)
		{

			scriptC.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga1 = true;
			animator.Play("PosicionBaja");

			recarga1.Play();
			scriptC.currentBalasRestantesActuales -= 1;
			scriptC.currentAmmoActual += 1;

			

			yield return new WaitForSeconds(.18f);
			sonidoRecarga1 = false;
			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
			isReloading = false;
		}

	}

	
	

	void Shoot()
    {
        muzzleFlash.Play();
        muzzleLight.Play();

		scriptC.Fire();



		RaycastHitRenderer hit;
		ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);

		if (SuperRaycast.Raycast(ray, out hit, range, ~((1 << 2) | (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12))))
        {
            Debug.Log(hit.gameObject.name);


			VidaEnemiga vidaEnemiga = hit.gameObject.GetComponentInParent<VidaEnemiga>();
			if (vidaEnemiga != null)
			{
				vidaEnemiga.TakeDamage(damage);
			}

			if (hit.gameObject.layer == 9)
			{
				Debug.Log("Si es un enemigo");
			}


			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, .15f);
        }

		disparo.Play();

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			animator.Play("PosicionAlta");
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("DisparoShotgunTriple"))
		{
			animator.Play("PosicionAlta");


		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("LevantarCambioDeArma"))
		{
			animator.Play("PosicionAlta");


		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("LevantarArmaInicial"))
		{
			animator.Play("PosicionAlta");


		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("RegresoDeRecarga"))
		{
			animator.Play("PosicionAlta");


		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta"))
		{
			animator.Play("PosicionAlta");


		}

	}

}



