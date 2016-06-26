using UnityEngine;
using System.Collections;

public class block : MonoBehaviour {
	GameObject parent;
	
	
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag=="WallBottom" || other.gameObject.tag=="Block"){
			parent.SendMessage("RedirectedOnCollisionEnter2D",other);
		}else if(other.gameObject.tag=="Player" || other.gameObject.tag=="Bullet"){
			
			Destroy(this.gameObject);
			parent.SendMessage("CheckChildCount");
			enabled=false;
		}
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D other){
	if(other.tag=="Player" || other.tag=="Bullet"){
			Destroy(this.gameObject);
			parent.SendMessage("CheckChildCount");
			enabled=false;
		}
			
	}
	
	// Use this for initialization
	void Start () {
		parent=gameObject.transform.parent.gameObject;
	}
	
	
	// Update is called once per frame
	void Update () {}
}
