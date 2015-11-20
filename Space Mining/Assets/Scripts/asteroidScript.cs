using UnityEngine;
using System.Collections;

public class asteroidScript : MonoBehaviour {
	public GameObject asteroid;
	public int asteroidHP;
	public int lvl;

	public Animator anim;

	public int getAsteroidHP(){
		if (lvl == 1) {
			asteroidHP = 10;
		} else {
			asteroidHP = lvl * 2;
		}
		return asteroidHP;
	}

	public void destroyAsteroid () {
		
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger("explode");
		}
		
	}

	/*public GameObject getAsteroidGO(){
		GameObject obj = Instantiate(asteroid,new Vector3(0.0f,-3.27f, 0.0f), Quaternion.identity) as GameObject;
		return obj;
	}

	public void DestroyAsteroid(GameObject asteroid){
		Destroy (asteroid, 1.0f);
	}*/
	
}
