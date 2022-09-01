using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorDeEnemigos : MonoBehaviour {

    public int enemigos;
    public Objetivos Objetivos;

	public TextMeshProUGUI textMeshPro;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

		textMeshPro.text = enemigos.ToString();

        if (enemigos <= 0 && Objetivos.win == false)
        {
            Objetivos.win = true;

            enemigos = 0;



			Cursor.visible = true;




		}

        


	}
}
