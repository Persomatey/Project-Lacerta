using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : MonoBehaviour
{
	[Header("Tower Prefabs")]
	[SerializeField] public GameObject towerA; 
	[SerializeField] public GameObject towerB; 
	[SerializeField] public GameObject towerC; 

	[Header("Button References")]
	[SerializeField] GameObject buttonA; 
	[SerializeField] GameObject buttonB; 
	[SerializeField] GameObject buttonC; 

	[Header("Other")] 
	[SerializeField] GameObject costTMP; 
	bool towerBuiltHere = false; 
	public bool hoveringOverBuildingSpot = false; 
	public bool hoveringOverButton = false; 

	private void Update()
	{
		transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = !towerBuiltHere; 

		// DebuggingSpawnTowers(); 
		DisplayTowerOptions(); 
	}

	void DebuggingSpawnTowers()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			BuildTowerA();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			BuildTowerB();
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			BuildTowerC();
		}
	}

	public void BuildTower(int towerType) 
	{
		switch(towerType)
		{
			case 0: BuildTowerA(); break;  
			case 1: BuildTowerB(); break;  
			case 2: BuildTowerC(); break;  
		}
	}

	IEnumerator DisableCostTMP()
	{
		yield return new WaitForEndOfFrame(); 
		costTMP.SetActive(false); 
	}

	// Builds a TowerBasic at this location 
	void BuildTowerA()
	{
		if (GameObject.Find("Map").GetComponent<MapScript>().Gold > towerA.GetComponent<TowerBase>().towerCost)
		{
			if (!towerBuiltHere)
			{
				Debug.Log($"Building a {towerA.name} here"); 
				Instantiate(towerA, transform.position, transform.rotation, transform); 
				GameObject.Find("Map").GetComponent<MapScript>().DecreaseGold(towerA.GetComponent<TowerBase>().towerCost); 
				towerBuiltHere = true; 
				StartCoroutine(DisableCostTMP()); 
			}
			else
			{
				Debug.Log("<color=red>Cannot build a tower here because one already exists!</color>"); 
				AudioSystem.instance.PlayMenuSelectionBackSFX(); 
			}
		}
		else
		{
			Debug.Log("<color=red>Cannot build a tower here because you don't have enough gold!</color>"); 
			AudioSystem.instance.PlayMenuSelectionBackSFX(); 
		}
		
	}

	// Builds an AOE at this location 
	void BuildTowerB()
	{
		if (GameObject.Find("Map").GetComponent<MapScript>().Gold > towerB.GetComponent<TowerBase>().towerCost)
		{
			if (!towerBuiltHere)
			{
				Debug.Log($"Building a {towerB.name} here"); 
				Instantiate(towerB, transform.position, transform.rotation, transform); 
				GameObject.Find("Map").GetComponent<MapScript>().DecreaseGold(towerB.GetComponent<TowerBase>().towerCost); 
				towerBuiltHere = true; 
				StartCoroutine(DisableCostTMP()); 
			}
			else
			{
				Debug.Log("<color=red>Cannot build a tower here because one already exists!</color>"); 
				AudioSystem.instance.PlayMenuSelectionBackSFX(); 
			}
		}
		else
		{
			Debug.Log("<color=red>Cannot build a tower here because you don't have enough gold!</color>"); 
			AudioSystem.instance.PlayMenuSelectionBackSFX(); 
		}
	}

	// Builds a ___ at this location 
	void BuildTowerC()
	{
		if (GameObject.Find("Map").GetComponent<MapScript>().Gold > towerC.GetComponent<TowerBase>().towerCost)
		{
			if (!towerBuiltHere)
			{
				Debug.Log($"Building a {towerC.name} here"); 
				Instantiate(towerC, transform.position, transform.rotation, transform); 
				GameObject.Find("Map").GetComponent<MapScript>().DecreaseGold(towerC.GetComponent<TowerBase>().towerCost); 
				towerBuiltHere = true; 
				StartCoroutine(DisableCostTMP()); 
			}
			else
			{
				Debug.Log("<color=red>Cannot build a tower here because one already exists!</color>"); 
				AudioSystem.instance.PlayMenuSelectionBackSFX(); 
			}
		}
		else
		{
			Debug.Log("<color=red>Cannot build a tower here because you don't have enough gold!</color>"); 
			AudioSystem.instance.PlayMenuSelectionBackSFX(); 
		}
	}

	void DisplayTowerOptions()
	{
		if (!towerBuiltHere && (hoveringOverBuildingSpot || hoveringOverButton)) 
		{
			buttonA.SetActive(true); 
			buttonB.SetActive(true); 
			buttonC.SetActive(true); 
		}
		else
		{
			buttonA.SetActive(false); 
			buttonB.SetActive(false); 
			buttonC.SetActive(false); 
		}
	}

	private void OnMouseOver()
	{
		hoveringOverBuildingSpot = true; 
		
	}

	private void OnMouseExit()
	{
		hoveringOverBuildingSpot = false; 
	}
}
