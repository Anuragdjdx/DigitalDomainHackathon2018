using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthKeeper : MonoBehaviour 
{
	[SerializeField]
	private float _TreeHeathDummy = 100;
	public GameObject SparkParticle;
	private bool _checkTrigger;


	

	void Update ()  				//checong the health of tree on each hit
	{
		if(_checkTrigger)
			_TreeHeathDummy -= 12 * Time.deltaTime;
	 if (_TreeHeathDummy < 0 ) 
		{
			Destroy (this.gameObject);
			var particle=Instantiate (SparkParticle, this.transform.position, Quaternion.identity);
			Destroy (particle,2f);

		}

	
	}


	void OnTriggerEnter (Collider other)
	{


		if (other.CompareTag ("Ranger") ||   other.CompareTag ("Knight") || other.CompareTag ("Mage") )
		{
			_checkTrigger = true;

		}


	}

	void OnTriggerExit (Collider other)
	{


		if (other.CompareTag ("Ranger") ||   other.CompareTag ("Knight") || other.CompareTag ("Mage") )
		{
			_checkTrigger = false;

		}


	}
}
