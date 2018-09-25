using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	GameObject player;
	public AudioClip PowerUp;
	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {


	}
	void OnTriggerEnter2D(Collider2D col) {



			if ( col.gameObject.tag == "Player")
			{
				Destroy (gameObject);
				Debug.Log ("ぱわーあっぷ");
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot (PowerUp);
			player.GetComponent<PlayerController>().m_shotCount+=1;
			}	
		}
	}
