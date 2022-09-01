using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject objToTP;
    public Transform tpLoc;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            objToTP.transform.position = tpLoc.transform.position;
        }
    }
}
