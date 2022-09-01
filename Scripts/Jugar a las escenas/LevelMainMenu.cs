using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMainMenu : MonoBehaviour
{

	public void PlayMainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("0Load");
	}

}
