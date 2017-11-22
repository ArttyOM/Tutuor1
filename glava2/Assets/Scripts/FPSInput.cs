using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
	
	// Update is called once per frame


		public float speed = 3f;
		


		// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horisontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		transform.Translate (deltaX, 0, deltaZ);
	}
	
}
