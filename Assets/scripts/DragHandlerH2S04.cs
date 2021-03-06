﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragHandlerH2S04 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject item;
	//public static GameObject item2;
	
	public Button button1;
	public Button button2;
	
	Vector3 start_position;
	public GameObject ui_text;
	Text highlight;
	
	void Start()
	{
		highlight = ui_text.GetComponent<Text> ();
		button1.GetComponentInChildren<Text> ().text = gameObject.tag;
	}
	
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		item = gameObject;
		start_position = transform.position;
	}
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	
	public void OnEndDrag (PointerEventData eventData)
	{
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 1000)) {
			if(hit.collider.tag == "Neutral" || hit.collider.tag == "Water")
			{
				StartCoroutine("DisplayText");
			}
			else if(hit.collider.tag == "Acid" || hit.collider.tag == "H2S04" || hit.collider.tag == "HCL")
			{
				StartCoroutine("DisplayTextAcid");
			}
			else if(hit.collider.tag == "Base")
			{
				StartCoroutine("DisplayTextBase");
			}
			else if(hit.collider.tag == "Pheno")
			{
				StartCoroutine ("DisplayTextPheno");
			}
			else if(hit.collider.tag == "Locked Chest")
			{
				if(button2.isActiveAndEnabled == false)
				{
					StartCoroutine("DisplayTextChest");
				}
				else {
					StartCoroutine("DisplayTextChest");
					hit.collider.GetComponent<Animation>().Play ("ChestAnim");
					StartCoroutine(hit.collider.GetComponent<ChestCameraPan>().PanToPosition (hit.collider.GetComponent<ChestCameraPan>().startMarker, hit.collider.GetComponent<ChestCameraPan>().endMarker, Time.time));
					StartCoroutine(hit.collider.GetComponent<ChestCameraPan>().RotToPosition (hit.collider.GetComponent<ChestCameraPan>().startMarker, hit.collider.GetComponent<ChestCameraPan>().endMarker, Time.time));			
				}
			}
			else if(hit.collider.tag == "Paper")
			{
				StartCoroutine("DisplayTextPaper");
			}
			else
			{
				StartCoroutine("DisplayTextEtc");
			}
		}
		item = null;
		transform.position = start_position;
	}
	
	IEnumerator DisplayText()
	{
		highlight.text = "H2S04 mixes deep in the water.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextPaper()
	{
		highlight.text = "A drip of acid creates a hole in the paper. Maybe you shouldn't use this.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextAcid()
	{
		highlight.text = "There was no reaction.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextBase()
	{
		highlight.text = "Percipatate formed in the mixed solution.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextPheno()
	{
		highlight.text = "Phenolphthalein turns orange";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextChest()
	{
		if (button2.isActiveAndEnabled == false) {
			highlight.text = "Some other tools might be necessary before you proceed.";
			yield return new WaitForSeconds (10);
			highlight.text = "";
		} else {
			highlight.text = "The lock corroded off the chest.";
			yield return new WaitForSeconds (10);
			highlight.text = "";
		}
	}
	
	IEnumerator DisplayTextEtc()
	{
		highlight.text = "These cannot be combined";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

}
