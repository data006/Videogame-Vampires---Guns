﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

	public void PlaySelectLevel()
	{
		SceneManager.LoadScene("00Load");
		Time.timeScale = 1f;
	}

}
