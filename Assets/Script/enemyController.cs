using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	GameObject player;
	GameObject enemy;
	GameObject boss;
	public GameObject gemPrefab;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		enemy = GameObject.Find ("enemy");
		boss = GameObject.Find ("Boss");
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
			Debug.Log ("ぷれいやー");
			director.GetComponent<GameDirector>().DecreaseHP();
		}
		if (col.gameObject.tag == "Boss") {
			Debug.Log ("ぼす");
			boss.GetComponent<BossController>().Hp-=-1; 

		}


		//player.GetComponent<AudioSource> ().Play();
	}
}

