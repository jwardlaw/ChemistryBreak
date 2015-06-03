using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValidateEntry : MonoBehaviour {
	public InputField field;
	public GameObject inputfield;
	public GameObject ui_text;
	public GameObject chest;

	Text msg;
	// Use this for initialization
	void Start () {
		msg = ui_text.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if(field.text == "1111") {
				msg.text = "Level 1 Completed";
<<<<<<< HEAD
				Application.LoadLevel("Game Menu");
=======
				Application.LoadLevel("EndScene");
>>>>>>> origin/master
			}

		}
	}

}
