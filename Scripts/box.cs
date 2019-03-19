using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

	public GameObject fogo;
	public bool existe;

	void Start(){
		existe = true;
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("chama"))
        {
			fogo.SetActive (true);
			StartCoroutine ("PegarFogo");
            
        }
    }
	IEnumerator PegarFogo(){
		yield return new WaitForSecondsRealtime (2);
		fogo.SetActive (false);
		existe = false;
		this.gameObject.SetActive(false);
	}
}
