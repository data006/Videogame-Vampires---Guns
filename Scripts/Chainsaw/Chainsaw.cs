using UnityEngine;
using System.Collections;


public class Chainsaw : MonoBehaviour {

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
	public bool jalar = false;
	public bool SonidoMotorEnReposo = false;
	public bool sonidoRecarga = false;

	public AudioSource disparo;
	public AudioSource recarga;
	public AudioSource preparando;
	public AudioSource descanso;
	public AudioSource motor;
	public AudioSource motorEnReposo;
	public AudioSource arranque;
	public AudioSource gatillo;
	public AudioSource ataqueAParo;
	public AudioSource apagarse;
	public Animator animator;
	public Animator manosAnimator;
	public Animator chainsawAnimator;

	public ScriptF scriptF;
	public WeaponSwitching Switch;

	public Aparecer3 contar;

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
		if (activacion)
			return;


		if (chainsawAnimator.GetCurrentAnimatorStateInfo(0).IsName("Preparandose") && isPreparing == true && isShooting == true && activacion == false && Switch.pausado == false)
		{
			if (Input.GetButton("Fire1"))
			{
				activacion = true;
				contar.enabled = true;
			}
			else
			{
				chainsawAnimator.Play("PosicionAlta");
				ataqueAParo.Stop();
				preparando.Stop();
				activacion = false;
				isPreparing = false;
				isShooting = false;
			}
		}

		if (isPreparing)
			return;

		if (chainsawAnimator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta") && isPreparing == false && isShooting == true)
		{
			if (Input.GetButton("Fire1") && Switch.pausado == false)
			{
				isPreparing = true;
				chainsawAnimator.Play("Preparandose");
			}
			else
			{
				chainsawAnimator.Play("PosicionAlta");
				ataqueAParo.Stop();
				preparando.Stop();
				isPreparing = false;
				activacion = false;
				isShooting = false;
			}
		}

		if (isShooting)
			return;



		if (chainsawAnimator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta") && isShooting == false && Switch.pausado == false)
		{
			if (scriptF.currentAmmoActual >= 1)
			{
				motorEnReposo.Play();
				SonidoMotorEnReposo = true;
				chainsawAnimator.Play("IdleChainsaw");


			}

		}

		if (chainsawAnimator.GetCurrentAnimatorStateInfo(0).IsName("PosicionAlta") && scriptF.currentAmmoActual <= 0)
		{
			motorEnReposo.Stop();
			SonidoMotorEnReposo = false;
			chainsawAnimator.Play("PosicionAlta");
		}




		if (Input.GetButton("Fire1"))
		{

			if (isShooting == false)
			{
				if (Input.GetButton("Fire1"))
				{



					if (scriptF.currentAmmoActual >= 1)
					{
						if (Input.GetButton("Fire1") && chainsawAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleChainsaw"))
						{
							isShooting = true;
							preparando.Play();
							motorEnReposo.Stop();
							SonidoMotorEnReposo = false;




							chainsawAnimator.Play("PosicionAlta");
						}
						else
						{
							isShooting = false;
							isPreparing = false;
							activacion = false;
						}
					}

					if (scriptF.currentAmmoActual <= 0 && scriptF.currentBalasRestantesActuales <= 0)
					{
						gatillo.Stop();
						gatillo.Play();
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



		if (scriptF.currentAmmoActual <= 0 && scriptF.currentBalasRestantesActuales > 0)
		{
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}



		

	




	}

	

	IEnumerator Reload()
	{
		
			yield return new WaitForSeconds(.3f);
		chainsawAnimator.enabled = false;
		contar.animatorCadena.enabled = false;
		scriptF.Reloading();


			manosAnimator.Play("BajarArma 0");
		
			yield return new WaitForSeconds(.3f);

			manosAnimator.Play("PosicionBaja");
			sonidoRecarga = true;
			recarga.Play();

			yield return new WaitForSeconds(.8f);
			scriptF.currentBalasRestantesActuales -= 1;
			scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		yield return new WaitForSeconds(0.05f);
		scriptF.currentBalasRestantesActuales -= 1;
		scriptF.currentAmmoActual += 1;

		sonidoRecarga = false;
		arranque.Play();
		manosAnimator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.5f);
		chainsawAnimator.enabled = true;
		contar.animatorCadena.enabled = true;
		isReloading = false;
		

		
	}

	
	

	void Shoot()
    {
        muzzleFlash.Play();
        muzzleLight.Play();

		scriptF.Fire();



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
    }

}



