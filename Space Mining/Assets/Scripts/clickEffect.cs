using UnityEngine;
using System.Collections;

public class clickEffect : MonoBehaviour {
	Camera cam;
	public GameObject particle;
	private Vector3 mousePos;
	private Vector3 worldPos;
	private GameObject particleObj;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			cam = Camera.main;

		}

	}
}
