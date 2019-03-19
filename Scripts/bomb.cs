using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
    public GameObject a;
    public int tempo;
	public AudioSource audio;
	public AudioClip explodiu;

	// Update is called once per frame
	void Update () {
		
        tempo++;
		if (tempo >= 120) 
		{
			a.SetActive (true);
			audio.PlayOneShot (explodiu, 1F);
		}
        Destroy(gameObject, 5);

	}
}
