using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

	public float gameTime;
	
	private TextMesh gameTimeText;
	
	public List<ProductionInterface> productsList = new List<ProductionInterface>();
	public List<ProductionInterface> entertainmentList = new List<ProductionInterface>();
	public List<ProductionInterface> servicesList = new List<ProductionInterface>();
	public List<ProductionInterface> softwareList = new List<ProductionInterface>();
	public List<WorkerInterface> workersList = new List<WorkerInterface>();
	public List<MarketingInterface> marketingList = new List<MarketingInterface>();
	
	public Color productColor;
	public Color entertainmentColor;
	public Color softwareColor;
	public Color serviceColor;
	public Color workerColor;
	public Color marketingColor;
	
	private float colorEdgeAdjustment = .2f;
	
	public Transform productPane;
	public Transform entertainmentPane;
	public Transform servicePane;
	public Transform softwarePane;
	public Transform marketingPane;
	public Transform workersPane;
	
	private XML xml;
	
	public void Awake(){
		gameTimeText = transform.Find("CompanyStatistics/CompanyStatisticsBar/Time").gameObject.GetComponent<TextMesh>();
		
		// productionLine = transform.Find("ProductionLine");
	}
	
	public void Start(){
		xml = XML.Instance();
		
		// LoadXMLInformation();
		
		CreateButtons();
	}
	
	public void Update(){
		gameTime += Time.deltaTime;
		
		UpdateGameTime();
	}
	
	public void ToggleSound(){
		Camera.main.gameObject.GetComponent<AudioListener>().enabled = !Camera.main.gameObject.GetComponent<AudioListener>().enabled;
		transform.Find("Tabs/MuteSound/Muted").gameObject.GetComponent<MeshRenderer>().enabled = !transform.Find("Tabs/MuteSound/Muted").gameObject.GetComponent<MeshRenderer>().enabled;
	}
	
	public void ToggleTimeSettings(){
		
	}
	
	private Color GenerateIncrementedColor(Color target, int increment, int totalIncrements){
		float redDifference = 1f - target.r;
		float greenDifference = 1f - target.g;
		float blueDifference = 1f - target.b;
		
		totalIncrements += 10;
		increment += 10; // Adjust away from white
		
		float redAdjustment = redDifference / totalIncrements;
		float greenAdjustment = greenDifference / totalIncrements;
		float blueAdjustment = blueDifference / totalIncrements;
		
		return new Color(target.r + (totalIncrements - increment) * redAdjustment, target.g + (totalIncrements - increment) * greenAdjustment, target.b + (totalIncrements - increment) * blueAdjustment);
	}
	
	private void CreateButtons(){
		GameObject g = null;

		float offsety = -2.4f;
		float offsetx = 3.81f;
		
		productPane = transform.Find("Products/ProductsPane");
		entertainmentPane = transform.Find("Entertainment/EntertainmentPane");
		servicePane = transform.Find("Services/ServicesPane");
		softwarePane = transform.Find("Software/SoftwarePane");
		marketingPane = transform.Find("Marketing/MarketingPane");
		workersPane = transform.Find("Workers/WorkersPane");
		
		Vector3 topLeft = new Vector3(-8f, 1.3f, 0f);
		
		Vector3 piScale = new Vector3(.62f, .62f, 1f);
		
		int size = 5;
		
		int numberPerColumn = size;
		
		for(int i = 0; i < xml.products.Count; i++){
			Product item = xml.products[i];
			
			g = Instantiate(Resources.Load("ProductionInterface", typeof(GameObject))) as GameObject;
			
			g.transform.parent = productPane;
			
			ProductionInterface pi = g.GetComponent<ProductionInterface>();
			
			pi.item = item;
			pi.product = item;
			
			pi.border.GetComponent<MeshRenderer>().material.color = GenerateIncrementedColor(productColor, i, xml.products.Count);
			pi.border.transform.Find("Edge").gameObject.GetComponent<MeshRenderer>().material.color = new Color(productColor.r * colorEdgeAdjustment, productColor.g * colorEdgeAdjustment, productColor.b * colorEdgeAdjustment, 1f);
			
			productsList.Add(pi);
				
			float marketingOffsetY = -1.8f;
			float marketingOffsetx = 3.5f;
			
			int col = i % 5;
			int row = i / 5;
		
			g.transform.localPosition = topLeft + new Vector3(col * offsetx, row * offsety, 0f);
			g.transform.localScale = piScale;
			

			
		}
		
		for(int i = 0; i < xml.entertainments.Count; i++){
			Entertainment item = xml.entertainments[i];
			
			g = Instantiate(Resources.Load("ProductionInterface", typeof(GameObject))) as GameObject;
			
			g.transform.parent = entertainmentPane;
			
			ProductionInterface pi = g.GetComponent<ProductionInterface>();
			
			pi.item = item;
			pi.entertainment = item;
			
			pi.border.GetComponent<MeshRenderer>().material.color = GenerateIncrementedColor(entertainmentColor, i, xml.products.Count);
			pi.border.transform.Find("Edge").gameObject.GetComponent<MeshRenderer>().material.color = new Color(entertainmentColor.r * colorEdgeAdjustment, entertainmentColor.g * colorEdgeAdjustment, entertainmentColor.b * colorEdgeAdjustment, 1f);
			
			entertainmentList.Add(pi);
			
			float entertainmentOffsetY = -3.3f;
			float entertainmentOffsetX = 4.7f;
			
			int col = i % 4;
			int row = i / 4;
			
			// topLeft = new Vector3(-7f, 1.3f, 0f);
			
			// piScale = new Vector3(.8f, .8f, 1f);
			
			g.transform.localPosition = new Vector3(-7.7f, 1f, 0f) + new Vector3(col * entertainmentOffsetX, row * entertainmentOffsetY, 0f);
			g.transform.localScale = new Vector3(.75f, .75f, 1f);
			
		
			
		}
		
		for(int i = 0; i < xml.softwares.Count; i++){
			Software item = xml.softwares[i];
			
			g = Instantiate(Resources.Load("ProductionInterface", typeof(GameObject))) as GameObject;
			
			g.transform.parent = softwarePane;
			
			ProductionInterface pi = g.GetComponent<ProductionInterface>();
			
			pi.border.GetComponent<MeshRenderer>().material.color = GenerateIncrementedColor(softwareColor, i, xml.products.Count);;
			pi.border.transform.Find("Edge").gameObject.GetComponent<MeshRenderer>().material.color = new Color(softwareColor.r * colorEdgeAdjustment, softwareColor.g * colorEdgeAdjustment, softwareColor.b * colorEdgeAdjustment, 1f);
			
			pi.item = item;
			pi.software = item;
			
			softwareList.Add(pi);
			
			float softwareOffsetY = -3.3f;
			float softwareOffsetX = 4.7f;
			
			int col = i % 4;
			int row = i / 4;
		
			// piScale = new Vector3(.8f, .8f, 1f);
		
			g.transform.localPosition = new Vector3(-7.7f, 1f, 0f) + new Vector3(col * softwareOffsetX, row * softwareOffsetY, 0f);
			g.transform.localScale = new Vector3(.75f, .75f, 1f);
			
			
		}
		
		for(int i = 0; i < xml.services.Count; i++){
			Service item = xml.services[i];
			
			g = Instantiate(Resources.Load("ProductionInterface", typeof(GameObject))) as GameObject;
			
			g.transform.parent = servicePane;
			
			ProductionInterface pi = g.GetComponent<ProductionInterface>();
			
			pi.item = item;
			pi.service = item;
			
			pi.border.GetComponent<MeshRenderer>().material.color = GenerateIncrementedColor(serviceColor, i, xml.products.Count);;
			pi.border.transform.Find("Edge").gameObject.GetComponent<MeshRenderer>().material.color = new Color(serviceColor.r * colorEdgeAdjustment, serviceColor.g * colorEdgeAdjustment, serviceColor.b * colorEdgeAdjustment, 1f);
			
			servicesList.Add(pi);
			
			// float marketingOffsetY = -1.8f;
			// float marketingOffsetx = 3.5f;
			
			int col = i % 5;
			int row = i / 5;
			
			int imod = i % size;
		
			g.transform.localPosition = topLeft + new Vector3(col * offsetx, row * offsety, 0f);
			g.transform.localScale = piScale;	
		}
		
		for(int i = 0; i < xml.workers.Count; i++){
			Worker xmlWorker = xml.workers[i];
			
			g = Instantiate(Resources.Load("WorkerInterface", typeof(GameObject))) as GameObject;
			
			switch(xmlWorker.discipline){
				case "products":
					g.transform.parent = workersPane.Find("ProductWorkers");
					break;
				case "marketing":
					g.transform.parent = workersPane.Find("MarketingWorkers");
					break;
				case "entertainment":
					g.transform.parent = workersPane.Find("EntertainmentWorkers");
					break;
				case "software":
					g.transform.parent = workersPane.Find("SoftwareWorkers");
					break;
				case "services":
					g.transform.parent = workersPane.Find("ServicesWorkers");
					break;
				default:
					
					break;
			}

			WorkerInterface wi = g.GetComponent<WorkerInterface>();

			wi.worker = xmlWorker;
			
			
			workersList.Add(wi);
			
			float workerOffset = -1.15f;
			
		
			g.transform.localPosition = new Vector3(0f, (g.transform.parent.childCount - 1) * workerOffset, 0f);
			g.transform.localScale = new Vector3(1.05f, 1.05f, 1f);
		}
		
		for(int i = 0; i < xml.marketingTools.Count; i++){
			MarketingTool item = xml.marketingTools[i];
						
			g = Instantiate(Resources.Load("MarketingInterface", typeof(GameObject))) as GameObject;
						
			g.transform.parent = marketingPane;
			
			MarketingInterface mi = g.GetComponent<MarketingInterface>();
			
			mi.marketing = item;
			
			// mi.border.GetComponent<MeshRenderer>().material.color = GenerateIncrementedColor(marketingColor, i, xml.products.Count);;
			// mi.border.transform.Find("Edge").gameObject.GetComponent<MeshRenderer>().material.color = new Color(marketingColor.r * colorEdgeAdjustment, marketingColor.g * colorEdgeAdjustment, marketingColor.b * colorEdgeAdjustment, 1f);
			
			marketingList.Add(mi);
			
			float marketingOffsetY = -1.8f;
			float marketingOffsetx = 3.8f;
			
			int col = i % 5;
			int row = i / 5;
			
			// int imod = i % size;
			
			// topLeft = new Vector3(-7.2f, 1.5f, -2f);
			
			g.transform.localPosition = new Vector3(-7.7f, 1.5f, 0f) + new Vector3(col * marketingOffsetx, row * marketingOffsetY, 0f);
			g.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
			
		}
	}
	
	private void UpdateGameTime(){
		string timeInHM = HelperFunctions.Timing.ConvertToHM(gameTime);
		string numberOfDays = HelperFunctions.Timing.GetDays(gameTime).ToString();

		gameTimeText.text = "Day " + numberOfDays + " " + timeInHM;
	}
	
	private static Gameplay instance;
	
	public static Gameplay Instance(){
		if(instance == null){
			instance = GameObject.FindObjectOfType<Gameplay>();
		}
		
		return instance;
	}
}
