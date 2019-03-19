using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShock : MonoBehaviour {

	public bool funcionou;
	private string certo;
	public string tentCerto;

	public string tentA;
	public string tentB;
	public string tentC;

	public string saveA;
	public string saveB;
	public string saveC;

	public GameObject choqueEletrico;

	// Use this for initialization
	void Start () {
		
		//variável com o codigo correto
		certo = "abc";

		//variáveis com valor fixos
		tentA = "a";
		tentB = "b";
		tentC = "c";

		//variáveis com valor mutável
		saveA = "n";
		saveB = "n";
		saveC = "n";

		funcionou = false;
	}
	
	// Update is called once per frame
	void Update () {

		tentCerto = string.Concat (saveA, saveB, saveC);

        if (tentCerto == certo)
        {
			choqueEletrico.SetActive(false);
            funcionou = true;
        }
        else
            funcionou = false;
	}
}
