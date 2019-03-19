using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerControl : MonoBehaviour {

    private bool painelEletricoPortas;
	private bool entrouPortaWaterGun;
	private bool painelPuzzleEletrico_1;
	private bool painelPuzzleEletrico_2;
	private bool painelPuzzleEletrico_3;
	private bool keyCard;
	public 	bool safe;
    public 	bool WaterGun;
    public 	bool isWatering;
    public 	bool FlameT;
    public 	bool isFlaming;
    public 	bool isBomb;
	public  bool isBombEquiped;
	public  bool podeApertarE;
	public  bool estaLendo;

	private int qtdFlame;
	private int qtdWater;
    private int count;
	private int qtdBombs;

	public  FirstPersonController firstPeson;
	public  SoundControl 		  soundControl;

	public  AudioSource  crawlerAudio;
	public  AudioSource  playerAudio;
	public  AudioClip    flameTSom;
	public  AudioClip    waterSom;
	public  AudioClip 	 grenadeSom;

	public 	GameObject   canvas;
	public 	GameObject   painelWeapons;
    public 	GameObject   waterGun;
    public 	GameObject   flameT;
    public 	GameObject   water;
    public 	GameObject   chama;
    public 	GameObject   Bomba;
	public  GameObject[] paineisChoqueEletrico;
	public  GameObject 	 morte;
	public  GameObject   GrenadeGun;

	//textos e mensagens
	public  GameObject 	 pressE;
	public  GameObject   needKey;
	public  GameObject   canFlame;
	public  GameObject   gotWaterGun;
	public  GameObject   gotFlameT;
	public  GameObject   gotGranadas;
	public  GameObject   painelPaper;

	//granada
    public 	Rigidbody bomb;
    public 	Transform muzzle;
    public 	int 	  force;

    public 	Animator anim;

	//acessos a outros scripts
	public 	ControlShock control;
    public 	RealTime1 	 real;
	public  box 		 boxScript;

	// Use this for initialization
	void Start () 
	{
		painelEletricoPortas = false;
		entrouPortaWaterGun  = false;
		WaterGun 			 = false;
        isWatering 			 = false;
		isBomb 				 = false;
		isBombEquiped        = false;
		podeApertarE 		 = false;
        Cursor.visible 		 = false;
		estaLendo 			 = false;
		morte.SetActive       (false);
		pressE.SetActive      (false);
		canFlame.SetActive 	  (false);
		painelPaper.SetActive (false);

		qtdFlame = 100;
		qtdWater = 300;
	}
	
	// Update is called once per frame
	void Update () 
	{
        TestaPuzzleEletrico ();
		Interagir ();
        Weapon ();
    }

    public void Weapon()
    {
		//WaterGun
		if (Input.GetKeyDown("1") && WaterGun && isWatering == false && isFlaming == false && isBombEquiped == false)
        {
            isWatering = true;
			waterGun.SetActive (true);
        }
		else if(Input.GetKeyDown("1") && WaterGun && isWatering == false && isBombEquiped == false && isFlaming)
		{
			//Para as chamas
			chama.SetActive(false);
			flameT.SetActive (false);
			playerAudio.Stop ();
			isFlaming = false;
			qtdFlame = 100;

			//Inicia a água
			isWatering = true;
			waterGun.SetActive (true);
		}
		else if(Input.GetKeyDown("1") && WaterGun && isWatering == false && isFlaming == false && isBombEquiped)
		{
			//Para a GrenadeGun
			isBombEquiped = false;
			GrenadeGun.SetActive (false);
			qtdBombs = 0;

			//Inicia a água
			isWatering = true;
			waterGun.SetActive (true);
		}
        else if (Input.GetKeyDown("1") && WaterGun && isWatering == true)
        {
			water.SetActive(false);
			playerAudio.Stop ();
            isWatering = false;
			waterGun.SetActive (false);
			qtdWater = 300;
        }


		//FlameGun
		if (Input.GetKeyDown("2") && FlameT && isFlaming == false && isWatering == false && isBombEquiped == false)
        {
            isFlaming = true;
			flameT.SetActive (true);
        }
		else if(Input.GetKeyDown("2") && FlameT && isFlaming == false && isBombEquiped == false && isWatering)
		{
			//Para a água
			water.SetActive(false);
			waterGun.SetActive (false);
			playerAudio.Stop ();
			isWatering = false;
			qtdWater = 300;

			//Inicia as chamas
			isFlaming = true;
			flameT.SetActive (true);
		}
		else if(Input.GetKeyDown("2") && FlameT && isFlaming == false && isWatering == false && isBombEquiped)
		{
			//Para a GrenadeGun
			isBombEquiped = false;
			GrenadeGun.SetActive (false);
			qtdBombs = 0;

			//Inicia as chamas
			isFlaming = true;
			flameT.SetActive (true);
		}
        else if (Input.GetKeyDown("2") && FlameT && isFlaming == true)
        {
			chama.SetActive(false);
			playerAudio.Stop ();
            isFlaming = false;
			flameT.SetActive (false);
			qtdFlame = 100;
        }

		//Equipar GrenadeGun
		if (Input.GetKeyDown("3") && isBomb && isBombEquiped == false && isFlaming == false && isWatering == false)
		{
			isBombEquiped = true;
			GrenadeGun.SetActive (true);
		}
		else if(Input.GetKeyDown("3") && isBomb && isBombEquiped == false && isFlaming == false && isWatering)
		{
			//Para a água
			water.SetActive(false);
			waterGun.SetActive (false);
			playerAudio.Stop ();
			isWatering = false;
			qtdWater = 300;

			//Inicia a Grenade
			isBombEquiped = true;
			GrenadeGun.SetActive (true);
		}
		else if(Input.GetKeyDown("3") && isBomb && isBombEquiped == false && isWatering == false && isFlaming)
		{
			//Para as chamas
			chama.SetActive(false);
			playerAudio.Stop ();
			isFlaming = false;
			flameT.SetActive (false);
			qtdFlame = 100;

			//Inicia a Grenade
			isBombEquiped = true;
			GrenadeGun.SetActive (true);
		}
		else if (Input.GetKeyDown("3") && isBomb && isBombEquiped)
		{
			isBombEquiped = false;
			GrenadeGun.SetActive (false);
			qtdBombs = 0;
		}



		//Disparar Bombas
        if (Input.GetMouseButtonDown(0) && isBombEquiped && qtdBombs == 0)
        {
			qtdBombs++;
            Rigidbody b = GameObject.Instantiate(bomb, muzzle.position, muzzle.rotation) as Rigidbody;
            b.AddForce(force * muzzle.up);
			playerAudio.PlayOneShot (grenadeSom, 1F);
			StartCoroutine ("TimeBomb");
        }

		//Disparar Lança Chamas
		if (Input.GetMouseButton (0) && isFlaming) {
			qtdFlame--;
			if (qtdFlame >= 0) {
				chama.SetActive (true);
				if (!playerAudio.isPlaying) {
					playerAudio.clip = flameTSom;
					playerAudio.Play ();
				} else {
				}
			} else {
				chama.SetActive (false);
				playerAudio.Stop ();
			}
		} else if(Input.GetMouseButtonUp (0) && isFlaming) {
			chama.SetActive (false);
			qtdFlame = 100;
			playerAudio.Stop ();
		}

		//Disparar Arma de água
		if (Input.GetMouseButton(0) && isWatering) {
			qtdWater--;
			if (qtdWater >= 0) {
				water.SetActive(true);
				if (!playerAudio.isPlaying) {
					playerAudio.clip = waterSom;
					playerAudio.Play ();
				} else {
				}
			} else {
				water.SetActive(false);
				playerAudio.Stop ();
			}
		} else if(Input.GetMouseButtonUp (0) && isWatering) {
			water.SetActive(false);
			playerAudio.Stop ();
			qtdWater = 300;
		}


		if (Input.GetMouseButton (1))
			painelWeapons.SetActive (true);
		else
			painelWeapons.SetActive (false);
    }

    public void TestaPuzzleEletrico()
    {
		//Ele salva a ordem em que o player apertou cada painel pelo valor da variavel count
		//Se a ordem salva for igual a correta no script ControlShock, então o padrão eletrico desativará

		//Primeiro painel elétrico///////////////////////////////////////
		if (painelPuzzleEletrico_1 && Input.GetKeyDown("e") && count == 0)
        {
            control.saveA = control.tentA;
            count++;
			paineisChoqueEletrico [0].SetActive (true);
        }
		else if (painelPuzzleEletrico_1 && Input.GetKeyDown("e") && count == 1)
        {
            control.saveA = control.tentB;
            count++;
			paineisChoqueEletrico [0].SetActive (true);
        }
		else if (painelPuzzleEletrico_1 && Input.GetKeyDown("e") && count == 2)
        {
            control.saveA = control.tentC;
            count++;
			paineisChoqueEletrico [0].SetActive (true);
        }

		else if (count == 3)
        {
            count++;
        }


		//Segundo painel elétrico////////////////////////////////////////
		if (painelPuzzleEletrico_2 && Input.GetKeyDown("e") && count == 0)
        {
            control.saveB = control.tentA;
            count++;
			paineisChoqueEletrico [1].SetActive (true);
        }
		else if (painelPuzzleEletrico_2 && Input.GetKeyDown("e") && count == 1)
        {
            control.saveB = control.tentB;
            count++;
			paineisChoqueEletrico [1].SetActive (true);
        }
		else if (painelPuzzleEletrico_2 && Input.GetKeyDown("e") && count == 2)
        {
            control.saveB = control.tentC;
            count++;
			paineisChoqueEletrico [1].SetActive (true);
        }
		else if (count == 3)
        {
            count++;
        }


		//Terceiro painel elétrico///////////////////////////////////////
		if (painelPuzzleEletrico_3 && Input.GetKeyDown("e") && count == 0)
        {
            control.saveC = control.tentA;
            count++;
			paineisChoqueEletrico [2].SetActive (true);
        }
		else if (painelPuzzleEletrico_3 && Input.GetKeyDown("e") && count == 1)
        {
            control.saveC = control.tentB;
            count++;
			paineisChoqueEletrico [2].SetActive (true);
        }
		else if (painelPuzzleEletrico_3 && Input.GetKeyDown("e") && count == 2)
        {
            control.saveC = control.tentC;
            count++;
			paineisChoqueEletrico [2].SetActive (true);
        }
		else if (count == 3)
        {
        	count++;
        }

		//Teste de verificação dos painéis//////////////////////////////////
        if (control.funcionou == false && count > 3)
        {
            control.saveA = "n";
            control.saveB = "n";
            control.saveC = "n";
			paineisChoqueEletrico [0].SetActive (false);
			paineisChoqueEletrico [1].SetActive (false);
			paineisChoqueEletrico [2].SetActive (false);
            count = 0;
        }
    }

	//Colliders e Triggers
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("eletro"))
        {
			painelEletricoPortas = true;
			pressE.SetActive (true);
        }
		if (hit.gameObject.CompareTag("Paper"))
		{
			podeApertarE = true;
			pressE.SetActive (true);
		}

		if (hit.gameObject.CompareTag("Box") && boxScript.existe == true)
		{
			canFlame.SetActive (true);
		}

		if (hit.gameObject.CompareTag("porta"))
		{
			entrouPortaWaterGun = true;
			if (keyCard) {
				pressE.SetActive (true);
				needKey.SetActive (false);
			} else {
				needKey.SetActive (true);
				pressE.SetActive (false);
			}
		}

		if (hit.gameObject.CompareTag("1"))
		{
			painelPuzzleEletrico_1 = true;
			pressE.SetActive (true);
		}

		if (hit.gameObject.CompareTag("2"))
		{
			painelPuzzleEletrico_2 = true;
			pressE.SetActive (true);
		}

		if (hit.gameObject.CompareTag("3"))
		{
			painelPuzzleEletrico_3 = true;
			pressE.SetActive (true);
		}

        if (hit.gameObject.CompareTag("SAFE"))
        {
            safe = true;
        }
    }

    public void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.CompareTag("eletro"))
        {
			painelEletricoPortas = false;
			pressE.SetActive (false);
        }

		if (hit.gameObject.CompareTag("Paper"))
		{
			podeApertarE = false;
			pressE.SetActive (false);
		}

		if (hit.gameObject.CompareTag("Box"))
		{
			canFlame.SetActive (false);
		}

		if (hit.gameObject.CompareTag("porta"))
		{
			entrouPortaWaterGun = false;
			needKey.SetActive (false);
			pressE.SetActive (false);
		}

		if (hit.gameObject.CompareTag("1"))
		{
			painelPuzzleEletrico_1 = false;
			pressE.SetActive (false);

		}

		if (hit.gameObject.CompareTag("2"))
		{
			painelPuzzleEletrico_2 = false;
			pressE.SetActive (false);

		}

		if (hit.gameObject.CompareTag("3"))
		{
			painelPuzzleEletrico_3 = false;
			pressE.SetActive (false);
		}

        if (hit.gameObject.CompareTag("SAFE"))
        {
            safe = false;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("shockwave"))
        {
			Morreu ();;
        }

        if (hit.gameObject.CompareTag("fogo"))
        {
			Morreu ();
        }

        if (hit.gameObject.CompareTag("keyCard"))
        {
            keyCard = true;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.CompareTag("WaterGun"))
        {
			gotWaterGun.SetActive (true);
			estaLendo = true;
			firstPeson.enabled = false;
			Cursor.visible = true;
            WaterGun = true;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.CompareTag("flameT"))
        {
			gotFlameT.SetActive (true);
			estaLendo = true;
			firstPeson.enabled = false;
			Cursor.visible = true;
            FlameT = true;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.CompareTag("enemy"))
        {
			Morreu ();
        }

        if (hit.gameObject.CompareTag("Bomb"))
        {
			gotGranadas.SetActive (true);
			estaLendo = true;
			firstPeson.enabled = false;
			Cursor.visible = true;
            isBomb = true;
            Destroy(hit.gameObject);
        }
    }

	public void Interagir(){
		
		//Interação com o papel do painel
		if (podeApertarE && Input.GetKeyDown ("e")) {
			painelPaper.SetActive (true);
			estaLendo = true;
			Cursor.visible = true;
			firstPeson.enabled = false;
		}
			

		//Interação com painéis elétricos
		if (painelEletricoPortas && Input.GetKeyDown("e"))
		{
			real.enabled = true;
			canvas.SetActive(true);
			pressE.SetActive (false);
		}

		if (painelEletricoPortas==false)
		{
			real.TestaErro ();
			real.enabled = false;
		}

		//Interação com a Porta da sala da watergun
		if(entrouPortaWaterGun && keyCard == true &&Input.GetKeyDown("e"))
		{
			anim.enabled = true;
			keyCard = false;
		}
	}

	public void Morreu(){
		morte.SetActive (true); 				//Painel de morte
		Cursor.visible = true;  				
		firstPeson.enabled = false; 			
		real.TestaErro ();         			 	//Reseta o quick action puzzle
		real.enabled = false;					//Desabilita o quick action puzzle
		soundControl.audioSource.volume = 0;    //Abaixa o volume da musica de fundo
		if (crawlerAudio.isPlaying){			//Examina se esta tocando o som do monstro
			crawlerAudio.Stop();				//Para o audio atual do montro
			crawlerAudio.Play ();				//Toca o som do monstro uma unica vez
			StartCoroutine ("CrawlerSound");
		}else{
			crawlerAudio.Play();
			StartCoroutine ("CrawlerSound");
		}
	}

	//Coroutines/////////////////////////////////////////////////
	IEnumerator TimeBomb(){
		yield return new WaitForSecondsRealtime (1);
		qtdBombs = 0;
	}

	IEnumerator CrawlerSound(){
		yield return new WaitForSecondsRealtime (2);
		crawlerAudio.enabled = false;
	}
}
