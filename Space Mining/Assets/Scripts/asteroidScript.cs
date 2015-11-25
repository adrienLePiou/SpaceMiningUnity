using UnityEngine;
using System.Collections;

public class asteroidScript : MonoBehaviour {
	public GameObject asteroid;
	public float asteroidHP;
	public int lvl = 1;


	private float baseHP= 10f;
	private int asteroidCrystals;
	public Animator anim;





	public float getAsteroidHP(){
		if (lvl == 1) {
			asteroidHP = baseHP;
		} else {
			// Round Up( ([Base Life] * (1.60 ^ ([Level] - 1)) + ([Level] - 1) * 10) * ([Is Boss] * 10) )
			asteroidHP = Mathf.Round(baseHP * (Mathf.Pow(1.60f, lvl-1)));
		}
		return asteroidHP;
	}

	public void destroyAsteroid () {
		
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger("explode");
		}
		
	}

	public int getCurrentLvl(){
		return lvl;
	}

	public void setCurrentLvl(){
		lvl ++;
	}

	public int getAsteroidCrystals(){
		asteroidCrystals = 1 * lvl;
		return asteroidCrystals;
	}

	/*public GameObject getAsteroidGO(){
		GameObject obj = Instantiate(asteroid,new Vector3(0.0f,-3.27f, 0.0f), Quaternion.identity) as GameObject;
		return obj;
	}

	public void DestroyAsteroid(GameObject asteroid){
		Destroy (asteroid, 1.0f);
	}*/
	
}
