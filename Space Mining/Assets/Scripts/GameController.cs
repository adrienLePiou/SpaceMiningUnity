using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject cosmonaut;
	public GameObject cracks;
	public GameObject cracks2;
	public Transform asteroid;
	public GameObject explosion;
	public Camera cam;
	public GameObject particle;
	public GameObject healthBar;
	public GameObject txtDmgs;
	public Canvas damagesCanvas;
	public GameObject CurrentLvlTxt;
	public GameObject PreviousLvlTxt;
	public GameObject NextLvlTxt;
	public GameObject MonsterKilledTxt;

	public GameObject TotalCrystalsTxt;


	public CosmonautController cosmonautController;
	public asteroidScript asteroidController;
	public MoneyController moneyController;
	
	Animator anim;

	private float currentHP;
	private float maxHP;
	private GameObject AsteroidClone;
	private GameObject objCracks;
	private GameObject Cracks;
	private Vector3 mousePos;
	private Vector3 worldPos;
	private GameObject particleObj;
	private float currentDmgs;
	private GameObject txtDmgsObj;
	private int currentLvl;
	private int MonsterKilled;
	private int CurrentTotalCrystals;



	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		//createNewAsteroid ();
		currentDmgs = cosmonautController.getDamages ();
		currentLvl = asteroidController.getCurrentLvl ();
		setLvlTxt (currentLvl);
		MonsterKilled = 0;
		CurrentTotalCrystals = moneyController.getTotalCrystal ();
	}
	
	// Update is called once per frame
	void Update () {


		if (AsteroidClone == null) {

			createNewAsteroid ();
		} else {

			if (Input.GetMouseButtonDown (0)) {

				mousePos = Input.mousePosition;
				mousePos.z = 1.5f;
				worldPos = cam.ScreenToWorldPoint (mousePos);
				particleObj = Instantiate (particle, worldPos, Quaternion.identity) as GameObject;


				currentDmgs = cosmonautController.getDamages ();
				Cracks = Instantiate (cracks, new Vector3 (0.0f, -3.34f, 0.0f), Quaternion.identity) as GameObject;
				txtDmgs.GetComponent<Text> ().text = currentDmgs.ToString ();
				txtDmgsObj = Instantiate (txtDmgs, new Vector3 (0.0f, -3.0f, 0.0f), Quaternion.identity) as GameObject;
				txtDmgsObj.transform.SetParent (damagesCanvas.transform);
				currentHP = currentHP - currentDmgs;
				setHealthBar (currentHP);

				if (currentHP < 3) {
					objCracks = Instantiate (cracks2, new Vector3 (0.0f, -3.34f, 0.0f), Quaternion.identity) as GameObject;

				}

				if (currentHP <= 0) {
					anim = AsteroidClone.GetComponent<Animator> ();
					anim.SetTrigger ("explode");
					StartCoroutine (DestroyAsteroid ());
					MonsterKilled ++;
					setMonsterKilledTxt (MonsterKilled);
					int asteroidCrystals = asteroidController.getAsteroidCrystals ();

					moneyController.setTotalCrystal (asteroidCrystals);
					CurrentTotalCrystals = moneyController.getTotalCrystal ();



					if (MonsterKilled == 10) {
						asteroidController.setCurrentLvl ();
						currentLvl = asteroidController.getCurrentLvl ();
						MonsterKilled = 0;
						setMonsterKilledTxt (MonsterKilled);
						setLvlTxt (currentLvl);
					}

				}
			}
		}
			
	}

	IEnumerator DestroyAsteroid(){

		Destroy (Cracks);
		Destroy (AsteroidClone, 1.0f);


		yield return new WaitForSeconds(1.2f);
		//after waiting for 1.5seconds we create a new asteroid.

	}

	void createNewAsteroid(){
		maxHP = asteroidController.getAsteroidHP ();
		currentHP = maxHP;
		setHealthBar (currentHP);
		AsteroidClone=Instantiate(asteroid,new Vector3(0.0f,-3.34f, 0.0f), Quaternion.identity) as GameObject;
	}

	public void setHealthBar(float myHealth){
		myHealth = currentHP / maxHP;
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	public void setLvlTxt(int currentLvl){
		int previousLvl = currentLvl - 1;
		int nextLvl = currentLvl + 1;
		CurrentLvlTxt.GetComponent<Text> ().text = currentLvl.ToString ();
		PreviousLvlTxt.GetComponent<Text> ().text = previousLvl.ToString ();
		NextLvlTxt.GetComponent<Text> ().text = nextLvl.ToString ();
	}

	private void setMonsterKilledTxt(int MonsterKilled){
		MonsterKilledTxt.GetComponent<Text>().text = MonsterKilled + "/10";
	}

	private void displayTotalCrystals( int TotalCrystals ) {
		TotalCrystalsTxt.GetComponent<Text>().text = TotalCrystals.ToString();
	}


}
