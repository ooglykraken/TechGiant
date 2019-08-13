using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Company : MonoBehaviour {
	
	public float numberOfCustomers;

	private float money = 4000; // start at 200
	
	private float companyValue; // total product value over time
	private float marketValue; // current value of in-stock items and money
		
	private TextMesh cValueTextMesh; // company value
	private TextMesh mValueTextMesh; // market value
	
	private TextMesh moneyTextMesh;
	private TextMesh customerTextMesh;
	
	public void Awake(){		
		moneyTextMesh = Company.Instance().transform.Find("CompanyStatisticsBar/Money").gameObject.GetComponent<TextMesh>();
		// customerTextMesh = CompanyStatistics.Instance().transform.Find("CompanyStatisticsBar/#Customers").gameObject.GetComponent<TextMesh>();
		
		numberOfCustomers++;
	}
	
	public void Update(){
		moneyTextMesh.text = GetMoney().ToString("C");
		// customerTextMesh.text = numberOfCustomers.ToString();
	}
	
	public bool CanProduce(float cost){
		if(money - cost <= 0){
			return false;
		}
		
		return true;
	}
	
	public float GetMoney(){
		return money;
	}
	
	public void SetMoney(float input){
		money = input;
	}
	
	public float GetCompanyValue(){
		return companyValue;
	}
	
	
	public void SetCompanyValue(float input){
		companyValue = input;
	}
	
	public float GetMarketValue(){
		// SetMarketValue(GetMoney() + storage.GetProductValue());
		return marketValue;
	}
	
	public void SetMarketValue(float input){
		marketValue = input;
	}
	
	private static Company instance;
	
	public static Company Instance(){
		if(instance == null){
			instance = GameObject.FindObjectOfType<Company>();
		}
		
		return instance;
	}
}
