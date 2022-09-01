using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarMunicion : MonoBehaviour {

	public ScriptB scriptB;
	public ScriptA scriptA;
	public ScriptC scriptC;
	public ScriptD scriptD;
	public ScriptE scriptE;
	public ScriptF scriptF;
	public ScriptG scriptG;
	public GameObject revolver;
	public GameObject shotgunDoble;
	public GameObject shotgunTriple;
	public GameObject minigun;
	public GameObject crossbow;
	public GameObject chainsaw;
	public GameObject crosstake;
    public GameObject raygun;

    public WeaponSwitching weaponSwitching;

    
    public bool shotgunDobleTomada = false;
    public bool shotgunTripleTomada = false;
    public bool minigunTomada = false;
    public bool crossbowTomada = false;
    public bool chainsawTomada = false;
    public bool crosstakeTomada = false;
    public bool raygunTomada = false;

	public float tiempoTranscurrido = 0;
	public float salidaLetrero;
	public bool mostrarLetrero = false;
	public GameObject letreroShotgunDoble;
	public GameObject letreroShotgunTriple;
	public GameObject letreroMinigun;
	public GameObject letreroCrossbow;
	public GameObject letreroChainsaw;
	public GameObject letreroCrosstake;
	public GameObject letreroRaygun;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(mostrarLetrero == true)
		{
			tiempoTranscurrido += Time.deltaTime;
			if (tiempoTranscurrido >= salidaLetrero)
			{
				letreroShotgunDoble.SetActive(false);
				letreroShotgunTriple.SetActive(false);
				letreroMinigun.SetActive(false);
				letreroCrossbow.SetActive(false);
				letreroChainsaw.SetActive(false);
				letreroCrosstake.SetActive(false);
				letreroRaygun.SetActive(false);
				mostrarLetrero = false;
				tiempoTranscurrido = 0;
			}
		}
		
	}


	void OnTriggerEnter(Collider obj)
	{

        if (obj.tag == "ShotgunDobleArma")
        {
            if (shotgunDoble.activeInHierarchy == false)
            {
                Destroy(obj.gameObject);
				shotgunDobleTomada = true;
				shotgunDoble.SetActive(true);

				
				letreroShotgunDoble.SetActive(true);
				tiempoTranscurrido = 0;
				mostrarLetrero = true;
					
                
            }
            else
            {
                Destroy(obj.gameObject);
            }


        }

        if (obj.tag == "ShotgunTripleArma")
        {
            if (shotgunTriple.activeInHierarchy == false)
            {
                Destroy(obj.gameObject);
                shotgunTriple.SetActive(true);
                shotgunTripleTomada = true;

				letreroShotgunTriple.SetActive(true);
				tiempoTranscurrido = 0;
				mostrarLetrero = true;
			}
            else
            {
                Destroy(obj.gameObject);
            }


        }

        if (obj.tag == "MinigunArma")
        {
            if (minigun.activeInHierarchy == false)
            {
                Destroy(obj.gameObject);
                minigun.SetActive(true);
                minigunTomada = true;

				letreroMinigun.SetActive(true);
				tiempoTranscurrido = 0;
				mostrarLetrero = true;
			}
            else
            {
                Destroy(obj.gameObject);
            }


        }

        if (obj.tag == "CrossbowArma")
        {
            if (crossbow.activeInHierarchy == false)
            {
                Destroy(obj.gameObject);
                crossbow.SetActive(true);
                crossbowTomada = true;

				letreroCrossbow.SetActive(true);
				tiempoTranscurrido = 0;
				mostrarLetrero = true;
			}
            else
            {
                Destroy(obj.gameObject);
            }


        }

        if (obj.tag == "ChainsawArma")
        {
            if (chainsaw.activeInHierarchy == false)
            {
                Destroy(obj.gameObject);
                chainsaw.SetActive(true);
                chainsawTomada = true;

				letreroChainsaw.SetActive(true);
				tiempoTranscurrido = 0;
				mostrarLetrero = true;
			}
            else
            {
                Destroy(obj.gameObject);
            }


        }



        if (obj.tag == "CrosstakeArma")
        {
            if (crosstake.activeInHierarchy == false)
            {
                Destroy(obj.gameObject);
                crosstake.SetActive(true);
                crosstakeTomada = true;

				letreroCrosstake.SetActive(true);
				tiempoTranscurrido = 0;
				mostrarLetrero = true;
			}
            else
            {
                Destroy(obj.gameObject);
            }
            
            
        }

        if (obj.tag == "RaygunArma")
        {
            if (raygun.activeInHierarchy == false)
            {
                Destroy(obj.gameObject);
                raygun.SetActive(true);
                raygunTomada = true;

				letreroRaygun.SetActive(true);
				tiempoTranscurrido = 0;
				mostrarLetrero = true;
			}
            else
            {
                Destroy(obj.gameObject);
            }


        }




        if (obj.tag == "ShotgunDobleChica" && shotgunDoble.activeInHierarchy)
		{

				if (scriptA.currentBalasRestantesActuales <= 44)
				{
					Destroy(obj.gameObject);
					scriptA.currentBalasRestantesActuales += 6;
					return;
				}


				if (scriptA.currentBalasRestantesActuales == 45)
				{
					Destroy(obj.gameObject);
					scriptA.currentBalasRestantesActuales += 5;
					return;
				}


				if (scriptA.currentBalasRestantesActuales == 46)
				{
					Destroy(obj.gameObject);
					scriptA.currentBalasRestantesActuales += 4;
					return;
				}


				if (scriptA.currentBalasRestantesActuales == 47)
				{
					Destroy(obj.gameObject);
					scriptA.currentBalasRestantesActuales += 3;
					return;
				}

				if (scriptA.currentBalasRestantesActuales == 48)
				{
					Destroy(obj.gameObject);
					scriptA.currentBalasRestantesActuales += 2;
					return;
				}

				if (scriptA.currentBalasRestantesActuales == 49)
				{
					Destroy(obj.gameObject);
					scriptA.currentBalasRestantesActuales += 1;
					return;
				}


				if (scriptA.currentBalasRestantesActuales >= 50)
				{
					return;
				}


			
				


			
		}








		if (obj.tag == "ShotgunDobleMediana" && shotgunDoble.activeInHierarchy)
		{



			if (scriptA.currentBalasRestantesActuales <= 40)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 10;
				return;
			}


			if (scriptA.currentBalasRestantesActuales == 41)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 9;
				return;
			}


			if (scriptA.currentBalasRestantesActuales == 42)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 8;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 43)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 7;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 44)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 6;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 45)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 5;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 46)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 4;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 47)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 48)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 49)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 1;
				return;
			}

			if (scriptA.currentBalasRestantesActuales >= 50)
			{
				return;
			}







		}










		if (obj.tag == "ShotgunDobleGrande" && shotgunDoble.activeInHierarchy)
		{



			

			if (scriptA.currentBalasRestantesActuales <= 34)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 16;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 35)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 15;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 36)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 14;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 37)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 13;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 38)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 12;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 39)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 11;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 40)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 10;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 41)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 9;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 42)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 8;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 43)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 7;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 44)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 6;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 45)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 5;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 46)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 4;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 47)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 48)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptA.currentBalasRestantesActuales == 49)
			{
				Destroy(obj.gameObject);
				scriptA.currentBalasRestantesActuales += 1;
				return;
			}

			if (scriptA.currentBalasRestantesActuales >= 50)
			{
				return;
			}







		}

















		if (obj.tag == "ShotgunTripleChica" && shotgunTriple.activeInHierarchy)
		{

			if (scriptC.currentBalasRestantesActuales <= 34)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 6;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 35)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 5;
				return;
			}


			if (scriptC.currentBalasRestantesActuales == 36)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 4;
				return;
			}


			if (scriptC.currentBalasRestantesActuales == 37)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 38)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 39)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 1;
				return;
			}

			if (scriptC.currentBalasRestantesActuales >= 40)
			{
				return;
			}







		}




		if (obj.tag == "ShotgunTripleMediana" && shotgunTriple.activeInHierarchy)
		{
			if (scriptC.currentBalasRestantesActuales <= 28)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 12;
				return;
			}
			if (scriptC.currentBalasRestantesActuales == 29)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 11;
				return;
			}
			if (scriptC.currentBalasRestantesActuales == 30)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 10;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 31)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 9;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 32)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 8;
				return;
			}


			if (scriptC.currentBalasRestantesActuales == 33)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 7;
				return;
			}


			if (scriptC.currentBalasRestantesActuales == 34)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 6;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 35)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 5;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 36)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 4;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 37)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 38)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 39)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 1;
				return;
			}

			if (scriptC.currentBalasRestantesActuales >= 40)
			{
				return;
			}







		}




		if (obj.tag == "ShotgunTripleGrande" && shotgunTriple.activeInHierarchy)
		{

			if (scriptC.currentBalasRestantesActuales <= 22)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 18;
				return;
			}
			if (scriptC.currentBalasRestantesActuales == 23)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 17;
				return;
			}
			if (scriptC.currentBalasRestantesActuales == 24)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 16;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 25)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 15;
				return;
			}


			if (scriptC.currentBalasRestantesActuales == 26)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 14;
				return;
			}


			if (scriptC.currentBalasRestantesActuales == 27)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 13;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 28)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 12;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 29)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 11;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 30)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 10;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 31)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 9;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 32)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 8;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 33)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 7;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 34)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 6;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 35)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 5;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 36)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 4;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 37)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 38)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptC.currentBalasRestantesActuales == 39)
			{
				Destroy(obj.gameObject);
				scriptC.currentBalasRestantesActuales += 1;
				return;
			}

			if (scriptC.currentBalasRestantesActuales >= 40)
			{
				return;
			}







		}










		if (obj.tag == "MinigunMunición" && minigun.activeInHierarchy)
		{



			if (scriptD.currentBalasRestantesActuales <= 200)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 100;
				return;
			}


			if (scriptD.currentBalasRestantesActuales == 201)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 99;
				return;
			}


			if (scriptD.currentBalasRestantesActuales == 202)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 98;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 203)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 97;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 204)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 96;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 205)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 95;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 206)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 94;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 207)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 93;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 208)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 92;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 209)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 91;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 210)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 90;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 211)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 89;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 212)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 88;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 213)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 87;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 214)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 86;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 215)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 85;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 216)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 84;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 217)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 83;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 218)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 82;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 219)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 81;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 220)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 80;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 221)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 79;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 222)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 78;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 223)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 77;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 224)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 76;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 225)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 75;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 226)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 74;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 227)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 73;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 228)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 72;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 229)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 71;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 230)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 70;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 231)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 69;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 232)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 68;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 233)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 67;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 234)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 66;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 235)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 65;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 236)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 64;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 237)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 63;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 238)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 62;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 239)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 61;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 240)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 60;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 241)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 59;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 242)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 58;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 243)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 57;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 244)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 56;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 245)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 55;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 246)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 54;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 247)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 53;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 248)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 52;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 249)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 51;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 250)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 50;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 251)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 49;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 252)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 48;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 253)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 47;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 254)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 46;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 255)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 45;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 256)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 44;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 257)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 43;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 258)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 42;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 259)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 41;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 260)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 40;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 261)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 39;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 262)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 38;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 263)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 37;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 264)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 36;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 265)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 35;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 266)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 34;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 267)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 33;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 268)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 32;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 269)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 31;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 270)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 30;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 271)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 29;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 272)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 28;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 273)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 27;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 274)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 26;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 275)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 25;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 276)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 24;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 277)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 23;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 278)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 22;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 279)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 21;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 280)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 20;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 281)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 19;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 282)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 18;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 283)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 17;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 284)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 16;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 285)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 15;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 286)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 14;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 287)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 13;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 288)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 12;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 289)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 11;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 290)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 10;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 291)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 9;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 292)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 8;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 293)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 7;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 294)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 6;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 295)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 5;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 296)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 4;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 297)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 298)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptD.currentBalasRestantesActuales == 299)
			{
				Destroy(obj.gameObject);
				scriptD.currentBalasRestantesActuales += 1;
				return;
			}

			if (scriptD.currentBalasRestantesActuales >= 300)
			{
				return;
			}







		}






		if (obj.tag == "CrossbowChica" && crossbow.activeInHierarchy)
		{



			if (scriptE.currentBalasRestantesActuales <= 15)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 5;
				return;
			}


			if (scriptE.currentBalasRestantesActuales == 16)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 4;
				return;
			}


			if (scriptE.currentBalasRestantesActuales == 17)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 18)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 19)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 1;
				return;
			}


			if (scriptE.currentBalasRestantesActuales >= 20)
			{
				return;
			}







		}









		if (obj.tag == "CrossbowGrande" && crossbow.activeInHierarchy)
		{



			if (scriptE.currentBalasRestantesActuales <= 10)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 10;
				return;
			}


			if (scriptE.currentBalasRestantesActuales == 11)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 9;
				return;
			}


			if (scriptE.currentBalasRestantesActuales == 12)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 8;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 13)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 7;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 14)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 6;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 15)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 5;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 16)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 4;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 17)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 3;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 18)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 2;
				return;
			}

			if (scriptE.currentBalasRestantesActuales == 19)
			{
				Destroy(obj.gameObject);
				scriptE.currentBalasRestantesActuales += 1;
				return;
			}


			if (scriptE.currentBalasRestantesActuales >= 20)
			{
				return;
			}







		}







		if (obj.tag == "ChainsawMunición" && chainsaw.activeInHierarchy)
		{

			if (scriptF.currentBalasRestantesActuales == 0)
			{
				Destroy(obj.gameObject);
				scriptF.currentBalasRestantesActuales += 100;
				return;
			}


			if (scriptF.currentBalasRestantesActuales == 100)
			{
				Destroy(obj.gameObject);
				scriptF.currentBalasRestantesActuales += 100;
				return;
			}
			

			if (scriptF.currentBalasRestantesActuales >= 200)
			{
				return;
			}







		}














	}

}
