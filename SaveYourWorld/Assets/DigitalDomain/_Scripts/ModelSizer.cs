using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelSizer : MonoBehaviour 
{
	 Slider Sizer;
	public float size;

	// Use this for initialization
	void Start () 
	{
		Sizer = GameObject.Find ("SliderSizer").GetComponent<Slider> ();
		Sizer.value = 0.5f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		size = Sizer.value;
		this.transform.localScale = Vector3.one * size;

	}

	void OnDestroy()
	{
		Sizer = null;
	}



	public IEnumerator waitsome()
	{
		yield return new WaitForSeconds (5f);
	}




}
