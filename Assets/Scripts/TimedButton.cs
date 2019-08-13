using UnityEngine;
using System.Collections;
using HelperFunctions;

public class TimedButton : MonoBehaviour {
	
	private MeshRenderer overlayingMesh;
	private MeshRenderer topMesh;
	
	private Vector3 startingScale;
	
	private Vector3 maskStartingPosition;
	
	private float timer;
	private float maskLength;
	private float scaleReduction = .95f;
	
	public bool isHovering;
	public bool isClicked;
	private bool isProducing = false;
	
	public string objectToProduce;
		
	private Transform mask;
	private Transform timerTransform;
	
	private TextMesh timeTextMesh;
	private TextMesh nameTextMesh;
	
	private Collider thisCollider;
	
	private Bounds colliderBounds;
	
	public float cost;
	public float retail;
	public float profit;
	
	public string productName;
	
	public float timeToFinish;
	
	public float factoryUpgradeCost;
	public float upgradeCost;
	
	public int customers;
	
	public int viability;
	
	private Company company;
	
	public void Awake(){
		mask = transform.Find("Timer/Mask");
		maskLength = mask.localScale.y;
		maskStartingPosition = mask.localPosition;
		mask.localScale = new Vector3(1f, 0f, 1f);
		
		startingScale = transform.Find("Icon").localScale;
		
		thisCollider = gameObject.GetComponent<Collider>();
		colliderBounds = GetComponent<Collider>().bounds;
						 		
		overlayingMesh = transform.Find("Icon/Overlay").gameObject.GetComponent<MeshRenderer>();
		overlayingMesh.enabled = false;
		topMesh = transform.Find("Icon/ActiveOverlay").gameObject.GetComponent<MeshRenderer>();
		topMesh.enabled = false;
		
		timeTextMesh = transform.Find("Timer/Label").gameObject.GetComponent<TextMesh>();
		
		
		company = Company.Instance();
	}
	
	public void Start(){
		timeTextMesh.text = Timing.GetProductionTime(timeToFinish);
	}
	
	public void Update(){
		colliderBounds = gameObject.GetComponent<Collider>().bounds;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition = new Vector3(mousePosition.x, mousePosition.y, colliderBounds.center.z);
		
		if(colliderBounds.Contains(mousePosition)){
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
				if(isHovering){
					Activate();
				}
				topMesh.enabled = false;
				overlayingMesh.enabled = false;
				transform.Find("Icon").localScale  = startingScale;
			}
		}

		if(timer <= 0 && isProducing){
			Finish();
			timeTextMesh.text = Timing.GetProductionTime(timeToFinish);
			return;
		}
		
		if(timer > 0){
			
			timer -= Time.deltaTime;
			timeTextMesh.text = Timing.GetProductionTime(timer);
			AdjustMask();
		}
		
		
	}
	
	private void Activate(){
		if(company.CanProduce(cost)){
			float moneyAfter = company.GetMoney() - cost;
			company.SetMoney(moneyAfter);
			isProducing = true;
			timer = timeToFinish;
			mask.localScale = new Vector3(1f, maskLength, 1f);
		}
	}
	
	private void Finish(){
		transform.parent.GetComponent<ProductionInterface>().MadeAnItem();
		mask.localPosition = maskStartingPosition;
		isProducing = false;
	}
	
	private void AdjustMask(){
		float ratio = (float) timer / (float) timeToFinish;
		
		float maskAdjustment = ratio * maskLength;
		// float maskDifference = maskLength - maskAdjustment;
		float maskDifference = mask.localScale.y - maskAdjustment;
		
		mask.localScale = new Vector3( mask.localScale.x , maskAdjustment, mask.localScale.z);

		mask.localPosition = new Vector3(maskStartingPosition.x , mask.localPosition.y + (maskDifference /2f), mask.localPosition.z);
	}
	
	public void Hovering(){
		if(Input.GetMouseButtonDown(0) && !isProducing){
			
			if(!isClicked){
				transform.Find("Icon").localScale = new Vector3(scaleReduction * startingScale.x, scaleReduction * startingScale.x, 1f);
			}
			
			isClicked = true;
			overlayingMesh.enabled = false;
			topMesh.enabled = true;
		}
	}
	
	public void InactivateAllElse(){
		transform.SetAsFirstSibling();
		for(int i = 1; i < transform.parent.childCount; i++){
			transform.parent.GetChild(i).gameObject.SetActive(false);
		}
		
		transform.Find("Icon").gameObject.SetActive(false);
		transform.Find("Timer").gameObject.SetActive(false);
		
		thisCollider.enabled = false;
	}
	
	public void ReactivateAllElse(){
		transform.SetAsFirstSibling();
		for(int i = 1; i < transform.parent.childCount; i++){
			transform.parent.GetChild(i).gameObject.SetActive(true);
		}
		
		transform.Find("Icon").gameObject.SetActive(true);
		transform.Find("Timer").gameObject.SetActive(true);
		
		thisCollider.enabled = true;
	}

}