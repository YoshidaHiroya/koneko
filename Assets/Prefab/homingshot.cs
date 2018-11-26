using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingshot: MonoBehaviour {
	float speed = 13;
	GameObject target;
	public GameObject homingSound;
	public GameObject effect;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("enemy");
		Destroy (this.gameObject, 2);
	}

	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.8f);
		} else {
			target = GameObject.FindGameObjectWithTag ("Enemy");
		}
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			Destroy (this.gameObject);
			GameObject soundClone = Instantiate (homingSound);
			Destroy (soundClone, 1);
			Instantiate (effect, transform.position, Quaternion.identity);
		} 	
		if (col.gameObject.tag == "wall") {
			Destroy (this.gameObject);
		} 	
	}

}
