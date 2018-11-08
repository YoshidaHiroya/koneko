using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kodomonokoriScript : MonoBehaviour {
	Text text;
	public int count;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 1) {
			this.text.text = "×1";
		}
		if (count == 2) {
			this.text.text = "×2";
		}if (count == 3) {
			this.text.text = "×3";
		}if (count == 4) {
			this.text.text = "×4";
		}
	}

}
