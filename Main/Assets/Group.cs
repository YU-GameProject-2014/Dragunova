using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {
	float speed=(float)-5;
	public Rigidbody2D rb;
	int cnt;
	
	bool isValidGridPos(){
		foreach(Transform child in transform){
			Vector2 v=Grid.roundVec2(child.position);
			if(!Grid.insideBorder(v))
				return false;
			if(Grid.grid[(int)v.x,(int)v.y]!=null && 
			   Grid.grid[(int)v.x,(int)v.y].parent != transform)
					return false;
		}
		return true;
	}
	
	
	void updateGrid(){
		foreach(Transform child in transform){
			Vector2 v=Grid.roundVec2(child.position);
			if((int)Grid.h<=(int)v.y){
				Time.timeScale=0;
			//	Debug.Log("GameOver");
			}
		 	Grid.grid[(int)v.x,(int)v.y] = child;
		}
/*		// Remove old children from grid
		for (int y = 0; y < Grid.h; ++y)
			for (int x = 0; x < Grid.w; ++x)
				if (Grid.grid[x, y] != null)
					if (Grid.grid[x, y].parent == transform)
						Grid.grid[x, y] = null;
    	// Add new children to grid
    	foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid[(int)v.x, (int)v.y] = child;
    	}
*/
	}
	
	
	void CheckChildCount(){
		if(transform.childCount==1){
			FindObjectOfType<Spawner>().spawnNext();
			Destroy(gameObject);
			enabled=false;
		}
	}
	
	
	void RedirectedOnCollisionEnter2D(Collision2D collision){
		Debug.Log("  ");
		
		if(CheckUnderMass()){
			rb.velocity=Vector3.zero;
			float tmp_x=(float)((int)transform.position.x + 0.5);
			float tmp_y=(float)((int)transform.position.y + 0.5);
			transform.position = new Vector3(tmp_x , tmp_y , transform.position.z);		
		//	foreach(Transform child in transform){Debug.Log(child.position.y);}
			updateGrid();
			Grid.deleteFullRows();
			if(cnt==0){
				FindObjectOfType<Spawner>().spawnNext();
				cnt++;
			}
			rb.isKinematic=true;
			Destroy(rb);
			
			// Disable script
			enabled = false;
		}
		
	}
	
	
	// Use this for initialization
	void Start () {
		cnt=0;
		if(!isValidGridPos()){
	//		Debug.Log("GameOver");
			Destroy(gameObject);
		}else{
			rb=GetComponent<Rigidbody2D>();
			rb.velocity=new Vector3(0,speed,0);
			//rb.AddForce(Vector2.down*speed);
		}
	}
	
	
	void Rotate(){
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(0, 0, -90);
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.Rotate(0, 0, 90);
		}
	}
	

	
	bool CheckUnderMass(){
		foreach(Transform child in transform){
			Vector2 v=Grid.roundVec2(child.position);
			v.y--;
		//	Debug.Log(v);
			if(v.y<0 || Grid.grid[(int)v.x,(int)v.y]!=null){
				return true;
			}
		}
		return false;
	}
	
	
	bool isNothingMass(Vector2 v){
		if(-1<v.x && v.x<Grid.w && 0<v.y && v.y<Grid.h && Grid.grid[(int)v.x,(int)v.y]==null){
		return true;
		}
		return false;
	}
    
	void Update() {
	
	//float tmp_x=(float)((int)transform.position.x + 0.5);
	//transform.position = new Vector3(tmp_x , transform.position.y, transform.position.z);
		//Debug
		Vector2 pos = Vector2.zero;
		
		if(Input.GetKeyDown("left")){
			pos.x -= 1;
		}else if(Input.GetKeyDown("right")){
			pos.x += 1;
		}else if(Input.GetKeyDown("up")){
			pos.y += 1;
		}else if(Input.GetKeyDown("down")){
			pos.y -= 1;
		}
		
		foreach(Transform child in transform){
			Vector2 v=Grid.roundVec2(child.position);
			v=v+pos;
			if(!isNothingMass(v)){
				return;
			}
		}
		transform.position+=(Vector3)pos;


	
/*		// Move Downwards and Fall
    	 if (cur_pos!=(int)transform.position.y) {
    	 	cur_pos=(int)transform.position.y;
	        // See if valid
    	    if (isValidGridPos()) {
        	    // It's valid. Update grid.
            	updateGrid();
        	} else {
	            // It's not valid. revert.
				transform.position += new Vector3(0, 1, 0);
				rb.velocity=Vector3.zero;
        	    // Clear filled horizontal lines
            	Grid.deleteFullRows();
	            // Spawn next Group
    	        FindObjectOfType<Spawner>().spawnNext();
	
    	        // Disable script
        	    enabled = false;
        	}
    	}
    	if(transform.childCount==0){
    		FindObjectOfType<Spawner>().spawnNext();
    		enabled=false;
    	}*/
	}
	
}
