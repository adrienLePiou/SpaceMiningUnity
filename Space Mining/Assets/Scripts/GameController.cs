using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject cosmonaut;
	public GameObject cracks;
	public GameObject cracks2;
	public Transform asteroid;
	public GameObject explosion;
	public Camera cam;

	public asteroidScript asteroidController;

	Animator anim;

	private int currentHP;
	private GameObject AsteroidClone;
	private GameObject objCracks;
	private GameObject Cracks;


	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		createNewAsteroid ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

	
			Cracks=Instantiate(cracks,new Vector3(0.0f,-3.34f, 0.0f), Quaternion.identity) as GameObject;
			currentHP --;

			if(currentHP < 3){
				objCracks=Instantiate(cracks2, new Vector3(0.0f,-3.34f, 0.0f), Quaternion.identity) as GameObject;

			}

			if(currentHP == 0){
				anim = AsteroidClone.GetComponent<Animator>();
				anim.SetTrigger("explode");
				StartCoroutine(DestroyAsteroid());
				//return;
			}
		}
			
	}

	IEnumerator DestroyAsteroid(){

		Destroy (Cracks);
		Destroy (AsteroidClone, 1.0f);


		yield return new WaitForSeconds(1.2f);
		//after waiting for 1.5seconds we create a new asteroid.
		createNewAsteroid ();
	}

	void createNewAsteroid(){
		currentHP = asteroidController.getAsteroidHP ();
		AsteroidClone=Instantiate(asteroid,new Vector3(0.0f,-3.34f, 0.0f), Quaternion.identity) as GameObject;
	}



}
