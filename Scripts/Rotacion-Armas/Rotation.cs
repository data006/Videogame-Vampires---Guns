﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, speed, 0);
	}
}
