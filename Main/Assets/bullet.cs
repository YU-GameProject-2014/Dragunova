using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public Rigidbody2D rb;
	int speed=1000;
	
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody2D>();
		rb.AddForce(Vector2.up*speed);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Block"){
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y>=Grid.h){
			Destroy(gameObject);
		}
	}
}
