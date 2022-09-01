using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class SistemaDeVida : MonoBehaviour {

    public int vida;
    public TempoAtaque tempoAtaque;
    public EstadoPersecucion estadoPersecucion;

	public Objetivos objetivos;

	public TextMeshProUGUI textMeshPro;

    public AudioSource[] sonidosDeDaños;

    public bool hudDaño = false;
    public float tiempoTranscurrido;
    public float tiempoLimite;

    public GameObject panelNegro;
    public GameObject hunterActual;
    public GameObject hunter100;
    public GameObject hunter80;
    public GameObject hunter60;
    public GameObject hunter40;
    public GameObject hunter20;
    public GameObject hunter0;
    public GameObject panelRojo;

    void Update () {

		textMeshPro.text = vida.ToString()+"%";

        if(vida >= 80 && vida <= 100)
        {
            hunterActual = hunter100;
        }
        if(vida >= 60 && vida <= 80)
        {
            hunter100.SetActive(false);
            hunter80.SetActive(true);
            hunterActual = hunter80;
        }
        if (vida >= 40 && vida <= 60)
        {
            hunter80.SetActive(false);
            hunter60.SetActive(true);
            hunterActual = hunter60;
        }
        if (vida >= 20 && vida <= 40)
        {
            hunter60.SetActive(false);
            hunter40.SetActive(true);
            hunterActual = hunter40;
        }
        if (vida > 0 && vida <= 20)
        {
            hunter40.SetActive(false);
            hunter20.SetActive(true);
            hunterActual = hunter20;
        }
		if (vida <= 0)
		{
			vida = 0;
			hunterActual = hunter0;

			objetivos.lose = true;
			objetivos.win = false;

			
		}

        if (hudDaño == true)
        {
            tiempoTranscurrido += Time.deltaTime;

            if (vida > 0)
            {
                panelNegro.gameObject.SetActive(false);
                hunterActual.gameObject.SetActive(false);
                panelRojo.gameObject.SetActive(true);

                if (tiempoTranscurrido >= tiempoLimite)
                {
                    panelNegro.gameObject.SetActive(true);
                    hunterActual.gameObject.SetActive(true);
                    panelRojo.gameObject.SetActive(false);
                    hudDaño = false;
                    tiempoTranscurrido = 0f;
                }
            }
            else
            {
                hunterActual = hunter0;
                hunter100.SetActive(false);
                hunter80.SetActive(false);
                hunter60.SetActive(false);
                hunter40.SetActive(false);
                hunter20.SetActive(false);
                hunterActual.gameObject.SetActive(true);
            }

        }
            
	}

    public void DañoAHunter ()
    {
        int n = Random.Range(1, sonidosDeDaños.Length);
        

        if (sonidosDeDaños[0].isPlaying == false && sonidosDeDaños[1].isPlaying == false && sonidosDeDaños[2].isPlaying == false && sonidosDeDaños[3].isPlaying == false && sonidosDeDaños[4].isPlaying == false)
        {
            sonidosDeDaños[n].Play();
        }


    }

}
