using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float lifetime;

	void Start () {
		Destroy (gameObject, lifetime);
	}
}
