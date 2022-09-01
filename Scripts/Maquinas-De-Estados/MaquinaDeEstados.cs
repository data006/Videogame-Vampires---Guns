using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstados : MonoBehaviour {

	public MonoBehaviour EstadoPatrulla;
	public MonoBehaviour EstadoPersecucion;
	public MonoBehaviour EstadoInicial;

    public EstoyVigilando estoyVigilando;

    public Animator animator;

    public MonoBehaviour estadoActual;


	void Start () {
		ActivarEstado(EstadoInicial);
	}


	public void ActivarEstado(MonoBehaviour nuevoEstado)
	{
		if(estadoActual!=null) estadoActual.enabled = false;
		estadoActual = nuevoEstado;
		estadoActual.enabled = true;
		
	}

    public void Update()
    {
        if (estadoActual == EstadoPatrulla && estoyVigilando.enabled == false)
        {
            animator.SetBool("Vigilando-Patrullando", true);
        }

        if (estadoActual == EstadoPatrulla && estoyVigilando.enabled == true)
        {
            return;
        }
    }
}
