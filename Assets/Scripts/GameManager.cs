using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private int prefabCount;

	public GameObject prefab;
	public string prefabName;

	// Use this for initialization
	void Start () {
		prefabCount = 0;

		Invoke ("DelayInstantiate", 0f);
		Invoke ("DelayInstantiate", 1f);
		Invoke ("DelayInstantiate", 2f);
		Invoke ("DelayInstantiate", 3f);

	}

	void DelayInstantiate() {
		GameObject instantiatedPrefab = Instantiate (prefab);
		instantiatedPrefab.name = prefabName + prefabCount;
		prefabCount++;
	}

}
