using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwenty : MonoBehaviour
{

	IEnumerator Start()
	{
		Cursor.visible = false;
		yield return new WaitForSeconds(13f);
		SceneManager.LoadScene("20Load");
		
	}

    

}
