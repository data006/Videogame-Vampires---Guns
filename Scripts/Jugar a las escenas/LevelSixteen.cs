using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSixteen : MonoBehaviour
{

	public float tiempoTranscurrido;

	public void Update()
    {
		Cursor.visible = false;
		tiempoTranscurrido += Time.fixedUnscaledDeltaTime;
		if (tiempoTranscurrido >= 16)
		{
			SceneManager.LoadScene("16Load");
			Time.timeScale = 1f;
		}

		
    }

}
