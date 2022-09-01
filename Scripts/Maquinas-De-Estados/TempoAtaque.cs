using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoAtaque : MonoBehaviour
{

    public float loQueFalta;
    public float tiempoTranscurrido;
    public Animator animator;

    public TempoDaño tempoDaño;

    public EstadoPersecucion estadoPersecucion;

    public SistemaDeVida sistemaDeVida;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        tiempoTranscurrido += Time.deltaTime;


        if (tiempoTranscurrido >= loQueFalta)
        {
            


            estadoPersecucion.estoyAtacando = false;
            tiempoTranscurrido = 0;
            enabled = false;
        }





    }
}
