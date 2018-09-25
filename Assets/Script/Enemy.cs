using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
	// 敵の出現位置の種類
	public enum RESPAWN_TYPE
	{
		UP, // 上
		RIGHT, // 右
		DOWN, // 下
		LEFT, // 左
		SIZEOF, // 敵の出現位置の数

	}

	// 敵を制御するコンポーネント
	public class Enemy : MonoBehaviour
	{
		public Vector2 m_respawnPosInside; // 敵の出現位置（内側）
		public Vector2 m_respawnPosOutside; // 敵の出現位置（外側）
		public float m_speed; // 移動する速さ
		public int m_hpMax; // HP の最大値
		public int m_exp; // この敵を倒した時に獲得できる経験値
		public int m_damage; // この敵がプレイヤーに与えるダメージ
	public Gem[] m_gemPrefabs; // 宝石のプレハブを管理する配列
	public float m_gemSpeedMin; // 生成する宝石の移動の速さ（最小値）
	public float m_gemSpeedMax; // 生成する宝石の移動の速さ（最大値）
	public GameObject explosionPrefab;
	public GameObject gemPrefab;
		private int m_hp; // HP
		private Vector3 m_direction; // 進行方向
	public Explosion m_explosionPrefab; // 爆発エフェクトのプレハブ
	public GameObject PowerupPrefab;
	public AudioClip m_deathClip;
		// 敵が生成された時に呼び出される関数
		private void Start()
		{
			// HP を初期化する
			m_hp = m_hpMax;
		}

		// 毎フレーム呼び出される関数
		private void Update()
		{
			// まっすぐ移動する
			transform.localPosition += m_direction * m_speed;
		}

		// 敵が出現する時に初期化する関数
		public void Init( RESPAWN_TYPE respawnType )
	{
		var pos = Vector3.zero;

		// 指定された出現位置の種類に応じて、
		// 出現位置と進行方向を決定する
		switch (respawnType) {
		// 出現位置が上の場合
		case RESPAWN_TYPE.UP:
			pos.x = Random.Range (
				-m_respawnPosInside.x, m_respawnPosInside.x);
			pos.y = m_respawnPosOutside.y;
			m_direction = Vector2.down;
			break;

		// 出現位置が右の場合
		case RESPAWN_TYPE.RIGHT:
			pos.x = m_respawnPosOutside.x;
			pos.y = Random.Range (
				-m_respawnPosInside.y, m_respawnPosInside.y);
			m_direction = Vector2.left;
			break;

		// 出現位置が下の場合
		case RESPAWN_TYPE.DOWN:
			pos.x = Random.Range (
				-m_respawnPosInside.x, m_respawnPosInside.x);
			pos.y = -m_respawnPosOutside.y;
			m_direction = Vector2.up;
			break;

		// 出現位置が左の場合
		case RESPAWN_TYPE.LEFT:
			pos.x = -m_respawnPosOutside.x;
			pos.y = Random.Range (
				-m_respawnPosInside.y, m_respawnPosInside.y);
			m_direction = Vector2.right;
			break;
		}

		// 位置を反映する
		transform.localPosition = pos;

	}



	private void OnTriggerEnter2D( Collider2D collision )
	{
		// 弾と衝突した場合
		if ( collision.name.Contains( "Shot" ) )
		{
			Debug.Log ("てき");
			Destroy( collision.gameObject );
			Destroy( gameObject );
			// 弾が当たった場所に爆発エフェクトを生成する
			/*Instantiate( 
				m_explosionPrefab, 
				collision.transform.localPosition, 
				Quaternion.identity );
			*/
			Instantiate (PowerupPrefab, transform.position, Quaternion.Euler(0, 0, 0));	
			Debug.Log ("生成");
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_deathClip );
			}
		}
	}






				











				
			



		




		
	
	
