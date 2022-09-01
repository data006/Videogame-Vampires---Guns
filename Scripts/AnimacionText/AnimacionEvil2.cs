using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimacionEvil2 : MonoBehaviour
{

	private TextMeshPro texto;
	public GameObject textoAnterior;
	public GameObject textoSiguiente;

	// Use this for initialization
	IEnumerator Start()
	{
		texto = gameObject.GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();

		int totalLetras = texto.textInfo.characterCount;
		int counter = 0;

		while (true)
		{
			int visibles = counter % (totalLetras + 1);


			texto.maxVisibleCharacters = 0;
			yield return new WaitForSeconds(.8f);
			textoAnterior.SetActive(false);
			texto.maxVisibleCharacters = 3;

			yield return new WaitForSeconds(0.25f);
			texto.maxVisibleCharacters = 8;

			yield return new WaitForSeconds(0.2f);
			texto.maxVisibleCharacters = 9;

			yield return new WaitForSeconds(0.5f);
			texto.maxVisibleCharacters = 14;

			yield return new WaitForSeconds(0.3f);
			texto.maxVisibleCharacters = 17;

			yield return new WaitForSeconds(0.3f);
			texto.maxVisibleCharacters = 24;

			yield return new WaitForSeconds(300.0f);



			counter += 1;

			yield return new WaitForSeconds(0.05f);

		}
	}

}