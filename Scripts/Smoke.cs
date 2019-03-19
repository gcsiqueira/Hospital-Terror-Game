using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Destroy(gameObject, 5);
	}
}
