using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public AudioSource audioS;
	public AudioSource audioMenu;
	public AudioClip audioC;

	void Start(){
		Cursor.visible = true;
	}

	public void GoNewGame(){
		audioMenu.Stop ();
		audioS.PlayOneShot (audioC, 1F);
		SceneManager.LoadScene ("C1");
	}

	public void GoCreditos(){
		SceneManager.LoadScene ("Creditos");
	}

	public void GoMenu(){
		SceneManager.LoadScene ("Menu");
	}

	public void Exit(){
		Application.Quit();
	}
}
