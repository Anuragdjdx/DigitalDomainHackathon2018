using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (gameObject);
	}
	

	public void ChangeLevel(string SceneName)
	{
		SceneManager.LoadScene (SceneName); // To Change Level
	}

	public void QUitApplication()
	{
		Application.Quit();
	}
}
