using UnityEngine;
using System.Collections;


public class Crossbow : MonoBehaviour {

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
    public bool isReloading = false;
	public bool isShooting = false;
	public bool sonidoRecarga = false;

	public AudioSource disparo;
	public AudioSource recarga;
	public AudioSource noAmmo;
	public Animator animator;

	public ScriptE scriptE;
	public WeaponSwitching Switch;



	public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleLight;
    public GameObject impactEffect;

	public GameObject crossbowConFlecha;
	public GameObject crossbowSinFlecha;

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
			animator.Play("DisparoCrossbow");
			StartCoroutine(scriptE.Disparando());
		}

		if (isShooting)
			return;

		if (scriptE.currentAmmoActual <= 0 && scriptE.currentBalasRestantesActuales > 0)
		{
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}



		if (Input.GetButtonDown("Reloading") && Time.time >= nextTimeToFire && scriptE.currentAmmoActual < scriptE.maxAmmoPorCartucho && scriptE.currentAmmoActual > 0 && scriptE.currentBalasRestantesActuales > 0)
		{
			nextTimeToFire = Time.time + 1f / fireRate;
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}

		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && scriptE.currentAmmoActual > 0 && Switch.pausado == false)
		{
			isShooting = true;
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();

		}

		if (Input.GetButtonDown("Fire1") && scriptE.currentAmmoActual <= 0 && scriptE.currentBalasRestantesActuales <= 0 && Switch.pausado == false)
		{
			noAmmo.Stop();
			noAmmo.Play();
		}




	}



	IEnumerator Reload()
	{
		if (scriptE.currentAmmoActual <= 0)
		{
			yield return new WaitForSeconds(.3f);

			scriptE.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga = true;
			animator.Play("PosicionBaja");
			recarga.Play();

			yield return new WaitForSeconds(.55f);
			
			crossbowConFlecha.gameObject.SetActive(true);
			crossbowSinFlecha.gameObject.SetActive(false);
			scriptE.currentBalasRestantesActuales -= scriptE.bulletsToDeduct;
			scriptE.currentAmmoActual += scriptE.bulletsToDeduct;

			animator.Play("RegresoDeRecarga");

			yield return new WaitForSeconds(.5f);
			sonidoRecarga = false;

			Debug.Log("Subiendo Arma");
			isReloading = false;
		}

		else
		{
			scriptE.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga = true;
			animator.Play("PosicionBaja");
			recarga.Play();

			yield return new WaitForSeconds(.55f);

			crossbowConFlecha.gameObject.SetActive(true);
			crossbowSinFlecha.gameObject.SetActive(false);
			scriptE.currentBalasRestantesActuales -= scriptE.bulletsToDeduct;
			scriptE.currentAmmoActual += scriptE.bulletsToDeduct;

			animator.Play("RegresoDeRecarga");

			yield return new WaitForSeconds(.85f);
			sonidoRecarga = false;

			Debug.Log("Subiendo Arma");
			isReloading = false;
		}
	}

	
	

	void Shoot()
    {
        muzzleFlash.Play();
        muzzleLight.Play();

		scriptE.Fire();



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
			
			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(fpsCam.transform.forward));
            Destroy(impactGO, 5f);
        }

		disparo.Play();

		crossbowSinFlecha.gameObject.SetActive(true);
		crossbowConFlecha.gameObject.SetActive(false);
		

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			animator.Play("PosicionAlta");
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("DisparoCrossbow"))
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



