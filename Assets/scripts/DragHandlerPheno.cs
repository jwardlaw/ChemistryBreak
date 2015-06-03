using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragHandlerPheno : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject item;
	public GameObject chest;
	public GameObject paper;
	//public static GameObject item2;
	
	public Button button1;
	
	Vector3 start_position;
	public GameObject ui_text;
	Text highlight;
	public Texture new_paper;
	
	void Start()
	{
		highlight = ui_text.GetComponent<Text> ();
		button1.GetComponentInChildren<Text> ().text = "Phenolphthalein";
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
				StartCoroutine("DisplayTextChest");
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
		highlight.text = "Phenolphthalein remained colorless.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}

	IEnumerator DisplayTextPaper()
	{
		highlight.text = "Phenolphthalein turns purple on the paper yielding a keycode: 1111";
		paper.GetComponent<Renderer>().material.SetTexture("_MainTex", new_paper);
		yield return new WaitForSeconds (5);
		StartCoroutine(chest.GetComponent<ChestCameraPan>().PanToPosition (chest.GetComponent<ChestCameraPan>().endMarker, chest.GetComponent<ChestCameraPan>().retMarker, Time.time));
		StartCoroutine(chest.GetComponent<ChestCameraPan>().RotToPosition (chest.GetComponent<ChestCameraPan>().endMarker, chest.GetComponent<ChestCameraPan>().retMarker, Time.time));			
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextAcid()
	{
		highlight.text = "Phenolphthalein turned orange.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextBase()
	{
		highlight.text = "Phenolphthalein turned fuchsia.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextPheno()
	{
		highlight.text = "Phenolphthalein remained colorless.";
		yield return new WaitForSeconds (10);
		highlight.text = "";
	}
	
	IEnumerator DisplayTextChest()
	{
		highlight.text = "Phenolphthalein splashed off the chest.";
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
