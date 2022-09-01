using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstoyVigilando : MonoBehaviour {
    public float limit_time;
    public float conten_time;
	public Animator animator;

	public EstadoPatrulla estadoPatrulla;
	public EstoyVigilando estoyVigilando;
	public NavMeshAgent navMeshAgent;

    public float velocidadPatrullando;

	void Start () {
		if (estadoPatrulla.enPersecucion == true)
		{
			return;
		}

		

		conten_time = 0;
	}


    void Update() {
		if (estadoPatrulla.enPersecucion == true)
		{
			return;
			
		}

		conten_time += Time.deltaTime;

		animator.SetBool("Patrullando-Vigilando", true);

		if (conten_time >= limit_time && estadoPatrulla.colision == false)
		{
			navMeshAgent.speed = velocidadPatrullando;
			estadoPatrulla.siguientWayPoint = (estadoPatrulla.siguientWayPoint + 1) % estadoPatrulla.WayPoints.Length;
			estadoPatrulla.ActualizarWayPointDestino();
			estadoPatrulla.vigilando = false;
			animator.SetBool("Patrullando-Vigilando", false);
			conten_time = 0;
			estoyVigilando.enabled = false;
		}
		
	}
	

}

