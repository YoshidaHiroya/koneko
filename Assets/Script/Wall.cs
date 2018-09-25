using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	public AudioClip Clip;
	public GameObject m_explosionPrefab;
	float x;
	float y;
	float z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.1f,0,0);
		x += 75 * Time.deltaTime;
		y = 0;
		z =0;
		transform.rotation = Quaternion.Euler (x, y, z);
	}
	private void OnTriggerEnter2D( Collider2D collision )
	{
		// 弾と衝突した場合
		if ( collision.name.Contains( "Shot" ) )
		{

			Debug.Log ("かべ！");
			Instantiate( 
				m_explosionPrefab, 
				collision.transform.localPosition, 
				Quaternion.identity );
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot(Clip);
			Destroy (gameObject);
			Destroy (collision.gameObject);
		}

}
}
