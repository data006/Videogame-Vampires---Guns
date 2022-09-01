using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoGrito : MonoBehaviour {

    public float duracionAnimacion;
    public float tiempoTranscurrido;
    public Animator animator;

    public GameObject player;

    public MaquinaDeEstados maquinaDeEstados;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		animator.SetBool("Vigilando-Gritando", true);
		animator.SetBool("Patrullando-Gritando", true);

		Vector3 playerPosition = new Vector3(player.transform.position.x,
                                              transform.position.y,
                                              player.transform.position.z);

        transform.LookAt(playerPosition);


        tiempoTranscurrido += Time.deltaTime;


        if(tiempoTranscurrido >= duracionAnimacion)
        {
            
            animator.SetBool("Vigilando-Gritando", false);
            animator.SetBool("Patrullando-Gritando", false);
            animator.SetBool("Gritando-Corriendo", true);

            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            tiempoTranscurrido = 0;
            enabled = false;
        }

	}
}
