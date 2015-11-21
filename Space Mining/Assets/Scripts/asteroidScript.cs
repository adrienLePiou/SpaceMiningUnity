using UnityEngine;
using System.Collections;

public class asteroidScript : MonoBehaviour {
	public GameObject asteroid;
	public float asteroidHP;
	public int lvl = 1;

	public Animator anim;

	public float getAsteroidHP(){
		if (lvl == 1) {
			asteroidHP = 10f;
		} else {
			asteroidHP = lvl * 2f;
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
