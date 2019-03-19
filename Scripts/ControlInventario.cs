using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlInventario : MonoBehaviour {

	public Image slot_1;
	public Image slot_2;
	public Image slot_3;

	public Sprite weapon1_Unable;
	public Sprite weapon1_Inactive;
	public Sprite weapon1_Active;

	public Sprite weapon2_Unable;
	public Sprite weapon2_Inactive;
	public Sprite weapon2_Active;

	public Sprite weapon3_Unable;
	public Sprite weapon3_Inactive;
	public Sprite weapon3_Active;

	public PlayerControl pcScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Agua
		if (pcScript.WaterGun && pcScript.isWatering == false)
			slot_1.sprite = weapon1_Inactive;
		else if (pcScript.isWatering)
			slot_1.sprite = weapon1_Active;
		else
			slot_1.sprite = weapon1_Unable;

		//Fogo
		if (pcScript.FlameT && pcScript.isFlaming == false)
			slot_2.sprite = weapon2_Inactive;
		else if (pcScript.isFlaming)
			slot_2.sprite = weapon2_Active;
		else
			slot_2.sprite = weapon2_Unable;

		//Bomba
		if (pcScript.isBomb && pcScript.isBombEquiped == false)
			slot_3.sprite = weapon3_Inactive;
		else if (pcScript.isBombEquiped)
			slot_3.sprite = weapon3_Active;
		else
			slot_3.sprite = weapon3_Unable;

	}
}
