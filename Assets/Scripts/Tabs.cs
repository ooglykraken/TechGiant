using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabs : MonoBehaviour {
	
	public Button productsButton;
	public Button serviceButton;
	public Button softwareButton;
	public Button entertainmentButton;
	public Button marketingButton;
	public Button workersButton;
	
	public GameObject products;
	public GameObject entertainment;
	public GameObject software;
	public GameObject services;
	public GameObject workers;
	public GameObject marketing;
		
	private bool productsOpen;
	private bool entertainmentOpen;
	private bool softwareOpen;
	private bool servicesOpen;
	private bool workersOpen;
	private bool marketingOpen;
	
	public GameObject productWorkers;
	public GameObject servicesWorkers;
	public GameObject entertainmentWorkers;
	public GameObject softwareWorkers;
	public GameObject marketingWorkers;
	
	private GameObject activeTab = null;
	
	private Gameplay gameplay;
	
	public void Awake(){
		gameplay = Gameplay.Instance();
		
		CloseAllTabs();
	}
	
	public void Update(){
	}
		
	private void CloseAllTabs(){
		
		activeTab = null;
		
		productsOpen = false;
		entertainmentOpen = false;
		softwareOpen = false;
		servicesOpen = false;
		workersOpen = false;
		marketingOpen = false;
		
		foreach(ProductionInterface pi in gameplay.productsList){
			pi.isOpen = true;
			pi.ToggleInterface();
		}
		foreach(ProductionInterface pi in gameplay.entertainmentList){
			pi.isOpen = true;
			pi.ToggleInterface();
		}
		foreach(ProductionInterface pi in gameplay.softwareList){
			pi.isOpen = true;
			pi.ToggleInterface();
		}
		foreach(ProductionInterface pi in gameplay.servicesList){
			pi.isOpen = true;
			pi.ToggleInterface();
		}
		foreach(WorkerInterface wi in gameplay.workersList){
			wi.isOpen = true;
			wi.ToggleInterface();
			productWorkers.SetActive(false);
			servicesWorkers.SetActive(false);
			entertainmentWorkers.SetActive(false);
			softwareWorkers.SetActive(false);
			marketingWorkers.SetActive(false);
		}
		foreach(MarketingInterface mi in gameplay.marketingList){
			mi.isOpen = true;
			mi.ToggleInterface();
		}
		
	}
	
	public void ToggleTabs(){
		CloseAllTabs();
	}
	
	public void ToggleProducts(){
		if(productsOpen){
			CloseAllTabs();
			productsOpen = true;
		} else {
			CloseAllTabs();
		}
		
		if(productsOpen){
			foreach(ProductionInterface pi in gameplay.productsList){
				pi.isOpen = true;
				pi.ToggleInterface();
			}
			productsOpen = false;
		} else {
			foreach(ProductionInterface pi in gameplay.productsList){
				pi.isOpen = false;
				pi.ToggleInterface();
			}
			productsOpen = true;
			
			activeTab = products;
		}
		// Debug.Log(productsOpen);
	}
	
	public void ToggleEntertainment(){
		if(entertainmentOpen){
			CloseAllTabs();
			entertainmentOpen = true;
		} else {
			CloseAllTabs();
		}
		
		if(entertainmentOpen){
			foreach(ProductionInterface pi in gameplay.entertainmentList){
				pi.isOpen = true;
				pi.ToggleInterface();
			}
			
			entertainmentOpen = false;
		} else {
			foreach(ProductionInterface pi in gameplay.entertainmentList){
				pi.isOpen = false;
				pi.ToggleInterface();
			}
			entertainmentOpen = true;
			
			activeTab = entertainment;
		}
	}
	
	public void ToggleSoftware(){
		if(softwareOpen){
			CloseAllTabs();
			softwareOpen = true;
		} else {
			CloseAllTabs();
		}
		
		if(softwareOpen){
			foreach(ProductionInterface pi in gameplay.softwareList){
				pi.isOpen = true;
				pi.ToggleInterface();
			}
			
			softwareOpen = false;
		} else {
			foreach(ProductionInterface pi in gameplay.softwareList){
				pi.isOpen = false;
				pi.ToggleInterface();
			}
			softwareOpen = true;
			
			activeTab = software;
		}
	}
	
	public void ToggleServices(){
		if(servicesOpen){
			CloseAllTabs();
			servicesOpen = true;
		} else {
			CloseAllTabs();
		}
		
		if(servicesOpen){
			foreach(ProductionInterface pi in gameplay.servicesList){
				pi.isOpen = true;
				pi.ToggleInterface();
			}
			
			servicesOpen = false;
		} else {
			foreach(ProductionInterface pi in gameplay.servicesList){
				pi.isOpen = false;
				pi.ToggleInterface();
			}
			servicesOpen = true;
			
			activeTab = services;
		}
	}
	
	public void ToggleWorkers(){
		if(workersOpen){
			CloseAllTabs();
			workersOpen = true;
		} else {
			CloseAllTabs();
		}
		
		if(workersOpen){
			foreach(WorkerInterface wi in gameplay.workersList){
				wi.isOpen = true;
				wi.ToggleInterface();
			}
			
			productWorkers.SetActive(false);
			servicesWorkers.SetActive(false);
			entertainmentWorkers.SetActive(false);
			softwareWorkers.SetActive(false);
			marketingWorkers.SetActive(false);
			
			workersOpen = false;
		} else {
			foreach(WorkerInterface wi in gameplay.workersList){
				wi.isOpen = false;
				wi.ToggleInterface();
			}
			
			productWorkers.SetActive(true);
			servicesWorkers.SetActive(true);
			entertainmentWorkers.SetActive(true);
			softwareWorkers.SetActive(true);
			marketingWorkers.SetActive(true);
			
			workersOpen = true;
			
			activeTab = workers;
		}
	}
	
	public void ToggleMarketing(){
		if(marketingOpen){
			CloseAllTabs();
			marketingOpen = true;
		} else {
			CloseAllTabs();
		}
		
		if(marketingOpen){
			foreach(MarketingInterface mi in gameplay.marketingList){
				mi.isOpen = true;
				mi.ToggleInterface();
			}
			
			marketingOpen = false;
		} else {
			foreach(MarketingInterface mi in gameplay.marketingList){
				mi.isOpen = false;
				mi.ToggleInterface();
			}
			marketingOpen = true;
			
			activeTab = marketing;
		}
	}
	
	private static Tabs instance;
	
	public static Tabs Instance(){
		if(instance == null){
			instance = GameObject.FindObjectOfType<Tabs>();
		}
		
		return instance;
	}
}
