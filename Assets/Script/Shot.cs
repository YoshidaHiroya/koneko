﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	private Vector3 m_velocity; // 速度

	private void Start(){
	}

		
		private void Update()
		{
			// 移動する
			transform.localPosition += m_velocity;
		}

		// 弾を発射する時に初期化するための関数
		public void Init( float angle, float speed )
		{
			// 弾の発射角度をベクトルに変換する
			var direction = GetDirection(angle);

			// 発射角度と速さから速度を求める
			m_velocity = direction * speed;

			// 弾が進行方向を向くようにする
			var angles = transform.localEulerAngles;
			angles.z = angle - 90;
			transform.localEulerAngles = angles;

			// 2 秒後に削除する
			Destroy( gameObject, 2 );
		}
	public static Vector3 GetDirection( float angle )
	{
		return new Vector3
			(
				Mathf.Cos( angle * Mathf.Deg2Rad ),
				Mathf.Sin( angle * Mathf.Deg2Rad ),
				0
			);
		
	}


	}
