using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenPanelScript : MonoBehaviour {
	public GameObject menuPanel;
	public Skill1Script skill1Controller;
	private	Button b;
	public Color myColor = new Color(0.5f, 0.5f, 0.5f);

	void Start(){
		b = transform.GetComponent<Button> ();
		b.onClick.AddListener (this.btnClicked);
	
	}

	void btnClicked(){
		if (!menuPanel.active) {
			menuPanel.SetActive (true);
			ColorBlock cb = b.colors;
			cb.normalColor = myColor;
			b.colors = cb;
			skill1Controller.isAvailable();

		} else {
			menuPanel.SetActive (false);
			ColorBlock cb = b.colors;
			cb.normalColor = Color.white;
			b.colors = cb;
		}
	}
}
