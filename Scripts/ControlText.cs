using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ControlText : MonoBehaviour {

	public FirstPersonController firstPeson;
	public PlayerControl playerC;
	public GameObject[] textos;

	public void SaiTexto_1(){
		firstPeson.enabled = true;
		playerC.estaLendo = false;
		Cursor.visible = false;
		textos [0].SetActive (false);
	}

	public void SaiTexto_2(){
		firstPeson.enabled = true;
		playerC.estaLendo = false;
		Cursor.visible = false;
		textos [1].SetActive (false);
	}

	public void SaiTexto_3(){
		firstPeson.enabled = true;
		playerC.estaLendo = false;
		Cursor.visible = false;
		textos [2].SetActive (false);
	}

	public void SaiTexto_4(){
		firstPeson.enabled = true;
		playerC.estaLendo = false;
		Cursor.visible = false;
		textos [3].SetActive (false);
	}

	public void FimDeJogo(){
		SceneManager.LoadScene("C1");
	}
}
