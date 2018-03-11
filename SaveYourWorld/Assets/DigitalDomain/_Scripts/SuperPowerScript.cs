using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SuperPowerScript : MonoBehaviour
{
	public Camera ArCoreCamera;
	private RaycastHit _hit;
	public  GameObject ShootingGaze,MazeDeath,RangerDeath,KnightDeath;
	public Text ScoreText;
	private int _kill =0;

	// Use this for initialization
	void Start()
	{
		ShootingGaze.SetActive (false);
	}




	// Update is called once per frame
	void Update ()
	{
		
		//Debug.DrawRay (ArCoreCamera_1.transform.position, ArCoreCamera_1.transform.forward * 100f);
		if (Physics.Raycast (ArCoreCamera.transform.position, ArCoreCamera.transform.forward, out _hit, 100f)) // Creating a Ray to find and Kill enemies
		{

			//// Below condition is checking the Collision for all the Enemies

			if (_hit.collider.CompareTag ("Ranger")) 					
			{
				ShootingGaze.SetActive (true);
				if (Input.touchCount > 0)
				{
					Vector3 pos = _hit.collider.transform.position;
					Destroy (_hit.collider.gameObject);
					var particale =Instantiate (MazeDeath, pos,Quaternion.identity);
					Destroy (particale, 2f);
					_kill++;

				}
			}
			else if (_hit.collider.CompareTag ("Mage")) 
			{
				ShootingGaze.SetActive (true);
				if (Input.touchCount > 0)
				{
					Vector3 pos = _hit.collider.transform.position;
					Destroy (_hit.collider.gameObject);
					var particale =Instantiate (RangerDeath, pos,Quaternion.identity);
					Destroy (particale,0.25f);
					_kill++;

				}
			}
			else if (_hit.collider.CompareTag ("Knight")) 
			{
				ShootingGaze.SetActive (true);
				if (Input.touchCount > 0)
				{
					Vector3 pos = _hit.collider.transform.position;

					var particale =Instantiate (KnightDeath, pos,Quaternion.identity);
					Destroy (particale,0.25f);
					Destroy (_hit.collider.gameObject);
					_kill++;


				}
			}
			else
			{
				ShootingGaze.SetActive (false);
			}
		}
		else
		{
			ShootingGaze.SetActive (false);
		}
				
		ScoreText.text = "Score :" + (_kill * 10).ToString ();
		
	}
}
