using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,-0.1f,0);
	}

	private void OnTriggerEnter2D( Collider2D collision )
	{
		GameObject director = GameObject.Find ("GameDirector");

		// 弾と衝突した場合
		if ( collision.name.Contains( "player" ) )
		{
			director.GetComponent<GameDirector> ().DecreaseHP ();
			Destroy (gameObject);
		}




}
}