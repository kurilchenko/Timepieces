using UnityEngine;
using System.Collections;

public class CubeClock : MonoBehaviour {

	public float rotationSpeed = 50f;

	void Update() {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.Self);
	}
}
