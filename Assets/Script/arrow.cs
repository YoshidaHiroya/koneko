﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
	public AudioClip m_damageClip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,-0.1f,0);
		if(transform.position.x<-50){
		Destroy (gameObject);
	}
	}

	private void OnTriggerEnter2D( Collider2D collision )
	{
		GameObject director = GameObject.Find ("GameDirector");

		// 弾と衝突した場合
		if ( collision.name.Contains( "player" ) )
		{
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_damageClip );
			director.GetComponent<GameDirector> ().DecreaseHP ();
			Destroy (gameObject);
		}




}
}