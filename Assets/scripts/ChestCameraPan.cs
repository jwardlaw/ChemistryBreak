using UnityEngine;
using System.Collections;

public class ChestCameraPan : MonoBehaviour {
	public GameObject chest;
	public GameObject inputfield;
	public Transform startMarker;
	public Transform endMarker;
	public Transform retMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public float elapsedTime = 0;

	void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}

	void Update()
	{
		startTime = Time.time;
	}


	public IEnumerator PanToPosition(Transform start, Transform end, float time)
	{	
		elapsedTime = (time - startTime) * speed;
		
		while (elapsedTime < time)
		{
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, end.position, (elapsedTime / journeyLength));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}

	public IEnumerator RotToPosition(Transform start, Transform end, float time)
	{
		elapsedTime = (time - startTime) * speed;
		inputfield.SetActive (false);
		chest.GetComponent<BoxCollider> ().enabled = false;
		while (elapsedTime < time)
		{
			Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, end.rotation, (elapsedTime / journeyLength));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
}