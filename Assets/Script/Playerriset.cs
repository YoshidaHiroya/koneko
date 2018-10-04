using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerriset : MonoBehaviour {
	public int score;
	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("highscore", score);
		PlayerPrefs.Save ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
