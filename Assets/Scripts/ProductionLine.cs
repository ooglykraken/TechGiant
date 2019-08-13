using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionLine : MonoBehaviour {

	public List<Item> itemsInProduction = new List<Item>();
	
	private static ProductionLine instance;
	
	public static ProductionLine Instance(){
		if(instance == null){
			instance = GameObject.FindObjectOfType<ProductionLine>();
		}
		
		return instance;
	}
}
