using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {
	
	public float upperLimit;
	public float lowerLimit;
	
	private Bounds modelBounds;
	
	private float verticalOffset = -.05f;
	
	public void Awake(){
		modelBounds = transform.Find("Model").gameObject.GetComponent<MeshRenderer>().bounds;
		
		// lowerLimit = new Vector3(0f, ((transform.GetChild(0).localScale.y * transform.childCount) + verticalOffset), 0f);
		// upperLimit = new Vector3(0f, verticalOffset, 0f);
		upperLimit = 7.2f;
		lowerLimit = verticalOffset;
	}
	
	public void Update(){
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition = new Vector3(mousePosition.x, mousePosition.y, modelBounds.center.z);
		if(modelBounds.Contains(mousePosition)){
			Hovering();
		}
	}
	
	public void Hovering(){
		// Debug.Log("Hovering");
		float scrollwheel = Input.GetAxis("Mouse ScrollWheel");
		
		Scroll(scrollwheel);
	}
	
	private void Scroll(float scrollDirection){
		
		if(scrollDirection > 0){
			if(transform.position.y > lowerLimit){
				transform.position -= new Vector3(0f, .3f, 0f);
			}
		} else if(scrollDirection < 0){
			if(transform.position.y < upperLimit){
				transform.position += new Vector3(0f, .3f, 0f);
			}
		} else { // is 0
			 // Do nothing
		} 
	}
}
