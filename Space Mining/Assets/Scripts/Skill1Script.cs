using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill1Script : MonoBehaviour {
	public MoneyController moneyController;
	public IsSkillAvailable IsSkillAvailable;
	public CosmonautController cosmonautController;
	public GameObject costTxt;

	private int CurrentCrystals;
	private int Cost = 2;
	private float DamagesToAdd = 1.0f;

	private bool SkillAvailable = false;

	void Awake(){

		IsSkillAvailable.SetButtonAvailable(SkillAvailable);
		CurrentCrystals = moneyController.getTotalCrystal ();
		isAvailable ();
		displayCost ();

	}

	public bool isAvailable(){
		CurrentCrystals = moneyController.getTotalCrystal ();
		if ((CurrentCrystals - Cost) >= 0) {
			SkillAvailable = true;
			IsSkillAvailable.SetButtonAvailable (SkillAvailable);
			Debug.Log ("true: " + CurrentCrystals);

		} else {
			Debug.Log ("false: " + CurrentCrystals);
			SkillAvailable = false;
			IsSkillAvailable.SetButtonAvailable (SkillAvailable);
		}
		return SkillAvailable;
	}

	public void BuySkill(){
		if (SkillAvailable) {
			moneyController.setTotalCrystal(-Cost);
			CurrentCrystals = moneyController.getTotalCrystal();
			cosmonautController.setDamages(DamagesToAdd);
			Cost++;
			isAvailable();
		}
	}

	private void displayCost(){
		costTxt.GetComponent<Text> ().text = Cost.ToString ();
	}



}
