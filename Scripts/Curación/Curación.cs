using System.Collections;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Curación : MonoBehaviour
{

    public int limiteVida;
    public GameObject me;
    public GameObject apagado;
    public SistemaDeVida sistemaDeVida;
    public TempoCuración tempoCuración;

    public float tiempoTranscurrido;
    public float loQueFalta;
    public bool primeraSuma = true;
    public bool siEsPlayer = false;
	public bool subiendo = false;



	public void Update()
	{
		if(limiteVida == 0)
		{
			tempoCuración.enabled = false;
            apagado.gameObject.SetActive(true);
			Destroy(me.gameObject);
		}

		
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			tempoCuración.enabled = false;
			subiendo = false;
			primeraSuma = true;
			siEsPlayer = false;
		}

	}

	public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            siEsPlayer = true;



            if (sistemaDeVida.vida > 100)
            {
                sistemaDeVida.vida = 100;
            }

            if(sistemaDeVida.vida <= 0)
            {
                sistemaDeVida.vida = 0;
            }

            if (sistemaDeVida.vida == 100)
            {
                sistemaDeVida.vida += 0;
            }

			if (limiteVida == 0)
			{
				tempoCuración.enabled = false;
                apagado.gameObject.SetActive(true);
                Destroy(me.gameObject);
			}

			if ((sistemaDeVida.vida > 0) && (sistemaDeVida.vida < 100))
            {

                if (sistemaDeVida.vida == 81)
                {
                    sistemaDeVida.hunter80.SetActive(false);
                    sistemaDeVida.hunterActual = sistemaDeVida.hunter100;
                    sistemaDeVida.hunter100.SetActive(true);
                }
                if (sistemaDeVida.vida == 61)
                {
                    sistemaDeVida.hunter60.SetActive(false);
                    sistemaDeVida.hunterActual = sistemaDeVida.hunter80;
                    sistemaDeVida.hunter80.SetActive(true);
                }
                if (sistemaDeVida.vida == 41)
                {
                    sistemaDeVida.hunter40.SetActive(false);
                    sistemaDeVida.hunterActual = sistemaDeVida.hunter60;
                    sistemaDeVida.hunter60.SetActive(true);
                }
                if (sistemaDeVida.vida == 21)
                {
                    sistemaDeVida.hunter20.SetActive(false);
                    sistemaDeVida.hunterActual = sistemaDeVida.hunter40;
                    sistemaDeVida.hunter40.SetActive(true);
                }





                if ((primeraSuma == false) && (subiendo == false) && (tempoCuración.enabled == false))
                {

                    tempoCuración.enabled = true;
                    
                }

				if ((primeraSuma == true) && (subiendo == false) && (tempoCuración.enabled == false))
				{
					sistemaDeVida.vida += 1;
					limiteVida -= 1;
					primeraSuma = false;
				}

			}
			
        }
        
    }

 

	

}