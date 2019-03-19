using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

	public FSMSimple enemyScript;
	public AudioSource audioSource;
	public AudioClip[] audioClip;

	// Use this for initialization
	void Start () {
		audioSource.clip = audioClip [1];
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		PlaySongs ();
	}

	public void PlaySongs(){
		if (enemyScript.crawlFast && enemyScript.crawl == false && audioSource.clip == 
			audioClip [1] || enemyScript.atack && enemyScript.crawl == false && audioSource.clip == audioClip [1]) 
		{
			audioSource.clip = audioClip [0];
			audioSource.volume = 0.7f;
			audioSource.Play ();
		}
		else if(enemyScript.crawl && audioSource.clip == audioClip [0]) 
		{
			audioSource.clip = audioClip [1];
			audioSource.volume = 1f;
			audioSource.Play ();
		}
	}
}
