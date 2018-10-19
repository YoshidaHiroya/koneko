using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour {
	GameObject score;
	Text text;
	// Use this for initialization
	void Start () {
		var i =PlayerPrefs.GetInt("highscore",1);
		score = GameObject.Find ("SCORE");
		text = score.GetComponent<Text> ();
		text.text = "SCORE:"+(i.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
