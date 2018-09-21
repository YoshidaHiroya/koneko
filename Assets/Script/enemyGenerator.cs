using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour {

	public GameObject enemyPrefab;
	float span=2.0f;
	float delta=0;

	// Update is called once per frame
	void Update () {


		delta += Time.deltaTime;
		if (delta > span) {
			delta = 0;
			GameObject go = Instantiate (enemyPrefab) as GameObject;
			int px = Random.Range (-3, 10);
			int py = Random.Range (-3, 3);
			go.transform.position = new Vector3 (px, py, 0);
		}

	}

}
