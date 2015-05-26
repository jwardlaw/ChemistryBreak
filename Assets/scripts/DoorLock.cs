using UnityEngine;
using System.Collections;

public class DoorLock : MonoBehaviour {
	public GameObject field;
	// Use this for initialization
	void Start () {
		field.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		field.SetActive (true);
	}
}
