using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class MarketingInterface : MonoBehaviour {

	public MarketingTool marketing = null;
	
	public bool isOpen;
	
	private GameObject bg;
	private GameObject label;
	private GameObject info;
	private GameObject increaseButton;
			
	private Company company;
	
	private Gameplay gameplay;
		
	public void Awake(){
		isOpen = true;
		
		bg = transform.Find("Background").gameObject;
		label = transform.Find("Label").gameObject;
		info = transform.Find("Information").gameObject;
		increaseButton = transform.Find("IncreaseButton").gameObject;
		
		company = Company.Instance();
		
		gameplay = Gameplay.Instance();
	}
	public void Start(){
		
		transform.Find("Label").gameObject.GetComponent<TextMesh>().text = marketing.tag;
				
		increaseButton.transform.Find("Label").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoneyWithoutDecimals(marketing.cost);
		info.transform.Find("Quantity").gameObject.GetComponent<TextMesh>().text =  (marketing.quantity).ToString();

		ToggleInterface();
	}
	
	public void Update(){
		if(isOpen){
			increaseButton.transform.Find("Label").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoneyWithoutDecimals(marketing.cost);
			info.transform.Find("Quantity").gameObject.GetComponent<TextMesh>().text =  (marketing.quantity).ToString();
		}
	}
	
	public void Upgrade(){
		marketing.quantity++;
		company.SetMoney(company.GetMoney() - marketing.cost);
	}
	
	public void ToggleInterface(){
		if(isOpen){
			bg.SetActive(false);
			label.SetActive(false);
			info.SetActive(false);
			increaseButton.SetActive(false);
			isOpen = false;
		} else{
			// Debug.Log("Activatin");
			bg.SetActive(true);
			label.SetActive(true);
			info.SetActive(true);
			increaseButton.SetActive(true);
			isOpen = true;
		}
	}
}
