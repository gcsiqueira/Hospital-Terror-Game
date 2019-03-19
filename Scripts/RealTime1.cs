using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RealTime1 : MonoBehaviour {

    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;
	public GameObject canvas;

    public Image fill;

    public int chanceButton;
    public bool duvida;

    public bool apareceuW;
    public bool apareceuA;
    public bool apareceuS;
    public bool apareceuD;

    public bool podeApertar;
    public bool podeAparecer;

    private int tempo1;
    private int tempo2;
    private int count;


	public Animator[] anim;


    // Use this for initialization
    void Start () {

        tempo1 = 0;
        tempo2 = 0;

        duvida = true;

        podeApertar = false;
        podeAparecer = true;

        fill.enabled = false;

        apareceuW = false;
        apareceuA = false;
        apareceuS = false;
        apareceuD = false;
	}
	
	// Update is called once per frame
	void Update () {

        TestaLetra();
        TestaTecla();
        TestaTempo();
		AcertouTodas();
   
    }


    public void TestaTecla()
    {
        if (podeApertar)
        {
            if (Input.GetKeyDown("1") && apareceuW)
            {
                count++;
                TestaAcerto();
            }
            else if (Input.GetKeyDown("1") && apareceuW == false)
            {
                TestaErro();
            }
				
            if (Input.GetKeyDown("2") && apareceuA)
            {
                count++;
                TestaAcerto();
            }
            else if (Input.GetKeyDown("2") && apareceuA == false)
            {
                TestaErro();
            }
				
            if (Input.GetKeyDown("3") && apareceuS)
            {
                count++;
                TestaAcerto();
            }
            else if (Input.GetKeyDown("3") && apareceuS == false)
            {
                TestaErro();
            }
				
            if (Input.GetKeyDown("4") && apareceuD)
            {
                count++;
                TestaAcerto();
            }
            else if (Input.GetKeyDown("4") && apareceuD == false)
            {
                TestaErro();
            }
        }
    }

    public void TestaLetra()
    {
        if (duvida)
        {
            tempo2 = 0;
            chanceButton = UnityEngine.Random.Range(0, 4);
        }
           

        if (chanceButton == 0 && podeAparecer)
        {
            duvida = false;

            podeApertar = true;

            fill.enabled = true;

            apareceuW = true;
            apareceuA = false;
            apareceuS = false;
            apareceuD = false;

            w.SetActive(true);
            a.SetActive(false);
            s.SetActive(false);
            d.SetActive(false);

            tempo1++;
             if (tempo1 == 60)
             {
                 fill.fillAmount -= 0.2f;
                 tempo2++;
                 tempo1 = 0;
             }
        }

        else if (chanceButton == 1 && podeAparecer)
        {
            duvida = false;

            podeApertar = true;

            fill.enabled = true;

            apareceuW = false;
            apareceuA = true;
            apareceuS = false;
            apareceuD = false;

            w.SetActive(false);
            a.SetActive(true);
            s.SetActive(false);
            d.SetActive(false);

            tempo1++;
            if (tempo1 == 60)
            {
                fill.fillAmount -= 0.2f;
                tempo2++;
                tempo1 = 0;
            }
        }

        else if (chanceButton == 2 && podeAparecer)
        {
            duvida = false;

            podeApertar = true;

            fill.enabled = true;

            apareceuW = false;
            apareceuA = false;
            apareceuS = true;
            apareceuD = false;

            w.SetActive(false);
            a.SetActive(false);
            s.SetActive(true);
            d.SetActive(false);

            tempo1++;
            if (tempo1 == 60)
            {
                fill.fillAmount -= 0.2f;
                tempo2++;
                tempo1 = 0;
            }
        }

        else if (chanceButton == 3 && podeAparecer)
        {
            duvida = false;

            podeApertar = true;

            fill.enabled = true;

            apareceuW = false;
            apareceuA = false;
            apareceuS = false;
            apareceuD = true;

            w.SetActive(false);
            a.SetActive(false);
            s.SetActive(false);
            d.SetActive(true);

            tempo1++;
            if (tempo1 == 60)
            {
                fill.fillAmount -= 0.2f;
                tempo2++;
                tempo1 = 0;
            }
        }
    }

    public void TestaTempo()
    {
        if (tempo2 >= 5)
        {
            TestaErro();
        }
            
    }

    public void TestaErro()
    {
        apareceuW = false;
        apareceuA = false;
        apareceuS = false;
        apareceuD = false;

        fill.enabled = false;

        w.SetActive(false);
        a.SetActive(false);
        s.SetActive(false);
        d.SetActive(false);

        fill.fillAmount = 1f;
        tempo1 = 0;
        count = 0;
        duvida = true;
        canvas.SetActive(false);
        this.enabled = false;
    }

    public void TestaAcerto()
    {

        podeAparecer = false;

        apareceuW = false;
        apareceuA = false;
        apareceuS = false;
        apareceuD = false;

        fill.enabled = false;

        w.SetActive(false);
        a.SetActive(false);
        s.SetActive(false);
        d.SetActive(false);  

        fill.fillAmount = 1f;
        tempo1 = 0;

        StartCoroutine(NextRoutine(UnityEngine.Random.Range(1, 3))); 
        
    }

    public IEnumerator NextRoutine(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        
        duvida = true;
        podeAparecer = true;
    }

	public void AcertouTodas(){

		if (count >= 4) {
			anim [0].enabled = true;
			anim [1].enabled = true;
			anim [2].enabled = true;
			anim [3].enabled = true;

			apareceuW = false;
			apareceuA = false;
			apareceuS = false;
			apareceuD = false;

			fill.enabled = false;

			w.SetActive(false);
			a.SetActive(false);
			s.SetActive(false);
			d.SetActive(false);

			fill.fillAmount = 1f;
			tempo1 = 0;
			count = 0;
			duvida = true;
			canvas.SetActive (false);
            this.enabled = false;
		}


	}

}
