using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (3.0f, 0, 0) * Time.deltaTime;
	}
}