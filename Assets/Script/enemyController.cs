using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	GameObject player;
	GameObject enemy;
	public GameObject gemPrefab;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		enemy = GameObject.Find ("enemy");

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.01f,0,0);
	}
	void OnTriggerEnter2D(Collider2D col) {
		Destroy (gameObject);
		Debug.Log ("あたり");
		/*if (col.gameObject.tag == "Shot") {
			
			var gem = Instantiate (
				         gemPrefab, transform.localPosition, Quaternion.identity);
		}*/
		GameObject director = GameObject.Find ("GameDirector");

	if(col.gameObject.tag=="Player"){
			director.GetComponent<GameDirector>().DecreaseHP();
		}
		player.GetComponent<AudioSource> ().Play();
	}
}

