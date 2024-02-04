using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
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
	}

	private void OnMouseExit()
	{
		buildingSpot.hoveringOverButton = false; 
	}
}
