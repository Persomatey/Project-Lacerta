using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
	[SerializeField] GameObject towerCostTMP; 
	[SerializeField] BuildingSpot buildingSpot;
	[Header("0=TowerA, 1=TowerB, 2=TowerC")]
	[SerializeField] int buttonNum; 

	private void OnMouseDown()
	{
		buildingSpot.BuildTower(buttonNum); 
	}
	
	private void OnMouseOver()
	{
		buildingSpot.hoveringOverButton = true; 
		int towerCost = 0; 
		switch(buttonNum)
		{
			case 0: towerCost = buildingSpot.towerA.GetComponent<TowerBase>().towerCost; break;  
			case 1: towerCost = buildingSpot.towerB.GetComponent<TowerBase>().towerCost; break;  
			case 2: towerCost = buildingSpot.towerC.GetComponent<TowerBase>().towerCost; break;  
		}
		towerCostTMP.GetComponent<TextMeshPro>().text = $"Cost ${towerCost}"; 
		towerCostTMP.SetActive(true); 
	}

	private void OnMouseExit()
	{
		buildingSpot.hoveringOverButton = false; 
		towerCostTMP.SetActive(false); 
	}

	public void DisableCostTMP()
	{
		buildingSpot.hoveringOverButton = false; 
		towerCostTMP.SetActive(false); 
	}
}
