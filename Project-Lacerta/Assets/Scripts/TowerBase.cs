using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
	[SerializeField] float cooldown; 
	[SerializeField] float towerRange; 
	EnemyBase[] enemies; 
	protected List<EnemyBase> enemiesWithinRange; 
	protected bool checkDone = false; 

	protected void Start()
	{
		enemiesWithinRange = new List<EnemyBase>(); 
	}

	protected void Update()
	{
		if (!checkDone)
		{
			FindAllEnemies(); 
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
		yield return new WaitForSeconds(cooldown); 
		checkDone = false; 
	}

	// Just to visualize the radius in editor.
	// If you want to see this visualized in editor, toggle the gizmo button in the upper right corner of the scene view window (looks like a weird ball thing). 
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(this.transform.position, towerRange);
	}
}
