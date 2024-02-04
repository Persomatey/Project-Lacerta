using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
	[SerializeField] float cooldown; 
	[SerializeField] float towerRange; 
	EnemyBase[] enemies; 
	[SerializeField] protected List<EnemyBase> enemiesWithinRange; 
	[SerializeField] protected bool checkDone = false; 
	float tempRandFloat; 
	[SerializeField] public int towerCost; 
	protected int towerLevel; 
	[SerializeField] TextMeshPro lvlText; 
	[SerializeField] int damageStepPerLevel; 

	protected virtual void Start()
	{
		enemiesWithinRange = new List<EnemyBase>(); 
		tempRandFloat = Random.Range(0f, 1f); 
		towerLevel = 0; 
	}

	protected virtual void Update()
	{
		if (!checkDone)
		{
			FindAllEnemies(); 
		}

		if (towerLevel > 0)
		{
			lvlText.text = $"+{towerLevel+1}"; 
		}
	}

	// This finds all enemies on the map, then narrows it down to a small list of only the ones within its radius. 
	void FindAllEnemies()
	{
		checkDone = true; 
		enemies = GameObject.FindObjectsOfType<EnemyBase>(); 
		enemiesWithinRange.Clear(); 

		for(int i = 0; i < enemies.Length; i++)
		{
			if (Vector3.Distance(transform.position, enemies[i].transform.position) < towerRange)
			{
				enemiesWithinRange.Add(enemies[i]); 
			}
		}

		StartCoroutine(ResetCooldown()); 
	}

	IEnumerator ResetCooldown()
	{
		if (checkDone)
		{
			yield return new WaitForSeconds(tempRandFloat); 
			tempRandFloat = 0f; 
			IntervalEvent(); 
			yield return new WaitForSeconds(cooldown); 
			checkDone = false; 
		}
	}

	// leaving this blank becaause it'll be overriden by the child clas anyways  
	protected virtual void IntervalEvent()
	{

	}

	// Just to visualize the radius in editor.
	// If you want to see this visualized in editor, toggle the gizmo button in the upper right corner of the scene view window (looks like a weird ball thing). 
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(this.transform.position, towerRange);
	}

	private void OnMouseDown()
	{
		UpgradeTower(); 
	}

	void UpgradeTower()
	{
		Debug.Log("<color=magenta>Upgrade 1</color>"); 
		int upgradeCost = towerCost + (damageStepPerLevel * towerLevel); 
		Debug.Log("<color=magenta>Upgrade 2</color>"); 

		if ( GameObject.Find("Map").GetComponent<MapScript>().Gold > upgradeCost )
		{
			Debug.Log("<color=magenta>Upgrade 3</color>"); 
			GameObject.Find("Map").GetComponent<MapScript>().DecreaseGold( upgradeCost ); 
			Debug.Log("<color=magenta>Upgrade 4</color>"); 
			towerLevel++; 
			Debug.Log("<color=magenta>Upgrade 5</color>"); 
			Debug.Log($"Tower upgraded to {towerLevel}"); 
		}
	}
}
