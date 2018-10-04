using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossController : MonoBehaviour {
	public GameObject arrowPrefab;
	public GameObject PowerupPrefab;
	public AudioClip boyon;
	public AudioSource aS;
	public float m_speed; 
	public int Hp;
	GameObject boss;
	GameObject player;
	public AudioClip m_damageClip;
	GameObject score;
	private float timeleft;
	float rot;
	float x;
	float y;
	float z;



	void start(){
		player = GameObject.Find ("player");
		score=GameObject.Find ("Score");
	}


	void Update (){
		transform.rotation = Quaternion.Euler (0,0,rot);
		rot += 0.001f * Time.deltaTime;
		//だいたい1秒ごとに処理を行う
		timeleft -= Time.deltaTime;
		if (timeleft <= 0.0) {
			timeleft = 1.0f;

			Instantiate (arrowPrefab, transform.position, Quaternion.Euler (0, 0, -90));
				
		}
			Vector3 playerPos = this.player.transform.position;
			transform.position = new Vector3 (playerPos.x, playerPos.y, transform.position.z);









		}





	private void OnTriggerEnter2D( Collider2D collision )
	{
		Debug.Log ("あたり！");
		// 弾と衝突した場合
		if ( collision.name.Contains( "Shot" ))
			{
				Hp-=1;// 弾を削除する
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_damageClip );
				Destroy( collision.gameObject );
			}
			if(Hp==0){
			// 敵を削除する
			Destroy( gameObject );
			score.GetComponent<Score> ().score += 1000;
			GameObject go =Instantiate (PowerupPrefab, transform.position, Quaternion.Euler(0, 0, 0));	
				}
			
	
}
	

}
	