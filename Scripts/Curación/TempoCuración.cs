using System.Collections;
using UnityEngine;

public class TempoCuración : MonoBehaviour
{

    public float loQueFalta;
    public float tiempoTranscurrido;
    
    

    public Curación curación;
    public SistemaDeVida sistemaDeVida;
    


    // Use this for initialization
    void OnEnable()
    {
        tiempoTranscurrido = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (curación.subiendo == true)
			return;


		curación.subiendo = true;

		StartCoroutine(Suba());

		return;








    }


	IEnumerator Suba()
	{

		
        for(int i = 0; i <= 98; i++)
        {
            yield return new WaitForSeconds(0.47f);

            if (curación.siEsPlayer == false)
            {
                yield break;
            }
            else
            {
                sistemaDeVida.vida += 1;
                curación.limiteVida -= 1;
            }
        }




    }


}
