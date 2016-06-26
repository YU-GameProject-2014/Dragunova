using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public static int w=10;
	public static int h=22;
	public static Transform[,]grid=new Transform[w,h];
	
	public static Vector2 roundVec2(Vector2 v){
		return new Vector2((float)((int)v.x),(float)((int)v.y));
	}
	
	public static bool insideBorder(Vector2 pos){
		return((int)pos.x>=0 && (int)pos.x<w && (int)pos.y>=0);
	}
	

	
	public static void deleteRow(int y){
		for(int x=0; x<w; ++x){
			Destroy(grid[x,y].gameObject);
			grid[x,y]=null;
		}
	}
	
	public static void decreaseRow(int y){
		Debug.Log("decrease");
		for(int x=0; x<w; ++x){
			if(grid[x,y]!=null){
				grid[x,y-1]=grid[x,y];
				grid[x,y]=null;
				grid[x,y-1].position+=new Vector3(0,-1,0);
			}
		}
	}
	
	public static void decreaseRowsAbove(int y,int top_y) {
		if(y>=top_y){
			return;
		}
		for (int i = y; i <=top_y ; ++i)
			decreaseRow(i);
	}
	
	public static bool isRowFull(int y) {
		for (int x = 0; x < w; ++x)
			if (grid[x, y] == null)
				return false;
	    return true;
	}
	
	public static int TopBlock_y(){
		for(int y=h-1; y>-1; y--)
			for(int x=0; x<w; x++)
				if(grid[x,y]!=null)
					return y;
		return 0;
	}
	
	public static void deleteFullRows() {
		int top_y=TopBlock_y();
		for (int y = 0; y <= top_y; ++y) {
			if (isRowFull(y)) {
				deleteRow(y);
				decreaseRowsAbove(y+1,top_y);
				--y;
			}
    	}
	}
	
	
	
	void Start () {
	}
	
	void Update () {
	}
}
