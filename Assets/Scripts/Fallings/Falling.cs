using UnityEngine;
using System.Collections;

public class Falling : MonoBehaviour {

	public Respawn targetRespawn;

	public void Respawn() {
		if (targetRespawn) {
			renderer.material.color = targetRespawn.colours[Random.Range(0, targetRespawn.colours.Count)];
			transform.position = targetRespawn.GetRandomPointInsideBounds();
			rigidbody.velocity = Vector3.zero;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Finish") {
			Respawn();
		}
	}
}
