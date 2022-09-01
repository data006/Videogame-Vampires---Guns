using UnityEngine;
using System.Collections;


public class Crosstake : MonoBehaviour {

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

	public AudioSource disparo;
	public Animator animator;

	public ScriptG scriptG;
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
			animator.Play("AtaqueCrosstake");
			StartCoroutine(scriptG.Disparando());
		}

		if (isShooting)
			return;

		if (scriptG.currentAmmoActual <= 0 && scriptG.currentBalasRestantesActuales > 0)
		{
			isReloading = true;
			StartCoroutine(Reload());
			return;
		}



		

		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && scriptG.currentAmmoActual > 0 && Switch.pausado == false)
		{
			isShooting = true;
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();

		}




	}

	

	IEnumerator Reload()
	{
		if (scriptG.currentAmmoActual <= 0)
		{
			yield return new WaitForSeconds(.3f);

			scriptG.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);

			animator.Play("PosicionBaja");

			yield return new WaitForSeconds(1.5f);
			scriptG.currentBalasRestantesActuales -= scriptG.bulletsToDeduct;
			scriptG.currentAmmoActual += scriptG.bulletsToDeduct;

			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.6005f);
			isReloading = false;
		}

		else
		{
			scriptG.Reloading();


			animator.Play("BajarArma 0");
			yield return new WaitForSeconds(.3f);

			animator.Play("PosicionBaja");

			yield return new WaitForSeconds(1.5f);
			scriptG.currentBalasRestantesActuales -= scriptG.bulletsToDeduct;
			scriptG.currentAmmoActual += scriptG.bulletsToDeduct;

			animator.Play("RegresoDeRecarga");

			Debug.Log("Subiendo Arma");
			yield return new WaitForSeconds(.6005f);
			isReloading = false;
		}
	}

	
	

	void Shoot()
    {
        

		scriptG.Fire();



		

		disparo.Play();

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			animator.Play("PosicionAlta");
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("AtaqueCrosstake"))
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



