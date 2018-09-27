using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	public int score;
	public Text text;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		text.text = "0"; 
		score = PlayerPrefs.GetInt ("highscore", score);
		text.text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = score.ToString (); 
		PlayerPrefs.SetInt ("highscore", score);
		PlayerPrefs.Save (); 
	}
}
