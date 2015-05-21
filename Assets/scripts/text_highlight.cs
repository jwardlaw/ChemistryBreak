using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class text_highlight : MonoBehaviour {
	public GameObject ui_text;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;

	Text highlight;

	void Start()
	{
		button2.SetActive (false);
		button3.SetActive (false);
		button4.SetActive (false);
		highlight = ui_text.GetComponent<Text> ();
	}
	

	void OnMouseDown()
	{
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)) { 
			if (hit.collider.tag == "Water")
				button4.SetActive (true);
			else if(hit.collider.tag == "Pheno")
				button3.SetActive(true);
			else if(hit.collider.tag == "H2S04")
				button2.SetActive (true);
		}
	}

	void OnMouseOver()
	{
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)) {
			if (hit.collider.tag == "Acid" || hit.collider.tag == "Base" || hit.collider.tag == "Neutral")
				highlight.text = "???";
			else if (hit.collider.tag == "Pheno")
				highlight.text = "Phenolphthalein";
			else
				highlight.text = hit.collider.tag;
		}

	}
	
}
