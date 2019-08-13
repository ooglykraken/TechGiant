using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour {
	
	
	private static Customers instance;
	
	public static Customers Instance(){
		if(instance == null){
			instance = GameObject.FindObjectOfType<Customers>();
		}
		
		return instance;
	}
}
