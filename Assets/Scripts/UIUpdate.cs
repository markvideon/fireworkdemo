using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour {

	private static int instanceCount;
	private int myInstanceNum;
	private Text textContent;

	private bool found;
	private GameObject monitoredObject;
	private Firework linkedFirework;

	private Camera cam;

	// Use this for initialization
	void Awake () {
		found = false;
		myInstanceNum = instanceCount; 
		instanceCount++;
		cam = Camera.main;
	}

	void Start() {
		textContent = GetComponent<Text> ();
		RectTransform myPos = GetComponent<RectTransform> ();

		if (myInstanceNum == 0) 
		{
			myPos.anchoredPosition = new Vector2(-200,-100);
		} else if (myInstanceNum == 1) 
		{
			myPos.anchoredPosition = new Vector3 (-100, -100);
		} else if (myInstanceNum == 2) 
		{
			myPos.anchoredPosition = new Vector3(100,-100);
		} else if (myInstanceNum == 3) 
		{
			myPos.anchoredPosition = new Vector3(200,-100);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!found) {

			if (monitoredObject = GameObject.Find ("Firework" + myInstanceNum)) {

				if (linkedFirework = monitoredObject.GetComponent<Firework>()) {
					found = true;
				}
			}
		} else {

			if (linkedFirework.isBursting
				|| cam.WorldToScreenPoint(monitoredObject.transform.position).y < 0) {
				textContent.text = "";
			} else {
				textContent.text = linkedFirework.explosionTriggerKey.ReturnString ();
			}
		}

	}
}
