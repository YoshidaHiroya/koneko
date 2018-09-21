using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour {

	public GameObject arrowPrefab;
	float span=1.0f;
	float delta=0;
	
	// Update is called once per frame
	void Update () {


		/*delta += Time.deltaTime;
		if (delta > span) {
			delta = 0;
			GameObject go = Instantiate (arrowPrefab) as GameObject;
			if (transform.position.y > 7.0f) {
				Destroy (go);
			}
*/			//int px = Random.Range (-3, 4);
			//	go.transform.position=new Vector3(px,7,0);
		}

	}
