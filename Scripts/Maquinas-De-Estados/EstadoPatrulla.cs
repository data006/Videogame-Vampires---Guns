using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoPatrulla : MonoBehaviour {

	public Transform[] WayPoints;

	private MaquinaDeEstados maquinaDeEstados;
	private ControladorNavMesh controladorNavMesh;
	public EstoyVigilando estoyVigilando;
	public int siguientWayPoint;

	public Animator animator;
	public NavMeshAgent navMeshAgent;

    public TempoGrito tempoGrito;

	public bool vigilando;
	public bool colision;
	public bool siguienteWayPoint;

	public bool enPersecucion;

	public GameObject player;


	void Awake()
	{
		if (enPersecucion == true)
		{
			return;
		}

		maquinaDeEstados = GetComponent<MaquinaDeEstados>();
		controladorNavMesh = GetComponent<ControladorNavMesh>();
	}

	void OnEnable()
	{

		if (enPersecucion == true)
		{
			return;
		}

		ActualizarWayPointDestino();
	}

	public void ActualizarWayPointDestino()
	{

		if (enPersecucion == true)
		{
			return;
		}

		if (siguienteWayPoint == true)
		{
			return;
		}

		if(siguienteWayPoint == false)
		{
			siguienteWayPoint = true;
			controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPoints[siguientWayPoint].position);
			siguienteWayPoint = false;
		}
		
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			


			Vector3 playerPosition = new Vector3(player.transform.position.x,
											  transform.position.y,
											  player.transform.position.z);

			transform.LookAt(playerPosition);

			
			
		}
	}



	void Update () {

		if(enPersecucion == true)
		{
			return;
		}


		if(vigilando == true)
		{
			return;
		}

		if (controladorNavMesh.HemosLlegado() && vigilando == false)
		{
			vigilando = true;
			navMeshAgent.speed = 0f;
			estoyVigilando.enabled = true;
			
		}
	}


	

	

	
}
