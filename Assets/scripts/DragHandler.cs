using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject item;
	//public static GameObject item2;

	public Button button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	
	Vector3 start_position;
	public GameObject ui_text;
	Text highlight;
	
	void Start()
	{
		button2.SetActive (false);
		button3.SetActive (false);
		button4.SetActive (false);
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
				button2.SetActive(true);
				StartCoroutine("DisplayText");
			}
			else if(hit.collider.tag == "H2S04" || hit.collider.tag == "HCL" || hit.collider.tag == "Acid")
			{
				if(hit.collider.tag == "H2S04")
					button3.SetActive(true);
				StartCoroutine("DisplayTextAcid");
			}
			else if(hit.collider.tag == "Base")
			{
				StartCoroutine("DisplayTextBase");
			}
			else if(hit.collider.tag == "Pheno")
			{
				button4.SetActive(true);
				StartCoroutine("DisplayTextPheno");
			}
			else if(hit.collider.tag == "Locked Chest")
			{
				StartCoroutine("DisplayTextChest");
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
		highlight.text = "The pH strip did not change colors.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextAcid()
	{
		highlight.text = "The pH strip turned orange.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextBase()
	{
		highlight.text = "The pH strip turned blue.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextPheno()
	{
		highlight.text = "The pH strip turned slightly orange.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextChest()
	{
		highlight.text = "The pH strip crumbled in the lock.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextEtc()
	{
		highlight.text = "These cannot be combined";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

}
