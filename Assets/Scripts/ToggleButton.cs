using UnityEngine;
using System.Collections;

public class ToggleButton : MonoBehaviour {

	public GameObject downTarget;
	
	public string downArgument;
	public string downFunction;

	private Bounds colliderBounds;
	
	public bool isActive;
	
	public Material activeMaterial;
	public Material inactiveMaterial;
	
	private MeshRenderer overlayingMesh;
	
	private MeshRenderer mesh;
	
	public void Awake(){
		colliderBounds = gameObject.GetComponent<Collider>().bounds;
		mesh = transform.Find("Model").gameObject.GetComponent<MeshRenderer>();
		
		overlayingMesh = transform.Find("Overlay").gameObject.GetComponent<MeshRenderer>();
		overlayingMesh.enabled = false;
	}
	
	public void Update(){
		colliderBounds = gameObject.GetComponent<Collider>().bounds;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition = new Vector3(mousePosition.x, mousePosition.y, colliderBounds.center.z);

		if(colliderBounds.Contains(mousePosition)){
			Hovering();
		}
		
		SetRendering();
	}
	
	public void Hovering(){
		if(Input.GetMouseButtonDown(0)){
			if (downTarget) {
				if (downFunction.Length > 0) {
					if (downArgument.Length > 0)
						downTarget.SendMessage(downFunction, downArgument, SendMessageOptions.DontRequireReceiver);
					else
						downTarget.SendMessage(downFunction, SendMessageOptions.DontRequireReceiver);
					
					isActive = !isActive;
					SetRendering();
				}
			}
		}
	}
	
	private void SetRendering(){
		if(isActive && mesh.material != activeMaterial){
			mesh.material = activeMaterial;
		} else if(!isActive && mesh.material != inactiveMaterial){
			mesh.material = inactiveMaterial;
		}
	}
}


