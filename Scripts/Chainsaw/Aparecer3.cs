using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparecer3 : MonoBehaviour {

	Ray ray;

	public float limit_time;
	public float conten_time;
	public GameObject instan;
	public bool animacionHecha = false;
	public bool sinBalas = false;

	public AudioSource bocina;
	public Animator animator;
	public Animator animatorCadena;

	public Chainsaw arma;
	public Aparecer3 contar;
	public ScriptF scriptF;
	public WeaponSwitching Switch;

	// Use this for initialization
	void Start()
	{
		conten_time = 0;
	}
	//SOY HACKER-MAN XD
	// Update is called once per frame
	void Update()
	{

		if (Input.GetButton("Fire1") && Switch.pausado == false)
		{

			conten_time += Time.deltaTime;

			if (Input.GetButton("Fire1"))
			{
				if (scriptF.currentAmmoActual >= 1)
				{
					if (conten_time >= limit_time && animacionHecha == false)
					{
						animacionHecha = true;

						arma.disparo.Play();



						arma.chainsawAnimator.Play("Atacando");
						animatorCadena.Play("Atacando");
					}

					if (Time.time >= arma.nextTimeToFire && animacionHecha == true)
					{
						arma.nextTimeToFire = Time.time + 1f / arma.fireRate;
						Shoot();
					}
				}
				else
				{
					
						arma.ataqueAParo.Play();
						arma.disparo.Stop();
						animatorCadena.Play("Idle");
						arma.chainsawAnimator.Play("AtaqueAParo");
						conten_time = 0;
						animacionHecha = false;
						sinBalas = false;
						arma.activacion = false;
						arma.isPreparing = false;
						contar.enabled = false;
						arma.isShooting = false;
					
						

					

				}

			}
			else
			{
				if (animacionHecha == true)
				{
					arma.ataqueAParo.Play();
					arma.disparo.Stop();
					animatorCadena.Play("Idle");
					arma.chainsawAnimator.Play("AtaqueAParo");
					conten_time = 0;
					animacionHecha = false;
					sinBalas = false;
					arma.activacion = false;
					arma.isPreparing = false;
					contar.enabled = false;
					arma.isShooting = false;
				}
				else
				{
					arma.preparando.Stop();
					arma.disparo.Stop();
					arma.chainsawAnimator.Play("PosicionAlta");
					animatorCadena.Play("Idle");
					conten_time = 0;
					animacionHecha = false;
					sinBalas = false;
					arma.activacion = false;
					arma.isPreparing = false;
					contar.enabled = false;
				}

			}








		}
		else
		{
			if (animacionHecha == true)
			{
				arma.ataqueAParo.Play();
				arma.disparo.Stop();
				animatorCadena.Play("Idle");
				arma.chainsawAnimator.Play("AtaqueAParo");
				conten_time = 0;
				animacionHecha = false;
				sinBalas = false;
				arma.activacion = false;
				arma.isPreparing = false;
				contar.enabled = false;
				arma.isShooting = false;
			}
			else
			{
				arma.preparando.Stop();
				arma.disparo.Stop();
				arma.chainsawAnimator.Play("PosicionAlta");
				animatorCadena.Play("Idle");
				conten_time = 0;
				animacionHecha = false;
				sinBalas = false;
				arma.activacion = false;
				arma.isPreparing = false;
				contar.enabled = false;
				arma.isShooting = false;
			}

		}
	}

	void Shoot()
	{
		arma.muzzleFlash.Play();
		arma.muzzleLight.Play();

		scriptF.Fire();



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
	}
}
