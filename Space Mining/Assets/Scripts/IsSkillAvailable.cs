using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IsSkillAvailable : MonoBehaviour {
	public Skill1Script skill1Controller;
	private	Button b;

	void Start(){
		b = transform.GetComponent<Button> ();
		b.onClick.AddListener (this.btnClicked);
		
	}

	// If the button is available we asign the color green, else, grey
	public void SetButtonAvailable(bool available) {
		b = transform.GetComponent<Button> ();
		if (available) {
			b.interactable = true;

		} else {
			b.interactable = false;

		}
	}
	
	void btnClicked(){
		skill1Controller.BuySkill ();
	}


}
