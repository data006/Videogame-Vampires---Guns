using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista : MonoBehaviour {
    

	public EstadoPatrulla estadoPatrulla;
	public VidaEnemiga vidaEnemiga;



	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		if (estadoPatrulla.enPersecucion == true)
		{
			return;
		}


		if (vidaEnemiga.teWacho == true && enabled && estadoPatrulla.colision == false && estadoPatrulla.siguienteWayPoint == false)
		{
			estadoPatrulla.colision = true;
			estadoPatrulla.enPersecucion = true;
			estadoPatrulla.estoyVigilando.enabled = false;
			estadoPatrulla.siguienteWayPoint = true;

			if (estadoPatrulla.animator.GetCurrentAnimatorStateInfo(0).IsName("Vigilando"))
			{
				estadoPatrulla.animator.SetBool("Vigilando-Gritando", true);
				estadoPatrulla.navMeshAgent.speed = 0;
				estadoPatrulla.tempoGrito.enabled = true;
			}

			if (estadoPatrulla.animator.GetCurrentAnimatorStateInfo(0).IsName("Patrullando"))
			{
				estadoPatrulla.animator.SetBool("Patrullando-Gritando", true);
				estadoPatrulla.navMeshAgent.speed = 0;
				estadoPatrulla.tempoGrito.enabled = true;
			}

			estadoPatrulla.vigilando = false;
            

		}



	}

	public void OnTriggerEnter(Collider other)
	{
		if(estadoPatrulla.enPersecucion == true)
		{
			return;
		}

		if(other.gameObject.CompareTag("Player") && enabled && estadoPatrulla.colision == false && estadoPatrulla.siguienteWayPoint == false)
		{
			estadoPatrulla.colision = true;
			estadoPatrulla.enPersecucion = true;
			estadoPatrulla.estoyVigilando.enabled = false;
			estadoPatrulla.siguienteWayPoint = true;

			if(estadoPatrulla.animator.GetCurrentAnimatorStateInfo(0).IsName("Vigilando"))
			{
				estadoPatrulla.animator.SetBool("Vigilando-Gritando", true);
				estadoPatrulla.navMeshAgent.speed = 0;
				estadoPatrulla.tempoGrito.enabled = true;
			}

			if (estadoPatrulla.animator.GetCurrentAnimatorStateInfo(0).IsName("Patrullando"))
			{
				estadoPatrulla.animator.SetBool("Patrullando-Gritando", true);
				estadoPatrulla.navMeshAgent.speed = 0;
				estadoPatrulla.tempoGrito.enabled = true;
			}

			estadoPatrulla.vigilando = false;
            

		}

		


	}

}
