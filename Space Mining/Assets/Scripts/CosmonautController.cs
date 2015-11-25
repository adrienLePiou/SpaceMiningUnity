using UnityEngine;
using System.Collections;

public class CosmonautController : MonoBehaviour {
	Animator anim;
	private float Damages = 1.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger("hitTrigger");
		}

	}

	public void setDamages(float DamagesToAdd){
		Damages = Damages + DamagesToAdd;
	}

	public float getDamages(){
		return Damages;
	}

}
