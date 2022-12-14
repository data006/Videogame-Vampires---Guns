using UnityEngine;
using System.Collections;


public class Raygun : MonoBehaviour {
    
    Ray ray;


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;


    public int maxAmmoPorCartucho = 999999999;
    public int currentAmmoActual;
	public int maxBalasRestantes = 999999999;
	public int currentBalasRestantesActuales;
	public int diferenciaDeBalasEntreElMaximoYElReloading;
	public float armaRecargando = 2f;
	public float subiendoArma = 2f;
	public float bajandoArma = .1f;
	public float reloadingTime = 2f;
	public float reloadTime = 5f;
    public bool isReloading = false;
	public bool isShooting = false;
	public bool sonidoRecarga = false;

	public AudioSource disparo;

	public Animator animator;
	public Animation anim;

	public ScriptH scriptB;
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
	void Update()
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

		
		if (isShooting)
			return;



/*		if (scriptB.currentAmmoActual <= 0 && scriptB.currentBalasRestantesActuales > 0)
		{
			isReloading = true;
			StartCoroutine(Reload());
			return;
		} */



		

		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && scriptB.currentAmmoActual > 0 && isShooting == false && Switch.pausado == false)
		{
			isShooting = true;
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();



		}

		
		




	}

	

/*	IEnumerator Reload()
	{
		
		if(scriptB.currentAmmoActual <= 0)
		{
			yield return new WaitForSeconds(.3f);

			scriptB.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);

			sonidoRecarga = true;
			animator.Play("PosicionBaja");
			recarga.Play();
			

			yield return new WaitForSeconds(1.5f);
			sonidoRecarga = false;
			scriptB.currentBalasRestantesActuales -= scriptB.bulletsToDeduct;
			scriptB.currentAmmoActual += scriptB.bulletsToDeduct;

			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
			isReloading = false;
		}
		else { 
		scriptB.Reloading();

		
		animator.Play("BajarArma 0");
		yield return new WaitForSeconds(.3f);

			sonidoRecarga = true;

			animator.Play("PosicionBaja");
		recarga.Play();

		yield return new WaitForSeconds(1.5f);

			sonidoRecarga = false;

			scriptB.currentBalasRestantesActuales -= scriptB.bulletsToDeduct;
		scriptB.currentAmmoActual += scriptB.bulletsToDeduct;

		animator.Play("RegresoDeRecarga");
		
		Debug.Log("Subiendo Arma");
		yield return new WaitForSeconds(.5f);
			isReloading = false;
		}

		
	} */




	void Shoot()
	{
        muzzleFlash.Play();
        muzzleLight.Play();


        scriptB.Fire();
        


        RaycastHitRenderer hitInfo;
        ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);

        if (SuperRaycast.Raycast(ray, out hitInfo, range, ~((1 << 2) | (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12))))
		{
			Debug.Log(hitInfo.gameObject.name);

            if (hitInfo.gameObject.name == "Vampire (6)")
			{
				VidaEnemiga vidaEnemiga = hitInfo.gameObject.GetComponentInParent<VidaEnemiga>();
				if (vidaEnemiga != null)
				{
					vidaEnemiga.TakeDamage(damage);
				}
			}
			else
			{
				VidaEnemiga vidaEnemiga = hitInfo.gameObject.GetComponentInParent<VidaEnemiga>();
				if (vidaEnemiga != null)
				{
					vidaEnemiga.TakeDamage(9999999);
				}
			}

			

			if (hitInfo.gameObject.layer == 9)
			{
				Debug.Log("Si es un enemigo");
			}


			GameObject impactGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
			Destroy(impactGO, .15f);
		}

		disparo.Play();


		StartCoroutine(scriptB.Disparando());

    }

}



