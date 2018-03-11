using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	private float _movementAngle = 0, TempZPostion,TempXPosition;
	private float _Speed = 0.5f; //2*PI in degress is 360, so you get 5 seconds to complete a circle
	private Animator _anim;
  	public float radius;
	private Quaternion _target;
	private SkinnedMeshRenderer _mesh;
	private int _count=0;
	private RaycastHit _hit;

	public int move;
	public GameObject fire;




    private void Start()					//Getting all the components and postion from the Active Heirarchy
    {
		_anim = GetComponent<Animator> ();								
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
		TempXPosition = move==1?transform.position.z:transform.position.x;
        _target = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {

		//Debug.DrawRay (this.transform.position + Vector3.up * 0.5f ,transform.forward * 0.35f);
		if (Physics.Raycast(this.transform.position + Vector3.up * 0.5f, this.transform.forward , out _hit ,0.3f) ) //Drawing a ray to get the Hit on Tree and change Animation State
		{
			if (_hit.collider.CompareTag ("Tree")) 
			{
				_anim.SetBool ("Attack", true);
			
				GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
//			

			} 
			else 
			{
				_anim.SetBool ("Attack", false);

			}
			
		} 
		else 
		{
			_anim.SetBool ("Attack", false);	
		
		if (move == 1) 									//checking the mmovement type X axis towards negative and Positive
														// and Movement type in Z axis towards neg and positive
		{
			if (TempZPostion > 1) {
				_target = Quaternion.Euler (0, 0, 0);
			} else if (TempZPostion < -1) 
			{
				_target = Quaternion.Euler (0, 180, 0);
            
			}
		}
			else 
		{
			
			if (TempZPostion > 1) {
				_target = Quaternion.Euler (0, 90, 0);
			} else if (TempZPostion < -1) {
				_target = Quaternion.Euler (0, 270, 0);

			}
		}


         transform.rotation = Quaternion.Slerp(transform.rotation, _target, Time.deltaTime * radius);      //Combining Spherical Interpolation to make a Line
        _movementAngle += _Speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
		if (move==1)
		transform.position = new Vector3(transform.position.x, transform.position.y, TempXPosition-TempZPostion);
		else
			transform.position = new Vector3(TempXPosition-TempZPostion,transform.position.y, transform.position.z );
		TempZPostion = Mathf.Cos(_movementAngle) * radius ;
      
		_count++;
		if (_count > 30)
		{
			GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true; // Enabling the Skin Mesh of the child component

		}
     }  
	}


}
	