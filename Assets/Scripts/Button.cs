using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject target;
	
	public string argument;
	public string function;
	
	private Bounds colliderBounds;
	
	private MeshRenderer overlayingMesh;
	private MeshRenderer clickedMesh;
	
	private Vector3 startingScale;
	// private float scaleReduction = .9f;
	
	private bool isHovering;
	private bool isActive;
	private bool isClicked;
	
	private Company company;
	
	private float cost;
	
	public void Awake(){
		colliderBounds = gameObject.GetComponent<Collider>().bounds;
				 
		// startingScale = transform.localScale;
		
		overlayingMesh = transform.Find("Overlay").gameObject.GetComponent<MeshRenderer>();
		overlayingMesh.enabled = false;
		clickedMesh = transform.Find("ActiveOverlay").gameObject.GetComponent<MeshRenderer>();
		clickedMesh.enabled = false;
		
		company = Company.Instance();
	}
	
	public void Update(){
		colliderBounds = gameObject.GetComponent<Collider>().bounds;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition = new Vector3(mousePosition.x, mousePosition.y, colliderBounds.center.z);
		
		if(colliderBounds.Contains(mousePosition)){
			if((transform.name == "FactoryButton" || transform.name == "UpgradeButton")){
				cost = transform.parent.gameObject.GetComponent<ProductionInterface>().item.GetFactoryUpgradeCost();
				argument = cost.ToString();
			} else if(transform.name == "IncreaseButton"){
				cost = transform.parent.gameObject.GetComponent<MarketingInterface>().marketing.cost;
				argument = cost.ToString();
			} else if(transform.name == "HireButton"){
				cost = transform.parent.gameObject.GetComponent<WorkerInterface>().worker.cost;
				argument = cost.ToString();
			}
			overlayingMesh.enabled = true;
			Hovering();
			isHovering = true;
			
		} else {
			isHovering = false;
			overlayingMesh.enabled = false;
		}
		
		if(isClicked){
			if(Input.GetMouseButtonUp(0)){
				isClicked = false; 
				if(isHovering && company.CanProduce(cost)){
					ClickRelease();
				}
				clickedMesh.enabled = false;
				overlayingMesh.enabled = false;
				// transform.Find("Icon").localScale  = startingScale;
			}
		}
	}
	
	public void Hovering(){
		if(Input.GetMouseButtonDown(0)){
			
			if((transform.name != "FactoryButton" && transform.name != "UpgradeButton") || ((transform.name == "FactoryButton" || transform.name == "UpgradeButton") && Company.Instance().CanProduce(int.Parse(argument)))){
				isClicked = true;
				overlayingMesh.enabled = false;
				clickedMesh.enabled = true;
			}
		}
	}
	
	public void ClickRelease(){
		// Debug.Log("Clicked a button");
		if (target) {
			
			if (argument.Length > 0)
				target.SendMessage(function, argument, SendMessageOptions.DontRequireReceiver);
			else
				target.SendMessage(function, SendMessageOptions.DontRequireReceiver);
		}
	}

}


