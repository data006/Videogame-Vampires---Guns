using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoPersecucion : MonoBehaviour {

	private MaquinaDeEstados maquinaDeEstados;
	private ControladorNavMesh controladorNavMesh;
    public NavMeshAgent navMeshAgent;
    public Animator animator;
	public GameObject player;

    public TempoAtaque tempoAtaque;
    public TempoDaño tempoDaño;
    public TempoGrito tempoGrito;

    public bool estoyAtacando = false;

    public bool estoyJuntoAlPlayer = false;

    public float velocidadAlCorrer;

    void Awake() {
		maquinaDeEstados = GetComponent<MaquinaDeEstados>();
		controladorNavMesh = GetComponent<ControladorNavMesh>();
	}

	void OnEnable()
	{
		
	}

    void Update() {

        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();


        if (controladorNavMesh.HemosLlegado())
        {
            estoyJuntoAlPlayer = true;
        }
        else
        {
            estoyJuntoAlPlayer = false;
        }


        if (estoyAtacando == true)
        {
            return;
        }


        

		
		

		if (controladorNavMesh.HemosLlegado() && tempoGrito.enabled == false)
        {
            navMeshAgent.speed = 0f;
            animator.SetBool("Corriendo-Atacando", true);

            estoyAtacando = true;

            tempoDaño.enabled = true;
        }
        else
        {
			

			navMeshAgent.speed = velocidadAlCorrer;
            animator.SetBool("Corriendo-Atacando", false);
        }
	}

	
}
