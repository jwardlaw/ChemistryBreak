using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class text_highlight : MonoBehaviour {
	public GameObject ui_text;

	Text highlight;

	void Start()
	{
		highlight = ui_text.GetComponent<Text> ();
	}


	void OnMouseOver()
	{
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)) {
			if (hit.collider.tag == "H2S04" || hit.collider.tag == "Base" || hit.collider.tag == "Neutral")
				highlight.text = "These are 3 bottles of H20, H2S04 and NaOH, but the name tags are missing.";
			else if (hit.collider.tag == "Pheno")
				highlight.text = "Phenolphthalein";
			else if (hit.collider.tag == "Locked Chest")
				highlight.text = "A Locked Chest, but the lock seems quite rusty. Maybe some highly corrosive strong acid would be able to destroy it.";
			else if (hit.collider.tag == "Door")
				highlight.text = "A Door, locked by a keypad. Where is the the keycode?";
			else
				highlight.text = hit.collider.tag;
		}

	}
	
}
