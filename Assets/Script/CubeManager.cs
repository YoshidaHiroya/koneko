using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {
	public GameObject CubePrefab;
	float x;
	float y;
	float z;
	float timeleft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.1f,0,0);
		//だいたい1秒ごとに処理を行う
		timeleft -= Time.deltaTime;
		if (timeleft <= 0.0) {
			timeleft =0.5f;
			Instantiate (CubePrefab, transform.position, Quaternion.Euler (0, 0, -90));

		}
		for (int i = 0; i < 36; i++) {
		/*Instantiate( 
			CubePrefab, 
			new Vector3 (0, 0, this.transform.position.z), Quaternion.Euler (0, 90 + i * 10, 45) );*/
			x += 75 * Time.deltaTime;
			y += 30 * Time.deltaTime;
			z -= 25 * Time.deltaTime;
			transform.rotation = Quaternion.Euler (x, y, z);
	}
}
}
