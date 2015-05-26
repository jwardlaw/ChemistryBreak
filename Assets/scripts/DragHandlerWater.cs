using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragHandlerWater : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject item;
	//public static GameObject item2;
	
	public Button button1;
	
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
			else if(hit.collider.tag == "Acid" || hit.collider.tag == "H2S04")
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
		highlight.text = "Nothing happened.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextAcid()
	{
		highlight.text = "Vicious reaction. Maybe you should try adding it the other way around?";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextBase()
	{
		highlight.text = "The water mixes with the solution.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextPheno()
	{
		highlight.text = "Phenolphthalein remains colorless.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextChest()
	{
		highlight.text = "Splash! Nothing happened.";
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
