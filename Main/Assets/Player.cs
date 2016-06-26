using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject bullet;
	
	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log(other.tag);
		if(other.gameObject.tag=="Block"){
			Debug.Log("GameOver:collision Block");
			Destroy(this.gameObject);
		}
	}
	
	
	void CreateBullet(){
		Instantiate(bullet , transform.position , Quaternion.identity);
	}
	
	
	// Use this for initialization
	void Start () {}
	
	
	// Update is called once per frame
	void Update () {
	/*	// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if(Input.GetKeyDown("left")){
			// 代入したPositionに対して加算減算を行う
			Position.x -= 1;
		} else if(Input.GetKeyDown("right")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.x += 1;
		} else if(Input.GetKeyDown("up")){ // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y += 1;
		} else if(Input.GetKeyDown("down")){ // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y -= 1;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
*/		
		
		if(Input.GetKeyDown("space")){
			CreateBullet();
		}
		
	}
}
