using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FSMSimple : MonoBehaviour
{
	//Estados do FMS
	public enum FSMStates
	{
		Waypoints,
		Chasing,
		Atacking,
		Die}
	;
	public FSMStates state = FSMStates.Waypoints;

	//Variáveis Genéricas
	public  GameObject  target;
	public  float 		speed;
	public  float 		rotSpeed;
	private Vector3 	dir;
	private Rigidbody 	rb;

	//Variáveis dos waypoints
	public  Transform[] waypoints;
	public  float 		distanceToChangeWaypoint;
	private int 		currentWaypoint;

	//Variáveis da perseguição
	public float distanceToStartChasing;
	public float distanceToStopChasing;
	public float distanceToAttack;
	public float distanceToReturnChase;

	//Variáveis de animação
	public  Animator 	 animator;
	public  int 	 	 index;
	public  bool 	 	 crawl;
	public  bool 	 	 crawlFast;
	public  bool 	 	 atack;
    public PlayerControl playerControl;

	//Variáveis de som
	public AudioSource audio;
	public AudioClip sound;

	public void Start ()
	{
		crawl = true;
		crawlFast = false;
		atack = false;

		currentWaypoint = 0;
		rb = GetComponent<Rigidbody> ();

		audio = GetComponent<AudioSource> ();
	}
		
	public void FixedUpdate ()
	{
		animator.SetBool ("crawl", crawl);
		animator.SetBool ("crawlFast", crawlFast);
		animator.SetBool ("atack", atack);

		dir = target.transform.position - transform.position;

		switch (state) {
		case FSMStates.Waypoints:
			WaypointState ();
			break;
		case FSMStates.Chasing:
			ChaseState ();
			break;
		case FSMStates.Atacking:
			AtackState ();
			break;

		default:
			print ("BUG: state should never be on default clause");
			break;
		}
	}

	//Waypoints
	private void WaypointState ()
	{
		
		crawl = true;
		crawlFast = false;
		atack = false;

		// Verifica se está na distância para perseguir
        if (dir.magnitude <= distanceToStartChasing && playerControl.safe == false) {
			state = FSMStates.Chasing;
			return;
		}
		// Descobre o caminho para o próximo Waypoint,
		// Gira para a direção dele
		Vector3 wpDir = waypoints [currentWaypoint].position - transform.position;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wpDir), Time.deltaTime * rotSpeed);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		if (wpDir.magnitude <= distanceToChangeWaypoint) {
			currentWaypoint++;
			if (currentWaypoint >= waypoints.Length)
				currentWaypoint = 0;

		} else
            transform.Translate(0, 0, speed * Time.deltaTime);
    }

	//Perseguição
	private void ChaseState ()
	{

		crawl = false;
		crawlFast = true;
		atack = false;

		// Verifica se está na distância para atacar ou se está longe demais para perseguir
		if (dir.magnitude > distanceToStopChasing || playerControl.safe == true) {
			SetClosestWayPoint ();
			state = FSMStates.Waypoints;
			return;
		} else if (dir.magnitude <= distanceToAttack) {
			rb.velocity = Vector3.zero;
			state = FSMStates.Atacking;
		}

		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), Time.deltaTime * rotSpeed);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
        transform.Translate(0, 0, 9 * Time.deltaTime);
	}

	//Ataque
	private void AtackState ()
	{
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), Time.deltaTime * rotSpeed);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

		if(audio)
		if(!audio.isPlaying) audio.PlayOneShot (sound, 0.6f);

		if (dir.magnitude < distanceToAttack) {
			crawl = false;
			crawlFast = false;
			atack = true;
		} else if (dir.magnitude > distanceToAttack && dir.magnitude <= distanceToReturnChase)
			state = FSMStates.Chasing;
		else if (dir.magnitude > distanceToReturnChase) {
			SetClosestWayPoint ();
			state = FSMStates.Waypoints;
		}
	}

	//Procurar o waypoint mais próximo
	private void SetClosestWayPoint ()
	{
		float dist = 100000;
		int current = 0;
		for (int i = 0; i < waypoints.Length; i++) {
			float d = Vector3.Distance (transform.position, waypoints [i].position);
			if (d < dist) {
				dist = d;
				current = i;
			}
		}

		currentWaypoint = current;
	}

}