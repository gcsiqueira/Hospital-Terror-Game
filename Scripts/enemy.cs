using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour {

    public int HP;

	// Use this for initialization
	void Start () {
        HP = 180;
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0) 
		{
			SceneManager.LoadScene ("Creditos");
		}
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("explosive"))
        {
            HP -= 60;
        }
    }
}
