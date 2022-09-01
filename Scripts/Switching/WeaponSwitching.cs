using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponSwitching : MonoBehaviour {

    public GameObject revolver;
	public GameObject shotgunDoble;
    public GameObject shotgunTriple;
    public GameObject minigun;
    public GameObject crossbow;
	public GameObject chainsaw;
	public GameObject crosstake;
	public GameObject raygun;
    

	public GameObject revolverC;
	public GameObject shotgunDobleC;
	public GameObject shotgunTripleC;
	public GameObject minigunC;
	public GameObject crossbowC;
	public GameObject chainsawC;
	public GameObject crosstakeC;
	public GameObject raygunC;

	public Revolver ShootRevolver;
	public ShotgunDoble ShootShotgunDoble;
	public ShotgunTriple ShootShotgunTriple;
	public Minigun ShootMinigun;
	public Crossbow ShootCrossbow;
	public Chainsaw ShootChainsaw;
	public Crosstake ShootCrosstake;
	public Raygun ShootRaygun;

	public ScriptF ammo;

    public TomarMunicion tomarMunicion;

	public Objetivos Objetivos;

	public GameObject pauseMenuUI;
	public GameObject winMenu;
	public GameObject loseMenu;
	public GameObject manos;

	public Animator animator;

	public bool inToRevolver = false;
	public bool inToShotgunDoble = false;
	public bool inToShotgunTriple = false;
	public bool inToMinigun = false;
	public bool inToCrossbow = false;
	public bool inToChainsaw = false;
	public bool inToCrosstake = false;
	public bool inToRaygun = false;

	public static bool inPause = false;
	public bool pausado = false;

    public GameObject hudRevolver;
    public GameObject hudDoubleShotgun;
    public GameObject hudTripleShotgun;
    public GameObject hudMinigun;
    public GameObject hudCrossbow;
    public GameObject hudChainsaw;
    public GameObject hudCrosstake;
    public GameObject hudRaygun;

	public GameObject hudInGame;

    // Use this for initialization
    void Start() {
	}

	// Update is called once per frame
	void Update() {

		if ((Input.GetKeyDown(KeyCode.Escape)) && (Objetivos.win == false))
		{
			if (inPause)
			{
				OutPause();
			} else
			{
				ToPause();
			}
		}
		
		if (pausado == true)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			return;
		}
			

		if (chainsawC.activeInHierarchy == false)
		{
			ShootChainsaw.motorEnReposo.Stop();
		}



		if (inToRevolver)
			return;
		if (inToShotgunDoble)
			return;
		if (inToShotgunTriple)
			return;
		if (inToMinigun)
			return;
		if (inToCrossbow)
			return;
		if (inToChainsaw)
			return;
		if (inToCrosstake)
			return;
		if (inToRaygun)
			return;

		if (ShootRevolver.isReloading == true)
			return;
		if (ShootShotgunDoble.isReloading == true)
			return;
		if (ShootShotgunTriple.isReloading == true)
			return;
		if (ShootMinigun.isReloading == true)
			return;
		if (ShootCrossbow.isReloading == true)
			return;
		if (ShootChainsaw.isReloading == true)
			return;
		if (ShootCrosstake.isReloading == true)
			return;
		if (ShootRaygun.isReloading == true)
			return;

		if (ShootRevolver.isShooting == true)
			return;
		if (ShootShotgunDoble.isShooting == true)
			return;
		if (ShootShotgunTriple.isShooting == true)
			return;
		if (ShootMinigun.isShooting == true)
			return;
		if (ShootChainsaw.isShooting == true)
			return;
		if (ShootCrossbow.isShooting == true)
			return;
		if (ShootCrosstake.isShooting == true)
			return;
		if (ShootRaygun.isShooting == true)
			return;

		if (inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false && pausado == false) { 

		if (Input.GetButtonDown("Revolver") && revolver.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
				inToRevolver = true;

				StartCoroutine(ToRevolver());
		}

		if ((Input.GetButtonDown("ShotgunDoble") && shotgunDoble.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false) || (tomarMunicion.shotgunDobleTomada == true))
            {
				inToShotgunDoble = true;
                tomarMunicion.shotgunDobleTomada = false;

                StartCoroutine(ToShotgunDoble());
		}

		if ((Input.GetButtonDown("ShotgunTriple") && shotgunTriple.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false) || (tomarMunicion.shotgunTripleTomada == true))
            {
				inToShotgunTriple = true;
                tomarMunicion.shotgunTripleTomada = false;
                StartCoroutine(ToShotgunTriple());
		}

		if ((Input.GetButtonDown("Minigun") && minigun.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false) || (tomarMunicion.minigunTomada == true))
            {
				inToMinigun = true;
                tomarMunicion.minigunTomada = false;
                StartCoroutine(ToMinigun());
		}

		if ((Input.GetButtonDown("Crossbow") && crossbow.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false) || (tomarMunicion.crossbowTomada == true))
            {
				inToCrossbow = true;
                tomarMunicion.crossbowTomada = false;
                StartCoroutine(ToCrossbow());
		}

		if ((Input.GetButtonDown("Chainsaw") && chainsaw.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false) || (tomarMunicion.chainsawTomada == true))

        {
				inToChainsaw = true;
                tomarMunicion.chainsawTomada = false;
                StartCoroutine(ToChainsaw());
		}

		if ((Input.GetButtonDown("Crosstake") && crosstake.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false) || (tomarMunicion.crosstakeTomada == true))
		{
				inToCrosstake = true;
                tomarMunicion.crosstakeTomada = false;

				StartCoroutine(ToCrosstake());
		}



		if ((Input.GetButtonDown("Raygun") && raygun.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false) || (tomarMunicion.raygunTomada == true))
		{
				inToRaygun = true;
                tomarMunicion.raygunTomada = false;
                StartCoroutine(ToRaygun());
		}
		}
	}

	public void OutPause()
	{
		pauseMenuUI.SetActive(false);

		gameObject.GetComponent<FirstPersonController>().enabled = true;
		Cursor.visible = false;

		Time.timeScale = 1f;

		if (ShootRevolver.sonidoRecarga == true)
		{
			ShootRevolver.recarga.Play();
		}

		if (ShootChainsaw.SonidoMotorEnReposo == true)
		{
			ShootChainsaw.motorEnReposo.Play();
		}

		if (ShootChainsaw.sonidoRecarga == true)
		{
			ShootChainsaw.recarga.Play();
		}

		if (ShootShotgunDoble.sonidoRecarga == true)
		{
			ShootShotgunDoble.recarga.Play();
		}

		if (ShootShotgunDoble.sonidoRecarga1 == true)
		{
			ShootShotgunDoble.recarga1.Play();
		}

		if (ShootShotgunTriple.sonidoRecarga == true)
		{
			ShootShotgunTriple.recarga.Play();
		}

		if (ShootShotgunTriple.sonidoRecarga1 == true)
		{
			ShootShotgunTriple.recarga1.Play();
		}

		if (ShootShotgunTriple.sonidoRecarga3 == true)
		{
			ShootShotgunTriple.recarga3.Play();
		}

		if (ShootMinigun.sonidoRecarga == true)
		{
			ShootMinigun.recarga.Play();
		}

		if (ShootCrossbow.sonidoRecarga == true)
		{
			ShootCrossbow.recarga.Play();
		}

		hudInGame.SetActive(true);

		inPause = false;
		pausado = false;
	}

	public void ToPause()
	{
		pauseMenuUI.SetActive(true);

		Time.timeScale = 0f;

		gameObject.GetComponent<FirstPersonController>().enabled = false;
		Cursor.visible = true;

		if(Objetivos.win == true && Objetivos.lose == false)
		{
			pauseMenuUI.SetActive(false);
			winMenu.SetActive(true);
			Cursor.visible = true;
			Cursor.visible = true;
			this.enabled = false;
		}

		if (Objetivos.win == false && Objetivos.lose == true)
		{
			pauseMenuUI.SetActive(false);
			manos.SetActive(false);
			loseMenu.SetActive(true);
			Cursor.visible = true;
			Cursor.visible = true;
			this.enabled = false;
		}

		if (ShootRevolver.sonidoRecarga == true)
		{
			ShootRevolver.recarga.Pause();
		}

		if (ShootChainsaw.SonidoMotorEnReposo == true)
		{
			ShootChainsaw.motorEnReposo.Pause();
		}

		if (ShootChainsaw.sonidoRecarga == true)
		{
			ShootChainsaw.recarga.Pause();
		}

		if (ShootShotgunDoble.sonidoRecarga == true)
		{
			ShootShotgunDoble.recarga.Pause();
		}

		if (ShootShotgunDoble.sonidoRecarga1 == true)
		{
			ShootShotgunDoble.recarga1.Pause();
		}

		if (ShootShotgunTriple.sonidoRecarga == true)
		{
			ShootShotgunTriple.recarga.Pause();
		}

		if (ShootShotgunTriple.sonidoRecarga1 == true)
		{
			ShootShotgunTriple.recarga1.Pause();
		}

		if (ShootShotgunTriple.sonidoRecarga3 == true)
		{
			ShootShotgunTriple.recarga3.Pause();
		}

		if (ShootMinigun.sonidoRecarga == true)
		{
			ShootMinigun.recarga.Pause();
		}

		if (ShootCrossbow.sonidoRecarga == true)
		{
			ShootCrossbow.recarga.Pause();
		}

		hudInGame.SetActive(false);

		inPause = true;
		pausado = true;
	}

	




	IEnumerator ToRevolver()
	{
		
		if (revolverC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;


            shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);
			

			inToRevolver = false;
		}
		
		if (shotgunDobleC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunDoble.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunDobleC.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(true);
            revolverC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRevolver.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);

			Debug.Log("Revolver");
			inToRevolver = false;
		}
		
		if (shotgunTripleC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunTriple.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunTripleC.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(true);
            revolverC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRevolver.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);

			Debug.Log("Revolver");
			inToRevolver = false;
		}

		if (minigunC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootMinigun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			minigunC.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(true);
            revolverC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRevolver.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);

			Debug.Log("Revolver");
			inToRevolver = false;
		}

		if (crossbowC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrossbow.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crossbowC.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(true);
            revolverC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRevolver.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);

			Debug.Log("Revolver");
			inToRevolver = false;
		}

		if (chainsawC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			if (ammo.currentAmmoActual <= 0)
			{
				ShootChainsaw.apagarse.Stop();
			}
			if (ammo.currentAmmoActual > 0)
			{
				ShootChainsaw.apagarse.Play();
			}
			ShootChainsaw.motorEnReposo.Stop();
			
			ShootChainsaw.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			chainsawC.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(true);
            revolverC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRevolver.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);

			Debug.Log("Revolver");
			inToRevolver = false;
		}

		if (crosstakeC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrosstake.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crosstakeC.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(true);
            revolverC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRevolver.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);

			Debug.Log("Revolver");
			inToRevolver = false;
		}

		if (raygunC.activeInHierarchy && inToRevolver == true && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToRevolver = true;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRaygun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			raygunC.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(true);
            revolverC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRevolver.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(true);

			Debug.Log("Revolver");
			inToRevolver = false;
		}

	}

	IEnumerator ToShotgunDoble()
	{

		if (shotgunDobleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			inToShotgunDoble = false;
		}

		if (revolverC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRevolver.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			revolverC.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(true);
            shotgunDobleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunDoble.enabled = true;

			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			Debug.Log("ShotgunDoble");
			inToShotgunDoble = false;
		}

		if (shotgunTripleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunTriple.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunTripleC.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(true);
            shotgunDobleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunDoble.enabled = true;

			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			Debug.Log("ShotgunDoble");
			inToShotgunDoble = false;
		}

		if (minigunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;


			ShootMinigun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			minigunC.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(true);
            shotgunDobleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunDoble.enabled = true;

			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			Debug.Log("ShotgunDoble");
			inToShotgunDoble = false;
		}

		if (crossbowC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrossbow.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crossbowC.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(true);
            shotgunDobleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunDoble.enabled = true;

			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			Debug.Log("ShotgunDoble");
			inToShotgunDoble = false;
		}

		if (chainsawC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			if (ammo.currentAmmoActual <= 0)
			{
				ShootChainsaw.apagarse.Stop();
			}
			if (ammo.currentAmmoActual > 0)
			{
				ShootChainsaw.apagarse.Play();
			}
			ShootChainsaw.motorEnReposo.Stop();
			ShootChainsaw.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			chainsawC.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(true);
            shotgunDobleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunDoble.enabled = true;

			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			Debug.Log("ShotgunDoble");
			inToShotgunDoble = false;
		}

		if (crosstakeC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrosstake.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crosstakeC.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(true);
            shotgunDobleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunDoble.enabled = true;

			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			Debug.Log("ShotgunDoble");
			inToShotgunDoble = false;
		}

		if (raygunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == true && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunDoble = true;
			inToRevolver = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRaygun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			raygunC.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(true);
            shotgunDobleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunDoble.enabled = true;

			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(true);

			Debug.Log("ShotgunDoble");
			inToShotgunDoble = false;
		}
	}

	IEnumerator ToShotgunTriple()
	{

		if (shotgunTripleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunTriple = true;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			inToShotgunTriple = false;
		}

		if (revolverC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunTriple = true;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRevolver.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			revolverC.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(true);
            shotgunTripleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunTriple.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			Debug.Log("ShotgunTriple");
			inToShotgunTriple = false;
		}

		if (shotgunDobleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunTriple = true;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunDoble.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunDobleC.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(true);
            shotgunTripleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunTriple.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			Debug.Log("ShotgunTriple");
			inToShotgunTriple = false;
		}

		if (minigunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunTriple = true;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootMinigun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			minigunC.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(true);
            shotgunTripleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunTriple.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			Debug.Log("ShotgunTriple");
			inToShotgunTriple = false;
		}

		if (crossbowC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunTriple = true;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrossbow.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crossbowC.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(true);
            shotgunTripleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunTriple.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			Debug.Log("ShotgunTriple");
			inToShotgunTriple = false;
		}

        if (chainsawC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
        {
            inToShotgunTriple = true;
            inToShotgunDoble = false;
            inToRevolver = false;
            inToMinigun = false;
            inToCrossbow = false;
            inToChainsaw = false;
            inToCrosstake = false;
            inToRaygun = false;

            if (ammo.currentAmmoActual <= 0)
            {
                ShootChainsaw.apagarse.Stop();
            }
            if (ammo.currentAmmoActual > 0)
            {
                ShootChainsaw.apagarse.Play();
            }
            ShootChainsaw.motorEnReposo.Stop();
            ShootChainsaw.enabled = false;
            animator.Play("BajarArma");
            yield return new WaitForSeconds(.2f);
            chainsawC.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(true);
            shotgunTripleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunTriple.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			Debug.Log("ShotgunTriple");
			inToShotgunTriple = false;
		}

		if (crosstakeC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunTriple = true;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrosstake.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crosstakeC.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(true);
            shotgunTripleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunTriple.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			Debug.Log("ShotgunTriple");
			inToShotgunTriple = false;
		}

		if (raygunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == true && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToShotgunTriple = true;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRaygun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			raygunC.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(true);
            shotgunTripleC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootShotgunTriple.enabled = true;

			revolverC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(true);

			Debug.Log("ShotgunTriple");
			inToShotgunTriple = false;
		}

	}

	IEnumerator ToMinigun()
	{

		if (minigunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);

			inToMinigun = false;
		}

		if (revolverC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRevolver.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			revolverC.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(true);
            minigunC.gameObject.SetActive(true);
			animator.Play("LevantarArmaInicial");
			yield return new WaitForSeconds(.9f);
			ShootMinigun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);

			Debug.Log("Minigun");
			inToMinigun = false;
		}

		if (shotgunDobleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunDoble.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunDobleC.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(true);
            minigunC.gameObject.SetActive(true);
			animator.Play("LevantarArmaInicial");
			yield return new WaitForSeconds(.9f);
			ShootMinigun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);

			Debug.Log("Minigun");
			inToMinigun = false;
		}

		if (shotgunTripleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunTriple.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunTripleC.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(true);
            minigunC.gameObject.SetActive(true);
			animator.Play("LevantarArmaInicial");
			yield return new WaitForSeconds(.9f);
			ShootMinigun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);

			Debug.Log("Minigun");
			inToMinigun = false;
		}

		if (crossbowC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrossbow.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crossbowC.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(true);
            minigunC.gameObject.SetActive(true);
			animator.Play("LevantarArmaInicial");
			yield return new WaitForSeconds(.9f);
			ShootMinigun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);

			Debug.Log("Minigun");
			inToMinigun = false;
		}

		if (chainsawC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			if (ammo.currentAmmoActual <= 0)
			{
				ShootChainsaw.apagarse.Stop();
			}
			if (ammo.currentAmmoActual > 0)
			{
				ShootChainsaw.apagarse.Play();
			}
			ShootChainsaw.motorEnReposo.Stop();
			ShootChainsaw.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			chainsawC.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(true);
            minigunC.gameObject.SetActive(true);
			animator.Play("LevantarArmaInicial");
			yield return new WaitForSeconds(.9f);
			ShootMinigun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);

			Debug.Log("Minigun");
			inToMinigun = false;
		}

		if (crosstakeC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrosstake.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crosstakeC.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(true);
            minigunC.gameObject.SetActive(true);
			animator.Play("LevantarArmaInicial");
			yield return new WaitForSeconds(.9f);
			ShootMinigun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);

			Debug.Log("Minigun");
			inToMinigun = false;
		}

		if (raygunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == true && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToMinigun = true;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRaygun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			raygunC.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(true);
            minigunC.gameObject.SetActive(true);
			animator.Play("LevantarArmaInicial");
			yield return new WaitForSeconds(.9f);
			ShootMinigun.enabled = true;

			revolverC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(true);


			Debug.Log("Minigun");
			inToMinigun = false;
		}

	}

	IEnumerator ToCrossbow()
	{

		if (crossbowC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);

			inToCrossbow = false;
		}

		if (revolverC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRevolver.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			revolverC.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(true);
            crossbowC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrossbow.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);

			Debug.Log("Crossbow");
			inToCrossbow = false;
		}

		if (shotgunDobleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunDoble.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunDobleC.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(true);
            crossbowC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrossbow.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);

			Debug.Log("Crossbow");
			inToCrossbow = false;
		}

		if (shotgunTripleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunTriple.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunTripleC.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(true);
            crossbowC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrossbow.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);

			Debug.Log("Crossbow");
			inToCrossbow = false;
		}

		if (minigunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootMinigun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			minigunC.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(true);
            crossbowC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrossbow.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);

			Debug.Log("Crossbow");
			inToCrossbow = false;
		}

		if (chainsawC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			if (ammo.currentAmmoActual <= 0)
			{
				ShootChainsaw.apagarse.Stop();
			}
			if (ammo.currentAmmoActual > 0)
			{
				ShootChainsaw.apagarse.Play();
			}
			ShootChainsaw.motorEnReposo.Stop();
			ShootChainsaw.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			chainsawC.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(true);
            crossbowC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrossbow.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);

			Debug.Log("Crossbow");
			inToCrossbow = false;
		}

		if (crosstakeC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrosstake.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crosstakeC.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(true);
            crossbowC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrossbow.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);

			Debug.Log("Crossbow");
			inToCrossbow = false;
		}

		if (raygunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == true && inToChainsaw == false && inToCrosstake == false && inToRaygun == false)
		{
			inToCrossbow = true;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToChainsaw = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRaygun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			raygunC.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(true);
            crossbowC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrossbow.enabled = true;

			revolverC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(true);


			Debug.Log("Crossbow");
			inToCrossbow = false;
		}

	}

	IEnumerator ToChainsaw()
	{

		if (chainsawC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			inToChainsaw = false;
		}

		if (revolverC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRevolver.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			revolverC.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(true);
            chainsawC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			ShootChainsaw.arranque.Play();
			yield return new WaitForSeconds(.38f);
			ShootChainsaw.enabled = true;

			ShootChainsaw.chainsawAnimator.Play("PosicionAlta");

			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToChainsaw = false;
		}

		if (shotgunDobleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunDoble.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunDobleC.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(true);
            chainsawC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			ShootChainsaw.arranque.Play();
			yield return new WaitForSeconds(.38f);
			ShootChainsaw.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToChainsaw = false;
		}

		if (shotgunTripleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootShotgunTriple.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunTripleC.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(true);
            chainsawC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			ShootChainsaw.arranque.Play();
			yield return new WaitForSeconds(.38f);
			ShootChainsaw.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToChainsaw = false;
		}

		if (minigunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootMinigun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			minigunC.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(true);
            chainsawC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			ShootChainsaw.arranque.Play();
			yield return new WaitForSeconds(.38f);
			ShootChainsaw.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToChainsaw = false;
		}

		if (crossbowC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrossbow.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crossbowC.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(true);
            chainsawC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			ShootChainsaw.arranque.Play();
			yield return new WaitForSeconds(.38f);
			ShootChainsaw.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToChainsaw = false;
		}

		if (crosstakeC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootCrosstake.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crosstakeC.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(true);
            chainsawC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			ShootChainsaw.arranque.Play();
			yield return new WaitForSeconds(.38f);
			ShootChainsaw.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToChainsaw = false;
		}

		if (raygunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == true && inToCrosstake == false && inToRaygun == false)
		{
			inToChainsaw = true;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToCrosstake = false;
			inToRaygun = false;

			ShootRaygun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			raygunC.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(true);
            chainsawC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			ShootChainsaw.arranque.Play();
			yield return new WaitForSeconds(.38f);
			ShootChainsaw.enabled = true;

			revolverC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToChainsaw = false;
		}

	}

	IEnumerator ToCrosstake()
	{

		if (crosstakeC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			shotgunDobleC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			inToCrosstake = false;
		}

		if (revolverC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			ShootRevolver.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			revolverC.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(true);
            crosstakeC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrosstake.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			Debug.Log("Crosstake");
			inToCrosstake = false;
		}

		if (shotgunDobleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			ShootShotgunDoble.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunDobleC.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(true);
            crosstakeC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrosstake.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			Debug.Log("Crosstake");
			inToCrosstake = false;
		}

		if (shotgunTripleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			ShootShotgunTriple.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunTripleC.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(true);
            crosstakeC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrosstake.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			Debug.Log("Crosstake");
			inToCrosstake = false;
		}

		if (minigunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			ShootMinigun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			minigunC.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(true);
            crosstakeC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrosstake.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			Debug.Log("Chainsaw");
			inToCrosstake = false;
		}

		if (crossbowC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			ShootCrossbow.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crossbowC.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(true);
            crosstakeC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrosstake.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			Debug.Log("Crosstake");
			inToCrosstake = false;
		}

		if (chainsawC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			if (ammo.currentAmmoActual <= 0)
			{
				ShootChainsaw.apagarse.Stop();
			}
			if (ammo.currentAmmoActual > 0)
			{
				ShootChainsaw.apagarse.Play();
			}
			ShootChainsaw.motorEnReposo.Stop();
			ShootChainsaw.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			chainsawC.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(true);
            crosstakeC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrosstake.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			Debug.Log("Crosstake");
			inToCrosstake = false;
		}

		if (raygunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == true && inToRaygun == false)
		{
			inToCrosstake = true;
			inToChainsaw = false;
			inToCrossbow = false;
			inToMinigun = false;
			inToShotgunTriple = false;
			inToShotgunDoble = false;
			inToRevolver = false;
			inToRaygun = false;

			ShootRaygun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			raygunC.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(true);
            crosstakeC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootCrosstake.enabled = true;

			revolverC.gameObject.SetActive(false);
			shotgunDobleC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(true);

			Debug.Log("Crosstake");
			inToCrosstake = false;
		}

	}

	IEnumerator ToRaygun()
	{

		if (raygunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;
			

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);
			
			inToRaygun = false;
		}



		if (revolverC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;

			ShootRevolver.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			revolverC.gameObject.SetActive(false);
            hudRevolver.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(true);
            raygunC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRaygun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);


			inToRaygun = false;
		}

		if (shotgunDobleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;

			ShootShotgunDoble.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunDobleC.gameObject.SetActive(false);
            hudDoubleShotgun.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(true);
            raygunC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRaygun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);

			Debug.Log("Raygun");
			inToRaygun = false;
		}

		if (shotgunTripleC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;

			ShootShotgunTriple.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			shotgunTripleC.gameObject.SetActive(false);
            hudTripleShotgun.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(true);
            raygunC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRaygun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);

			Debug.Log("Raygun");
			inToRaygun = false;
		}

		if (minigunC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;

			ShootMinigun.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			minigunC.gameObject.SetActive(false);
            hudMinigun.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(true);
            raygunC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRaygun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);

			Debug.Log("Raygun");
			inToRaygun = false;
		}

		if (crossbowC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;

			ShootCrossbow.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crossbowC.gameObject.SetActive(false);
            hudCrossbow.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(true);
            raygunC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRaygun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);

			Debug.Log("Raygun");
			inToRaygun = false;
		}

		if (chainsawC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;

			if (ammo.currentAmmoActual <= 0)
			{
				ShootChainsaw.apagarse.Stop();
			}
			if (ammo.currentAmmoActual > 0)
			{
				ShootChainsaw.apagarse.Play();
			}
			ShootChainsaw.motorEnReposo.Stop();

			ShootChainsaw.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			chainsawC.gameObject.SetActive(false);
            hudChainsaw.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(true);
            raygunC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRaygun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);

			Debug.Log("Raygun");
			inToRaygun = false;
		}

		if (crosstakeC.activeInHierarchy && inToRevolver == false && inToShotgunDoble == false && inToShotgunTriple == false && inToMinigun == false && inToCrossbow == false && inToChainsaw == false && inToCrosstake == false && inToRaygun == true)
		{
			inToRaygun = true;
			inToRevolver = false;
			inToShotgunDoble = false;
			inToShotgunTriple = false;
			inToMinigun = false;
			inToCrossbow = false;
			inToChainsaw = false;
			inToCrosstake = false;

			ShootCrosstake.enabled = false;
			animator.Play("BajarArma");
			yield return new WaitForSeconds(.2f);
			crosstakeC.gameObject.SetActive(false);
            hudCrosstake.gameObject.SetActive(false);
            hudRaygun.gameObject.SetActive(true);
            raygunC.gameObject.SetActive(true);
			animator.Play("LevantarCambioDeArma");
			yield return new WaitForSeconds(.38f);
			ShootRaygun.enabled = true;

			shotgunDobleC.gameObject.SetActive(false);
			shotgunTripleC.gameObject.SetActive(false);
			minigunC.gameObject.SetActive(false);
			crossbowC.gameObject.SetActive(false);
			chainsawC.gameObject.SetActive(false);
			crosstakeC.gameObject.SetActive(false);
			revolverC.gameObject.SetActive(false);
			raygunC.gameObject.SetActive(true);

			Debug.Log("Raygun");
			inToRaygun = false;
		}

		

	}



}
