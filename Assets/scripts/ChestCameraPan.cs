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

	void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}


	public IEnumerator PanToPosition(Transform start, Transform end, float time)
	{	
		yield return new WaitForSeconds (2);
		float elapsedTime = 0;
		while (elapsedTime < time)
		{
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, end.position, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}

	public IEnumerator RotToPosition(Transform start, Transform end, float time)
	{
		yield return new WaitForSeconds (2);
		float elapsedTime = 0;
		inputfield.SetActive (false);
		chest.GetComponent<BoxCollider> ().enabled = false;
		while (elapsedTime < time)
		{
			Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, end.rotation, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
}