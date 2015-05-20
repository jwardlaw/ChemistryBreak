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
		if (this.tag == "Acid" || this.tag == "Base" || this.tag == "Neutral")
			highlight.text = "???";
		else if (this.tag == "Pheno")
			highlight.text = "Phenopthalien";
		else
			highlight.text = this.tag;
	}
}
