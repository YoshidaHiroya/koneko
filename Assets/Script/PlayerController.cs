using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
	public GameObject arrowPrefab;
	public AudioClip boyon;
	public AudioSource aS;
	public float m_speed; 
	public Shot m_shotPrefab; // 弾のプレハブ
	public float m_shotSpeed; // 弾の移動の速さ
	public float m_shotAngleRange; // 複数の弾を発射する時の角度
	public float m_shotTimer; // 弾の発射タイミングを管理するタイマー
	public int m_shotCount; // 弾の発射数
	public float m_shotInterval; // 弾の発射間隔（秒）
	public int  p_hp;
	public AudioClip m_damageClip;
	public AudioClip PowerUp;
	GameObject boss;
	// Use this for initialization

	public static Vector2 m_moveLimit = new Vector2( 19.4f, 4.0f );

	// 指定された位置を移動可能な範囲に収めた値を返す
	public static Vector3 ClampPosition( Vector3 position )
	{
		return new Vector3
			(
				Mathf.Clamp( position.x, -m_moveLimit.x, m_moveLimit.x ),
				Mathf.Clamp( position.y, -m_moveLimit.y, m_moveLimit.y ),
				0
			);
	}

	void Start () {
		
		boss = GameObject.Find ("Boss");
	}
	
	// Update is called once per frame
	void Update () {


		// 矢印キーの入力情報を取得する
		var h = Input.GetAxis( "Horizontal" );
		var v = Input.GetAxis( "Vertical" );

		// 矢印キーが押されている方向にプレイヤーを移動する
		var velocity = new Vector3( h, v ) * m_speed;
		transform.localPosition += velocity;
	

		//if (Input.GetKeyDown (KeyCode.Space)) {			
		//	GameObject go =Instantiate (arrowPrefab, transform.position, Quaternion.Euler(0, 0, 90));	
		//	aS.PlayOneShot(boyon);
		//}
		transform.localPosition = ClampPosition( transform.localPosition );

		// 弾の発射タイミングを管理するタイマーを更新する
		m_shotTimer += Time.deltaTime;

		// まだ弾の発射タイミングではない場合は、ここで処理を終える
		if ( m_shotTimer < m_shotInterval ) return;

		// 弾の発射タイミングを管理するタイマーをリセットする
		m_shotTimer = 0;

		// 弾を発射する


		var screenPos = Camera.main.WorldToScreenPoint( transform.position );

		// プレイヤーから見たマウスカーソルの方向を計算する
		var direction = Input.mousePosition - screenPos;

		// マウスカーソルが存在する方向の角度を取得する
		var angle = GetAngle( Vector3.zero, direction );

		// プレイヤーがマウスカーソルの方向を見るようにする
		var angles = transform.localEulerAngles;
		angles.z = angle - 90;
		transform.localEulerAngles = angles;


		ShootNWay( angle, m_shotAngleRange, m_shotSpeed, m_shotCount );





		}


	// 弾を発射する関数
	private void ShootNWay( 
		float angleBase, float angleRange, float speed, int count )
	{
		var pos = transform.localPosition; // プレイヤーの位置
		var rot = transform.localRotation; // プレイヤーの向き

		// 弾を複数発射する場合
		if ( 1 < count )
		{
			// 発射する回数分ループする
			for ( int i = 0; i < count; ++i )
			{
				// 弾の発射角度を計算する
				var angle = angleBase + 
					angleRange * ( ( float )i / ( count - 1 ) - 0.5f );

				// 発射する弾を生成する
				var shot = Instantiate( m_shotPrefab, pos, rot );

				// 弾を発射する方向と速さを設定する
				shot.Init( angle, speed );
			}
		}
		// 弾を 1 つだけ発射する場合
		else if ( count == 1 )
		{
			// 発射する弾を生成する
			var shot = Instantiate( m_shotPrefab, pos, rot );

			// 弾を発射する方向と速さを設定する
			shot.Init( angleBase, speed );
		}
	}
	public static float GetAngle( Vector2 from, Vector2 to )
	{
		var dx = to.x - from.x;
		var dy = to.y - from.y;
		var rad = Mathf.Atan2( dy, dx );
		return rad * Mathf.Rad2Deg;
	}





	void OnTriggerEnter2D(Collider2D col) {
		
		Debug.Log ("あたり");
		GameObject director = GameObject.Find ("GameDirector");
		GameObject score = GameObject.Find ("Score");

		if (col.gameObject.tag == "enemy") {
			Destroy (col.gameObject);
			Debug.Log ("えねみー");
			director.GetComponent<GameDirector> ().DecreaseHP ();
			score.GetComponent<Score> ().score += 10;
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_damageClip );
		}

		if (col.gameObject.tag == "Boss") {
			Debug.Log ("ぼす");
			boss.GetComponent<BossController> ().Hp += -1; 
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_damageClip );
			if ( col.gameObject.tag == "Powerup")
			{
				Destroy (col.gameObject);
				Debug.Log ("ぱわーあっぷ");
				m_shotCount += 1;


			}	
			if (col.gameObject.tag == "Wall") {
				Debug.Log ("かべ");

			}
				
			if ( col.gameObject.tag == "arrow")
			{
				 audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_damageClip );
				Destroy (col.gameObject);

			}	
		}
	}
}