using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour {
	public GameObject smoke;
	public AudioSource audio;
	public AudioClip apagando;
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("water"))
        {
			smoke.transform.position = this.transform.position;
			smoke.SetActive (true);
			audio.PlayOneShot (apagando, 1F);
			StartCoroutine ("StartSmoke");
        }
    }

	IEnumerator StartSmoke(){
		yield return new WaitForSecondsRealtime (1);
		this.gameObject.SetActive(false);
	}

    }
