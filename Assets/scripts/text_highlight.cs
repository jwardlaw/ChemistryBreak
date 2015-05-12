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
		highlight.text = this.tag;
	}
}
