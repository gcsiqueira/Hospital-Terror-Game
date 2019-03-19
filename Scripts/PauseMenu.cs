using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

	private bool 		  gamePaused;
	private float 		  originalFixedTime;
	public  GameObject    pausePanel;
	public  GameObject    controlePanel;
	public  Animator 	  bicho;
    public  FSMSimple 	  fsm;
	public  SoundControl  soundControl;
	public  PlayerControl playerControl;
	public  RealTime1     quickTime;

	public  FirstPersonController firstPeson;

	public void PauseGame(){

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		pausePanel.SetActive(true);

		//Pausa o que o unity conseguir pausar sozinho
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;

		//Pausa o que Unity não consegue pausar sozinho
		bicho.enabled = false;
		fsm.enabled = false;
		firstPeson.enabled = false;
		soundControl.audioSource.Pause ();
		quickTime.podeAparecer = false;
		quickTime.podeApertar = false;
		gamePaused = true;
	}
		

	public void UnPauseGame(){
		pausePanel.SetActive(false);

        Time.timeScale = 1;
		Time.fixedDeltaTime = originalFixedTime;

		gamePaused = false;
		bicho.enabled = true;
		fsm.enabled = true;
		soundControl.audioSource.UnPause ();
		quickTime.podeAparecer = true;
		quickTime.podeApertar = true;

		if (playerControl.estaLendo) {
			firstPeson.enabled = false;
			Cursor.visible = true;
		} else {
			firstPeson.enabled = true;
			Cursor.visible = false;
		}
	}
		
	public void ResetGame(){
		UnPauseGame();
		SceneManager.LoadScene("C1");
	}

    public void Return()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = originalFixedTime;
        SceneManager.LoadScene("Menu");
    }

	public void Controles()
	{
		controlePanel.SetActive (true);
	}

	public void SairControles()
	{
		controlePanel.SetActive (false);
	}
		
    public void QuitGame(){
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
		gamePaused = false;
		originalFixedTime = Time.fixedDeltaTime;
		pausePanel.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape)) {
			gamePaused = !gamePaused;
			if(gamePaused) 
			{
				PauseGame();
			} else
			{
				UnPauseGame();
			}
	}
}
}
