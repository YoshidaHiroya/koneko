using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameDirector : MonoBehaviour {

	GameObject hpGauge;
	// Use this for initialization
	void Start () {
		hpGauge = GameObject.Find ("Image");
	}
	
	public void DecreaseHP(){
		this.hpGauge.GetComponent<Image> ().fillAmount -= 0.1f;
		if (this.hpGauge.GetComponent<Image> ().fillAmount == 0) {
			SceneManager.LoadScene ("GameOverScene");
		}
	}

}
