using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VidaEnemiga : MonoBehaviour {

    public Animator animator;
	public float vida;
	public float vidaMaxima;
	public bool teWacho;
    public bool muriendo = false;
    public ContadorDeEnemigos contadorDeEnemigos;

    public Collider colision;
    public CharacterController characterController;
    public NavMeshAgent navMeshAgent;
    public EstadoPersecucion estadoPersecucion;
    public EstadoPatrulla estadoPatrulla;
    public MaquinaDeEstados maquinaDeEstados;
    public EstoyVigilando estoyVigilando;
    public TempoGrito tempoGrito;
    public TempoAtaque tempoAtaque;
    public TempoDaño tempoDaño;

    public float tiempoTranscurrido;
    public float tiempoLimite;

    void Start () {
		
	}
	
	void Update () {

		if(vida <= 0)
		{
			vida = 0;
		}

        if(muriendo == true)
        {
			colision.enabled = false;
			characterController.enabled = false;
			navMeshAgent.enabled = false;
			estadoPersecucion.enabled = false;
			estadoPatrulla.enabled = false;
			maquinaDeEstados.enabled = false;
			estoyVigilando.enabled = false;
			tempoGrito.enabled = false;
			tempoAtaque.enabled = false;
			tempoDaño.enabled = false;

			tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido >= tiempoLimite)
            {
                Destroy(gameObject);
            }
        }

		if(teWacho == true)
		{
			return;
		}


		if(vida != vidaMaxima)
		{
			teWacho = true;
		}

        

	}

	public void TakeDamage(float amount)
	{
		vida -= amount;

		if ((vida <= 0) && (navMeshAgent.enabled == true))
		{
			navMeshAgent.enabled = false;
			vida = 0;
            muriendo = true;
			Die();
		}
	}

    void Die()
    {
        colision.enabled = false;
        characterController.enabled = false;
        navMeshAgent.enabled = false;
        estadoPersecucion.enabled = false;
        estadoPatrulla.enabled = false;
        maquinaDeEstados.enabled = false;
        estoyVigilando.enabled = false;
        tempoGrito.enabled = false;
        tempoAtaque.enabled = false;
        tempoDaño.enabled = false;

        animator.SetBool("Vigilando-Muriendo", true);
        animator.SetBool("Patrullando-Muriendo", true);
        animator.SetBool("Corriendo-Muriendo", true);
        animator.SetBool("Atacando-Muriendo", true);
        animator.SetBool("Gritando-Muriendo", true);

        contadorDeEnemigos.enemigos -= 1;
    }

}
