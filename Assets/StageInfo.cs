using UnityEngine;
using System.Collections;

public class StageInfo
{
	public int size;
	public Sprite background; 
	public string name;
	public StageInfo(string s){
		name = s;
		size = 6;
	}
}

