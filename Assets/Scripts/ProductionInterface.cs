using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class ProductionInterface : MonoBehaviour {
	
	public bool isOpen;
	
	public GameObject border;
	private GameObject bg;
	private GameObject label;
	private GameObject info;
	private GameObject upgradeButton;
	private GameObject factoryButton;
	private GameObject infoButton;
	private GameObject timedButtonIcon;
	private GameObject timedButtonLabel;
	private Collider timedButtonCollider;
	
	private TimedButton timedButton;
	
	public Item item;
	
	public Product product = null;
	public Service service = null;
	public Software software = null;
	public Entertainment entertainment = null;
	
	private Company company;
	
	private Gameplay gameplay;
	
	private float incomeEveryMinute;
	
	public void Awake(){
		isOpen = true;
		
		border = transform.Find("Border").gameObject;
		bg = transform.Find("Background").gameObject;
		label = transform.Find("Label").gameObject;
		info = transform.Find("Information").gameObject;
		upgradeButton = transform.Find("UpgradeButton").gameObject;
		factoryButton = transform.Find("FactoryButton").gameObject;
		infoButton = transform.Find("InformationButton").gameObject;
		timedButtonIcon = transform.Find("TimedButton/Icon").gameObject;
		
		timedButtonLabel = transform.Find("TimedButton/Timer").gameObject;
		// timedButtonLabel.transform.Find("Label").GetComponent<TextMesh>().color = border.GetComponent<MeshRenderer>().material.color;
		timedButtonCollider = transform.Find("TimedButton").gameObject.GetComponent<Collider>();
		
		company = Company.Instance();
		
		gameplay = Gameplay.Instance();
	}
	
	public void Start(){
		
		
		timedButton = transform.Find("TimedButton").gameObject.GetComponent<TimedButton>();
		
		if(product != null){
			product.UpdateMarketValue();
			product.UpdateUpgradeCost();
			timedButton.profit = product.profitPerUnit;
		} else if(entertainment != null){
			entertainment.UpdateMarketValue();
			entertainment.UpdateUpgradeCost();
			timedButton.profit = entertainment.GetIncomePerSecond();
		} else if(software != null){
			software.UpdateMarketValue();
			software.UpdateUpgradeCost();
			timedButton.profit = software.GetIncomePerSecond();
		} else if (service != null){
			service.UpdateMarketValue();
			service.UpdateUpgradeCost();
			timedButton.profit = service.GetIncomePerSecond();
		}else if(item == null){
			Destroy(gameObject);
		}
		
		transform.Find("Label").gameObject.GetComponent<TextMesh>().text = item.tag;
		
		timedButton.timeToFinish = item.time;
		timedButton.cost = item.cost;
		timedButton.retail = item.price;
		
		timedButton.viability = item.viability;
		timedButton.customers = item.customers;
		
		info.transform.Find("CostText").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoney(item.adjustedCost);
		info.transform.Find("PriceText").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoney(item.adjustedPrice);
		info.transform.Find("ProfitText").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoney(timedButton.profit);
		
		upgradeButton.transform.Find("txtCost").gameObject.GetComponent<TextMesh>().text =  MoneyParsing.ParseMoneyWithoutDecimals(item.upgradeCost);
		factoryButton.transform.Find("txtCost").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoneyWithoutDecimals(item.GetFactoryUpgradeCost());
		
		// Debug.Log(item.name + ".png");
		timedButtonIcon.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("ProductIcons/" + item.name) as Texture;
		
		ToggleInterface();
	}
	
	public void Update(){
		if(isOpen){
			// float profit = item.price - item.cost;
			// timedButton.profit = profit;
			float income = 0;
			
			if(product != null){
				product.UpdateMarketValue();
				product.UpdateUpgradeCost();
				timedButton.profit = product.profitPerUnit;
			} else if(entertainment != null){
				entertainment.UpdateMarketValue();
				entertainment.UpdateUpgradeCost();
				timedButton.profit = entertainment.GetIncomePerSecondPerItem();
				income = entertainment.GetIncomePerSecond();
			} else if(software != null){
				software.UpdateMarketValue();
				software.UpdateUpgradeCost();
				timedButton.profit = software.GetIncomePerSecondPerItem();
				income = software.GetIncomePerSecond();
			} else if (service != null){
				service.UpdateMarketValue();
				service.UpdateUpgradeCost();
				timedButton.profit = service.GetIncomePerSecondPerItem();
				income = service.GetIncomePerSecond();
			}else if(item == null){
				Destroy(gameObject);
			}
			
			
			
			// if((gameplay.gameTime % 60) == 0){ // Collect income every minute from income streams i.e. not products
				// company.SetMoney(company.GetMoney() + income);
			// }
			
			timedButton.cost = item.adjustedCost;
			timedButton.retail = item.adjustedPrice;
			
		info.transform.Find("CostText").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoney(item.adjustedCost);
		info.transform.Find("PriceText").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoney(item.adjustedPrice);
		info.transform.Find("ProfitText").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoney(timedButton.profit);
		
		upgradeButton.transform.Find("txtCost").gameObject.GetComponent<TextMesh>().text =  MoneyParsing.ParseMoneyWithoutDecimals(item.upgradeCost);
		factoryButton.transform.Find("txtCost").gameObject.GetComponent<TextMesh>().text = MoneyParsing.ParseMoneyWithoutDecimals(item.GetFactoryUpgradeCost());
		}
	}
	
	public void UpgradeFactory(){
		item.factoryLevel++;
		company.SetMoney(company.GetMoney() - item.GetFactoryUpgradeCost());
	}
	
	public void Upgrade(){
		item.upgradeLevel++;
		company.SetMoney(company.GetMoney() - item.upgradeCost);
	}
	
	public void MadeAnItem(){
		item.quantity++;
		
		if(product != null){
			item.quantity--;
			company.SetMoney(company.GetMoney() + item.adjustedPrice);
		} else if(entertainment != null){
			entertainment.consumerTimer += entertainment.viability;
		} else if(software != null){
			software.consumerTimer += software.viability;
		} else if (service != null){
			service.consumerTimer += service.viability;
		} else if(item == null){
			Destroy(gameObject);
		}
	}
	
	public void ToggleInterface(){
		if(isOpen){
			border.SetActive(false);
			bg.SetActive(false);
			label.SetActive(false);
			info.SetActive(false);
			upgradeButton.SetActive(false);
			infoButton.SetActive(false);
			timedButtonIcon.SetActive(false);
			timedButtonLabel.SetActive(false);
			factoryButton.SetActive(false);
			timedButtonCollider.enabled = false;
			
			isOpen = false;
		} else{
			// Debug.Log("Activatin");
			border.SetActive(true);
			bg.SetActive(true);
			label.SetActive(true);
			info.SetActive(true);
			upgradeButton.SetActive(true);
			infoButton.SetActive(true);
			timedButtonIcon.SetActive(true);
			timedButtonLabel.SetActive(true);
			factoryButton.SetActive(true);
			timedButtonCollider.enabled = true;
			
			isOpen = true;
		}
	}
}
