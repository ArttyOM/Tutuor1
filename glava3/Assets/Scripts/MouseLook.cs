using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public float sensitivityHor = 9f;
	public float sensitivityVert= 9f;

	public float minimumVert = -45f;
	public float maximumVert = 45f;

	private float _rotationX = 0; //закрытая переменная для угла поворота по вертикали

	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	void Start()
	{
		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null)
			body.freezeRotation = true;
	}

	// Update is called once per frame
	void Update () {
	
		if (axes == RotationAxes.MouseX){
			transform.Rotate (0, Input.GetAxis("Mouse X")* sensitivityHor, 0);// это поворот в горизонтальной плоскости
		}
		else if (axes == RotationAxes.MouseY){

			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
			//transform.Rotate (sensitivityVer,0, 0);
			//Это поворот в вертикальной плоскости
		}
		else {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
			//Это комбинированный поворот
		}
	}


}
