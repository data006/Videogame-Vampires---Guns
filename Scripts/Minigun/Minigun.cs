using UnityEngine;
using System.Collections;


public class Minigun : MonoBehaviour {

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
	public bool isPreparing = false;
	public bool activacion = false;
	public bool sonidoRecarga = false;

	public AudioSource disparo;
	public AudioSource recarga;
	public AudioSource preparando;
	public AudioSource descanso;
	public AudioSource motor;
	public Animator animator;
	public Animator manosAnimator;

	public ScriptD scriptD;
	public WeaponSwitching Switch;

	public Aparecer2 contar;



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
		if (activacion)
			return;

		

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Preparandose") && isPreparing == true && isShooting == true && activacion == false)
		{
			if (Input.GetButton("Fire1"))
			{
				activacion = true;
				contar.enabled = true;
			}
			else
			{
				animator.Play("PosicionAlta");
				descanso.Stop();
				preparando.Stop();
				activacion = false;
				isPreparing = false;
				isShooting = false;
			}
		}

		if (isPreparing)
			return;

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta") && isPreparing == false && isShooting == true)
		{
			if (Input.GetButton("Fire1") && Switch.pausado == false)
			{
				isPreparing = true;
				animator.Play("Preparandose");
			}
			else
			{
				animator.Play("PosicionAlta");
				descanso.Stop();
				preparando.Stop();
				isPreparing = false;
				activacion = false;
				isShooting = false;
			}
		}

		if (isShooting)
			return;

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta") && isShooting == false)
		{
			manosAnimator.Play("Idle");
		}




		if (Input.GetButton("Fire1"))
		{
			
			if (isShooting == false)
			{
				if (Input.GetButton("Fire1"))
				{

					
					




					
						if (Input.GetButton("Fire1"))
						{
							isShooting = true;
							preparando.Play();





							animator.Play("PosicionAlta");
						}
						else
						{
							isShooting = false;
							isPreparing = false;
							activacion = false;
						}
					

				}
				else
				{
					isShooting = false;
					isPreparing = false;
					activacion = false;
				}

				
			}

			
			



		}
		else
		{
			isShooting = false;
			isPreparing = false;
			activacion = false;
		}
		
		




		if (scriptD.currentAmmoActual <= 0 && scriptD.currentBalasRestantesActuales > 0)
		{
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}



		if (Input.GetButtonDown("Reloading") && Time.time >= nextTimeToFire && scriptD.currentAmmoActual < scriptD.maxAmmoPorCartucho && scriptD.currentAmmoActual > 0 && scriptD.currentBalasRestantesActuales > 0)
		{
			nextTimeToFire = Time.time + 1f / fireRate;
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}




	}

	

	IEnumerator Reload()
	{
		if (scriptD.currentAmmoActual <= 0)
		{
			yield return new WaitForSeconds(.5f);

			scriptD.Reloading();


			manosAnimator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga = true;
			manosAnimator.Play("PosicionBaja");
			recarga.Play();

			yield return new WaitForSeconds(2.5f);
			sonidoRecarga = false;
			scriptD.currentBalasRestantesActuales -= scriptD.bulletsToDeduct;
			scriptD.currentAmmoActual += scriptD.bulletsToDeduct;

			manosAnimator.Play("LevantarArmaInicial");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(0.9f);
			isReloading = false;
		}

		else
		{
			scriptD.Reloading();


			manosAnimator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);
			sonidoRecarga = true;
			manosAnimator.Play("PosicionBaja");
			recarga.Play();

			yield return new WaitForSeconds(2.5f);
			sonidoRecarga = false;
			scriptD.currentBalasRestantesActuales -= scriptD.bulletsToDeduct;
			scriptD.currentAmmoActual += scriptD.bulletsToDeduct;

			manosAnimator.Play("LevantarArmaInicial");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(0.9f);
			isReloading = false;
		}
	}

	
	

	void Shoot()
    {
        muzzleFlash.Play();
        muzzleLight.Play();

		scriptD.Fire();



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

		if (manosAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			manosAnimator.Play("PosicionAlta");
		}

		if (manosAnimator.GetCurrentAnimatorStateInfo(0).IsName("ShootRevolver"))
		{
			manosAnimator.Play("PosicionAlta");


		}
		if (manosAnimator.GetCurrentAnimatorStateInfo(0).IsName("LevantarCambioDeArma"))
		{
			manosAnimator.Play("PosicionAlta");


		}
		if (manosAnimator.GetCurrentAnimatorStateInfo(0).IsName("LevantarArmaInicial"))
		{
			manosAnimator.Play("PosicionAlta");


		}
		if (manosAnimator.GetCurrentAnimatorStateInfo(0).IsName("RegresoDeRecarga"))
		{
			manosAnimator.Play("PosicionAlta");


		}
		if (manosAnimator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta"))
		{
			manosAnimator.Play("PosicionAlta");


		}

	}

}



