using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

	void LateUpdate()
	{
		//	float pinchAmount = 0;
		//	Quaternion desiredRotation = transform.rotation;

		//	//Calculate();

		//	if (Mathf.Abs(TouchManager.pinchDistanceDelta) > 15)
		//	{ // zoom
		//		pinchAmount = TouchManager.pinchDistanceDelta;
		//	}

		//	if (Mathf.Abs(TouchManager.turnAngleDelta) < 15)
		//	{ // rotate
		//		Vector3 rotationDeg = Vector3.zero;
		//		rotationDeg.z = -TouchManager.turnAngleDelta;
		//		desiredRotation *= Quaternion.Euler(rotationDeg);
		//	}

		//	// not so sure those will work:
		//	transform.rotation = desiredRotation;
		//	transform.position += Vector3.forward * pinchAmount;
		//}
	}
}