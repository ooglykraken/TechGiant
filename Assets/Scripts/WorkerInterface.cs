using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class WorkerInterface : MonoBehaviour {
	
	public Worker worker = null;
	
	public bool isOpen;
	
	private GameObject bg;
	private GameObject label;
	private GameObject info;
	private GameObject hireButton;
	
	// public string discipline;
			
	private Company company;
	
	private Gameplay gameplay;
		
	public void Awake(){
		isOpen = true;
		
		bg = transform.Find("Background").gameObject;
		label = transform.Find("Label").gameObject;
		info = transform.Find("Information").gameObject;
		hireButton = transform.Find("HireButton").gameObject;
		
		company = Company.Instance();
		
		gameplay = Gameplay.Instance();
	}
	public void Start(){
		
		transform.Find("Label").gameObject.GetComponent<TextMesh>().text = worker.tag;
				
		hireButton.transform.Find("Label").gameObject.GetComponent<TextMesh>().text =  MoneyParsing.ParseMoneyWithoutDecimals(worker.cost);
		info.transform.Find("Workforce").gameObject.GetComponent<TextMesh>().text =  (worker.workforce).ToString();

		ToggleInterface();
	}
	
	public void Update(){
		if(isOpen){
			hireButton.transform.Find("Label").gameObject.GetComponent<TextMesh>().text =  MoneyParsing.ParseMoneyWithoutDecimals(worker.cost);
			info.transform.Find("Workforce").gameObject.GetComponent<TextMesh>().text =  (worker.workforce).ToString();
		}
	}
	
	public void Upgrade(){
		worker.workforce++;
		company.SetMoney(company.GetMoney() - worker.cost);
	}
	
	public void ToggleInterface(){
		if(isOpen){
			bg.SetActive(false);
			label.SetActive(false);
			info.SetActive(false);
			hireButton.SetActive(false);
			isOpen = false;
		} else{
			bg.SetActive(true);
			label.SetActive(true);
			info.SetActive(true);
			hireButton.SetActive(true);
			isOpen = true;
		}
	}
}

