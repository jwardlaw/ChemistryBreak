using UnityEngine;
using System.Collections;

public class StartGame: MonoBehaviour {
	void Update()
	{
		//start the game if the start game key is pressed
		if (Input.GetKeyDown ("space"))
		{
			Application.LoadLevel("main");
		}
	}
}