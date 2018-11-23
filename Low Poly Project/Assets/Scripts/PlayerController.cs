using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	public Camera camera;
	public NavMeshAgent agent;

	Animator myAnim;
	float dist = 0;
	RaycastHit hit;

	Quaternion newRotation;
	float rotSpeed = 5f;

	Quaternion savedRot;
	bool isMoving = false;

	void Start() {

		myAnim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		RayCastCalculation ();
		DistanceCalculation ();
		RotationCalculation ();

		if (transform.rotation != savedRot && isMoving == false) {

			transform.rotation = savedRot;
		
		}
	}

	void RayCastCalculation(){

		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) 
			{
				agent.SetDestination (hit.point);
				myAnim.SetBool ("IsRunning", true);
				isMoving = true;
			}
		}

	}


	void DistanceCalculation(){

		dist = Vector3.Distance (hit.point, transform.position);
		//Debug.Log ("Distance = " + dist);
		if (dist < 0.5f) {

			myAnim.SetBool ("IsRunning", false);
			isMoving = false;
			savedRot = transform.rotation;
		}
	
	}

	void RotationCalculation(){

		Vector3 relativePos = hit.point - transform.position;
		newRotation = Quaternion.LookRotation (relativePos, Vector3.up);
		newRotation.x = 0f;
		newRotation.z = 0f;

		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, rotSpeed * Time.deltaTime);

	}

}