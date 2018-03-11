using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
using GoogleARCore.HelloAR;


public class EnvironmentControllerScript : MonoBehaviour 
{
	public Image SelectableModel;
	public GameObject[] Monsters; // Holding Enemies 
	public GameObject[] Environment; //Holding Trees
	public Sprite[] Environment_Images;
	public Camera FirstPersonCamera;
	public static GameObject Selectable_Character;

	private bool _IsGameStarted; // to Check Game is Started
	private int _count=0;

	//public Text DebugText;


	void Start() //Getting all the sprites for UI and Spwaing on UI Buttons
	{
		SelectableModel.sprite = Environment_Images [_count];
		Selectable_Character = Environment [_count];
	}

	public void StartGame() // Setting the environment and calling all the enemies using Coroutine
	{
		HelloARController.SetEnvironment_Bool = true;
		
		_IsGameStarted = true;

		StartCoroutine ("SetEnvironment");


	}



	public void previousBtn()  				//Selecting the chaenvironemt objects
	{
		if(_count!=0)
		_count--;
		SelectableModel.sprite = Environment_Images [_count];
		Selectable_Character = Environment [_count];

	}
	public void nextBtn()
	{
		if(_count!=6)
		_count++;
		SelectableModel.sprite = Environment_Images [_count];
		Selectable_Character = Environment [_count];
	}



	IEnumerator SetEnvironment()			//Refrence to the StartGame Method
	{
	
		if (HelloARController.TreeList.Count > 0) 
		{
			while (true) 
			{
				int r = Random.Range (0, HelloARController.TreeList.Count);
				//foreach (var item in HelloARController.TreeList) 

				var items = HelloARController.TreeList [r];
				int monsternumber = Random.Range(0,3);
				Instantiate (Monsters[monsternumber],items,Quaternion.identity); //Spwaning the Monster around the Tress and the Bushes
			//	DebugText.text = monsternumber.ToString();

				yield return new WaitForSeconds (10f);
				
			}

		}


	}



}
