using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyController : MonoBehaviour {
	public GameObject TotalCrystalsTxt;
	private int TotalCrystal;

	public void setTotalCrystal(int newCrystals){
		TotalCrystal = TotalCrystal + newCrystals;
		displayTotalCrystals (TotalCrystal);
	}

	public int getTotalCrystal(){
		return TotalCrystal;
	}

	private void displayTotalCrystals( int TotalCrystals ) {
		TotalCrystalsTxt.GetComponent<Text>().text = TotalCrystals.ToString();
	}

}
