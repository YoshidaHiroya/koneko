using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {
	GameObject player;
	GameObject enemy;
	GameObject arrow;
	public GameObject explosionPrefab;   //爆発エフェクトのPrefab

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		enemy = GameObject.Find ("enemy");

	}
	// Update is called once per frame
 		void Update () {
		
		if (transform.position.y > 30.0f||transform.position.x > 30.0f) {
			Destroy (gameObject);
		}
	}
	    void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "enemy") {
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);

		}
}



}





		


