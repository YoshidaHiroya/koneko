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
		transform.Translate (0, -0.1f, 0);
		if (transform.position.y > 30.0f||transform.position.x > 30.0f) {
			Destroy (gameObject);
		}
	}
	    void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "enemy") {
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);

		}

/*		Vector2 p1 = enemy.transform.position;
		Vector2 p2 = this.player.transform.position;
		Vector2 dir = p1 - p2;
		float d = dir.magnitude;
		float r1 = 1.0f;
		float r2 = 1.0f;

		if (d < r1 + r2) {
			Destroy (enemy);

			GameObject director = GameObject.Find ("GameDirector");
			director.GetComponent<GameDirector>().DecreaseHP();
*/
}



}





		


