using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Respawn : MonoBehaviour {

	public List<Falling> prototypeFallings = new List<Falling>();
	public List<Falling> fallings = new List<Falling>();
	public int populationPerPrototype = 5;
	public List<Color> colours;

	void Start() {
		foreach (Falling prototype in prototypeFallings) {
			for (var i = 0; i < populationPerPrototype; i++) {

				var falling = Object.Instantiate(prototype) as Falling;
				falling.targetRespawn = this;
				fallings.Add(falling);

				falling.Respawn();

			}

			prototype.gameObject.SetActive(false);
		}
	}

	public Vector3 GetRandomPointInsideBounds() {
		var bounds = collider.bounds;
		var randomPointInsideBounds = new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			Random.Range(bounds.min.y, bounds.max.y),
			Random.Range(bounds.min.z, bounds.max.z)
		);

		return randomPointInsideBounds;
	}

}
