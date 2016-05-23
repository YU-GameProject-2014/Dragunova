using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	//Groups
	public GameObject[] groups;
	
	public void spawnNext(){
		//Random Index
		int i=Random.Range(0,groups.Length);
		
		//spawn Group at current Position
		Instantiate(groups[i],
		            transform.position,
		            Quaternion.identity);
	}
	
	
	// Use this for initialization
	void Start () {
		spawnNext();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
