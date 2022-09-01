using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimacionText : MonoBehaviour {

	private TextMeshPro texto;
	public GameObject textoSiguiente;

	// Use this for initialization
	IEnumerator Start () {
		texto = gameObject.GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();

		int totalLetras = texto.textInfo.characterCount;
		int counter = 0;

		while (true)
		{
			int visibles = counter % (totalLetras + 1);

			texto.maxVisibleCharacters = visibles;

			if (visibles == 0)
			{
				yield return new WaitForSeconds(2.5f);
			}
			

			if(visibles >= totalLetras)
			{
				textoSiguiente.SetActive(true);
				yield return new WaitForSeconds(300.0f);
				
			}

			counter += 1;

			yield return new WaitForSeconds(0.03f);

		}
	}
	
}
