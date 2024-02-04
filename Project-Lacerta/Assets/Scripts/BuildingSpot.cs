using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : MonoBehaviour
{
	[SerializeField] GameObject towerA; 
	[SerializeField] GameObject towerB; 
	[SerializeField] GameObject towerC; 

	bool towerBuiltHere = false; 

	private void Update()
	{
		// Temp for debugging purposes. Pressing 1, 2, 3 at the top of the keyboard will build a tower 
		//if (Input.GetKeyDown(KeyCode.Alpha1))
		//{
		//	BuildTowerA(); 
		//}

		//if (Input.GetKeyDown(KeyCode.Alpha2))
		//{
		//	BuildTowerB(); 
		//}

		//if (Input.GetKeyDown(KeyCode.Alpha3))
		//{
		//	BuildTowerC(); 
		//}

		transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = !towerBuiltHere; 
	}

	// Builds a TowerBasic at this location 
	public void BuildTowerA()
	{
		if (GameObject.Find("Map").GetComponent<MapScript>().Gold > towerA.GetComponent<TowerBase>().towerCost)
		{
			if (!towerBuiltHere)
			{
				Debug.Log($"Building a {towerA.name} here"); 
				Instantiate(towerA, transform.position, transform.rotation, transform); 
				GameObject.Find("Map").GetComponent<MapScript>().DecreaseGold(towerA.GetComponent<TowerBase>().towerCost); 
				towerBuiltHere = true; 
			}
			else
			{
				Debug.Log("<color=red>Cannot build a tower here because one already exists!</color>"); 
			}
		}
		else
		{
			Debug.Log("<color=red>Cannot build a tower here because you don't have enough gold!</color>"); 
		}
		
	}

	// Builds a ___ at this location 
	public void BuildTowerB()
	{
		if (!towerBuiltHere)
		{
			Debug.Log($"Building a {towerB.name} here"); 
			Instantiate(towerB, transform.position, transform.rotation, transform); 
			towerBuiltHere = true; 
		}
		else
		{
			Debug.Log("<color=red>Cannot build a tower here because one already exists!</color>"); 
		}
	}

	// Builds a ___ at this location 
	public void BuildTowerC()
	{
		if (!towerBuiltHere)
		{
			Debug.Log($"Building a {towerC.name} here"); 
			Instantiate(towerC, transform.position, transform.rotation, transform); 
			towerBuiltHere = true; 
		}
		else
		{
			Debug.Log("<color=red>Cannot build a tower here because one already exists!</color>"); 
		}
	}

	private void OnMouseDown()
	{
		Debug.Log($"Tower {gameObject.name} has been clicked on."); 
		//BuildTowerA(); 
		BuildTowerB(); 
	}
}
