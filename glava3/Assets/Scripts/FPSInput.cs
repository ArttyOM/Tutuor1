using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour {
	
	public float speed = 9f;
	public float gravity = -9.8f;
	private CharacterController _characterController;
	void Start ()
	{
		_characterController = GetComponent<CharacterController>();
	}
		// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed *Time.deltaTime;
		//Debug.Log (deltaX);
		float deltaZ = Input.GetAxis("Vertical")*speed* Time.deltaTime;
		Vector3 movement = Vector3.ClampMagnitude (new Vector3 (deltaX, gravity*Time.deltaTime, deltaZ), speed*Time.deltaTime);
		movement = transform.TransformDirection (movement);
		_characterController.Move (movement);
	}
	
}
