using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoDaño : MonoBehaviour
{

    public float tiempoDaño;
    public float tiempoTranscurrido;
    public Animator animator;

    public int daño;

    public EstadoPersecucion estadoPersecucion;
    public TempoAtaque tempoAtaque;

    public SistemaDeVida sistemaDeVida;


    void Start()
    {

    }
    
    void Update()
    {


        tiempoTranscurrido += Time.deltaTime;


        if (tiempoTranscurrido >= tiempoDaño)
        {
            if ((estadoPersecucion.estoyJuntoAlPlayer == true) && (sistemaDeVida.vida > 0))
            {
                sistemaDeVida.vida -= daño;
                sistemaDeVida.DañoAHunter();
                sistemaDeVida.hudDaño = true;
            }
            
            tiempoTranscurrido = 0;
            tempoAtaque.enabled = true; 
            enabled = false;
        }





    }
}
