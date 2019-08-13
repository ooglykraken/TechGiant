using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XML : MonoBehaviour {
	
	private string fileRoot = "XML/";
	private string xmlFile = "TechGiant";
	
	private string xmlRoot = "doc>0>disciplines>0>discipline";
		
	public List<Product> products = new List<Product>();
	public List<Worker> workers = new List<Worker>();
	public List<Entertainment> entertainments = new List<Entertainment>();
	public List<Software> softwares = new List<Software>();
	public List<Service> services = new List<Service>();
	public List<MarketingTool> marketingTools = new List<MarketingTool>();
	
	private static int PRODUCTS = 0;
	private static int ENTERTAINMENTS = 1;
	private static int SOFTWARES = 2;
	private static int SERVICES = 3;
	private static int MARKETING = 4;
	private static int WORKERS = 5;
	
	// public List<Tile> tiles = new List<Tile>();
	
	public void Awake() {
		ConnectXML();
	}
	
	private void ConnectXML(){
		string resourcePath = fileRoot + xmlFile;
		
		XMLNode xml = XMLParser.Parse((Resources.Load(resourcePath, typeof(TextAsset)) as TextAsset).text);
		XMLNodeList xmlList = xml.GetNodeList(xmlRoot);
			
		XMLNode xmlSubNode = xmlList[PRODUCTS] as XMLNode;
		
		XMLNodeList productsXML = xmlSubNode.GetNodeList("products>0>product");
		for (int j = 0; j < productsXML.Count; j++) {
			XMLNode productXML = productsXML[j] as XMLNode;
			Product product = new Product();
			
			product.name = productXML.GetValue("@name");
			product.tag = productXML.GetValue("@tag");
			product.cost = float.Parse(productXML.GetValue("@cost"));
			product.price = float.Parse(productXML.GetValue("@retail"));
			product.upgradeCost = float.Parse(productXML.GetValue("@upgrade"));
			product.time = float.Parse(productXML.GetValue("@time"));
			product.viability = int.Parse(productXML.GetValue("@viability"));
			product.customers = int.Parse(productXML.GetValue("@customers"));
			
			products.Add(product);
		}
		
		// Debug.Log(products);
		xmlSubNode = xmlList[ENTERTAINMENTS] as XMLNode;
		XMLNodeList entertainmentXML = xmlSubNode.GetNodeList("entertainments>0>entertainment");
		for (int j = 0; j < entertainmentXML.Count; j++) {
			XMLNode entertainmentsXML = entertainmentXML[j] as XMLNode;
			Entertainment entertainment = new Entertainment();
			
			entertainment.name = entertainmentsXML.GetValue("@name");
			entertainment.tag = entertainmentsXML.GetValue("@tag");
			entertainment.cost = float.Parse(entertainmentsXML.GetValue("@cost"));
			entertainment.price = float.Parse(entertainmentsXML.GetValue("@retail"));
			entertainment.upgradeCost = float.Parse(entertainmentsXML.GetValue("@upgrade"));
			entertainment.time = float.Parse(entertainmentsXML.GetValue("@time"));
			entertainment.viability = int.Parse(entertainmentsXML.GetValue("@viability"));
			entertainment.buyers = int.Parse(entertainmentsXML.GetValue("@buyers"));
			entertainment.advertisers = int.Parse(entertainmentsXML.GetValue("@advertisers"));
			// entertainment.priceable = entertainmentsXML.GetValue("@priceable");
			
			entertainments.Add(entertainment);
		}
		
		xmlSubNode = xmlList[SOFTWARES] as XMLNode;
		XMLNodeList softwareXML = xmlSubNode.GetNodeList("softwares>0>software");
		for (int j = 0; j < softwareXML.Count; j++) {
			XMLNode softwaresXML = softwareXML[j] as XMLNode;
			Software software = new Software();
			
			software.name = softwaresXML.GetValue("@name");
			software.tag = softwaresXML.GetValue("@tag");
			software.cost = float.Parse(softwaresXML.GetValue("@cost"));
			software.price = float.Parse(softwaresXML.GetValue("@retail"));
			software.upgradeCost = float.Parse(softwaresXML.GetValue("@upgrade"));
			software.time = float.Parse(softwaresXML.GetValue("@time"));
			software.viability = int.Parse(softwaresXML.GetValue("@viability"));
			software.buyers = int.Parse(softwaresXML.GetValue("@buyers"));
			// software.priceable = softwaresXML.GetValue("@priceable");
			
			softwares.Add(software);
		}
		
		xmlSubNode = xmlList[SERVICES] as XMLNode;
		XMLNodeList servicesXML = xmlSubNode.GetNodeList("services>0>service");
		for (int j = 0; j < servicesXML.Count; j++) {
			XMLNode serviceXML = servicesXML[j] as XMLNode;
			Service service = new Service();
			
			service.name = serviceXML.GetValue("@name");
			service.tag = serviceXML.GetValue("@tag");
			service.cost = float.Parse(serviceXML.GetValue("@cost"));
			service.price = float.Parse(serviceXML.GetValue("@retail"));
			service.upgradeCost = float.Parse(serviceXML.GetValue("@upgrade"));
			service.time = float.Parse(serviceXML.GetValue("@time"));
			service.viability = int.Parse(serviceXML.GetValue("@viability"));
			service.buyers = int.Parse(serviceXML.GetValue("@customers"));
			// service.priceable = serviceXML.GetValue("@priceable");
			service.profitMethod = serviceXML.GetValue("@profitMethod");
			
			services.Add(service);
		}
		
		xmlSubNode = xmlList[WORKERS] as XMLNode;
		XMLNodeList workersXML = xmlSubNode.GetNodeList("workers>0>worker");
		for (int j = 0; j < workersXML.Count; j++) {
			XMLNode workerXML = workersXML[j] as XMLNode;
			Worker worker = new Worker();
			
			worker.name = workerXML.GetValue("@name");
			worker.tag = workerXML.GetValue("@tag");
			worker.cost = float.Parse(workerXML.GetValue("@cost"));
			worker.discipline = workerXML.GetValue("@discipline");
			// worker.price = float.Parse(workerXMl.GetValue("@price"));
			// worker.upgradeCost = float.Parse(workerXMl.GetValue("@cost"));
			// worker.time = float.Parse(workerXMl.GetValue("@time"));
			// worker.viability = int.Parse(workerXMl.GetValue("@viability"));
			// worker.customers = int.Parse(workerXMl.GetValue("@customers"));
			
			workers.Add(worker);
		}
		
		xmlSubNode = xmlList[MARKETING] as XMLNode;
		XMLNodeList marketingXML = xmlSubNode.GetNodeList("marketing>0>tool");
		for (int j = 0; j < marketingXML.Count; j++) {
			XMLNode toolXML = marketingXML[j] as XMLNode;
			MarketingTool tool = new MarketingTool();
			
			tool.name = toolXML.GetValue("@name");
			tool.tag = toolXML.GetValue("@tag");
			tool.cost = float.Parse(toolXML.GetValue("@cost"));
			// tool.price = float.Parse(toolXML.GetValue("@price"));
			// tool.upgradeCost = float.Parse(toolXML.GetValue("@cost"));
			// tool.time = float.Parse(toolXML.GetValue("@time"));
			// tool.viability = int.Parse(toolXML.GetValue("@viability"));
			// tool.customers = int.Parse(toolXML.GetValue("@customers"));
			
			marketingTools.Add(tool);
		}			
	}
	
	private static XML instance = null;
	
	public static XML Instance(){
		if(instance == null){
			instance = (new GameObject("XML")).AddComponent<XML>();
		}
		return instance;
	}
}

public class Item{
	public float timeModifier = 1f;
	public string name = "";
	public string tag = "";
	public float cost;
	public float adjustedCost;
	
	public float price;
	public float adjustedPrice;
	
	// public float profit;
	public float upgradeCost;
	public float buyers;
	public float advertisers;
	public float adjustedAdvertisers;
	
	// public string priceable;
	
	public float consumerTimer;
	
	// public float productionTime;
	public float time;
	
	public int viability;
	public float viabilityLeft;
	
	public int customers;
	
	public int upgradeLevel;
	public int factoryLevel;
	public float factoryUpgradeModifier = 20f;
	public float factoryModifier = .05f;
	
	public int quantity = 0;
	
	public float GetFactoryUpgradeCost(){
		return adjustedCost * factoryUpgradeModifier;
	}
	
}

public class Product : Item{
	
	public float profit;
	public float margin;
	private float upgradeCostModifier = 500f;
	private float upgradeModifier = 1.15f;
	private float upgradePriceModifier = 1.15f;
	
	public float profitPerUnit;
	
	public void Start(){
		UpdateMarketValue();
		UpdateUpgradeCost();
	}
	
	public void Update(){
		if(quantity > 0){
			UpdateMarketValue();
			UpdateUpgradeCost();
			
			consumerTimer -= Time.deltaTime;
			
			if((consumerTimer % viability) == 0){
				quantity--;
			}
			
		}
	}
	
	public void UpdateMarketValue(){
		adjustedCost = cost + (upgradeLevel * upgradeModifier) - (factoryLevel * factoryModifier);
		
		adjustedPrice = price + (upgradeLevel * upgradeModifier);
		
		profit = (viability * adjustedPrice) - (adjustedCost * viability);
		
		margin = profit / (adjustedCost * 1000f);
		
		profitPerUnit = adjustedPrice - adjustedCost;
	}
	
	public void UpdateUpgradeCost(){
		upgradeCost = adjustedCost * upgradeCostModifier;
	}

	public float GetIncomePerSecond(){
		return profit / (time / 60f);
	}
}

public class Entertainment : Item{
	public float profit;
	public float margin;
	private float upgradeCostModifier = 5f;
	private float upgradeModifier = 1.15f;
	public float profitPerUnit;
	
	public void Start(){
		UpdateMarketValue();
		UpdateUpgradeCost();
	}
	
	public void Update(){
		if(quantity > 0){
			UpdateMarketValue();
			UpdateUpgradeCost();
			
			consumerTimer -= Time.deltaTime;
			
			
			if((consumerTimer % viability) == 0){
				quantity--;
			}
		}
	}
	
	public void UpdateMarketValue(){
		adjustedCost = cost + (upgradeLevel * upgradeModifier) - (factoryLevel * factoryModifier);
		
		adjustedPrice = price + (upgradeLevel * upgradeModifier);
		
		profit = ((8f * (buyers * time)) + (8f * adjustedAdvertisers)) - adjustedCost;
		margin = profit / adjustedCost;
		profitPerUnit = adjustedPrice - adjustedCost;
	}
	
	public void UpdateUpgradeCost(){
		upgradeCost = adjustedCost * upgradeCostModifier;
	}
	
	public float GetIncomePerSecond(){
		return  quantity * ( profit / viability);
	}
	
	public float GetIncomePerSecondPerItem(){
		return  profit / viability;
	}
}
public class Software : Item{
	public float profit;
	public float margin;
	private float upgradeCostModifier = .75f;
	private float upgradeModifier = 1.15f;
	public float profitPerUnit;
	
	public void Start(){
		UpdateMarketValue();
		UpdateUpgradeCost();
	}
	
	public void Update(){
		if(quantity > 0){
			UpdateMarketValue();
			UpdateUpgradeCost();
			
			consumerTimer -= Time.deltaTime;
			
			if((consumerTimer % viability) == 0){
				quantity--;
			}
		}
	}
	
	public void UpdateMarketValue(){
		adjustedCost = cost + (upgradeLevel * upgradeModifier) - (factoryLevel * factoryModifier);
		
		adjustedPrice = price + (upgradeLevel * upgradeModifier);
		
		profit = buyers * viability * adjustedPrice - adjustedCost;
		margin = profit / adjustedCost;
		profitPerUnit = adjustedPrice - adjustedCost;
	}
	
	public void UpdateUpgradeCost(){
		upgradeCost = adjustedCost * upgradeCostModifier;
	}
	
	public float GetIncomePerSecond(){
		return  quantity * ( profit / viability);
	}
	
	public float GetIncomePerSecondPerItem(){
		return  ( profit / viability);
	}
}
public class Service : Item{
	public float profit;
	public float margin;
	private float upgradeCostModifier = .75f;
	private float upgradeModifier = 1.15f;
	public float profitPerUnit;
	
	public string profitMethod;
	
	private int timedIncomeModifier = 1;
	
	public void Start(){
		DeterminePrice();
		UpdateMarketValue();
		UpdateUpgradeCost();
		
	}
	
	public void Update(){
		if(quantity > 0){
			UpdateMarketValue();
			UpdateUpgradeCost();
			
			consumerTimer -= Time.deltaTime;
			
			if((consumerTimer % viability) == 0){
				quantity--;
			}
		}
	}
	
	public void DeterminePrice(){
		switch(profitMethod){
			case "Monthly":
				timedIncomeModifier = 4;
				break;
			case "Transaction":
				timedIncomeModifier = 1;
				break;
			case "Ride":
				timedIncomeModifier = 1;
				break;
			case "Rocket":
				timedIncomeModifier = 1;
				break;
			default:
				break;
		}
	}
	
	public void UpdateMarketValue(){
		adjustedCost = cost + (upgradeLevel * upgradeModifier) - (factoryLevel * factoryModifier);
		
		adjustedPrice = price + (upgradeLevel * upgradeModifier);
		
		profit = (adjustedPrice/ timedIncomeModifier) * viability * buyers - adjustedCost;
		margin = profit / adjustedCost;
		profitPerUnit = adjustedPrice - adjustedCost;
	}
	
	public void UpdateUpgradeCost(){
		upgradeCost = adjustedCost * upgradeCostModifier;
	}
	
	public float GetIncomePerSecond(){
		return  quantity * ( profit / viability);
	}
	
	public float GetIncomePerSecondPerItem(){
		return  ( profit / viability);
	}
}
public class Worker : Item{
	public string discipline;
	public int workforce;
	
}
public class MarketingTool : Item{
	public int quantity;
}