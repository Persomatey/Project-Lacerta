using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDisrupt : TowerBase
{
	EnemyBase enemyTarget; 
	bool projectileSpawnCheckDone = true; 

	[Header("Prefab")]
	[SerializeField] GameObject projectile; 

	[Header("stuff")]
	[SerializeField] Transform[] projectileLocs; 
	[SerializeField] List<ProjectileDisrupterTower> projectiles;

	[Header("Tuning")]
	[SerializeField] float projectileSpawnInterval = 0; 

	protected override void Start()
	{
		base.Start(); 
		projectiles = new List<ProjectileDisrupterTower>(); 
		StartCoroutine(ResetProjectileSpawnCooldown()); 
	}

	protected override void Update()
	{
		enemyTarget = FindViableEnemy(); 

		base.Update(); 

		if (!projectileSpawnCheckDone)
		{
			projectileSpawnCheckDone = true; 
			StartCoroutine(ResetProjectileSpawnCooldown()); 

			Transform loc = null; 

			for(int i = 0; i < projectileLocs.Length; i++)
			{
				if (projectileLocs[i].childCount == 0)
				{
					loc = projectileLocs[i]; 
					break; 
				}
			}

			if (loc == null)
			{
				return; 
			}

			GameObject newProj = Instantiate(projectile, loc.position, transform.rotation, loc); 
			projectiles.Add(newProj.GetComponent<ProjectileDisrupterTower>()); 
			AudioSystem.instance.PlayTowerCSpawnHelperSFX();
		}
	}

	EnemyBase FindViableEnemy()
	{
		for(int i = 0; i < enemiesWithinRange.Count; i++)
		{
			if (!enemiesWithinRange[i].stunned)
			{
				return enemiesWithinRange[i]; 
			}
		}

		return null; 
	}

	protected override void IntervalEvent()
	{
		if (enemyTarget)
		{
			ShootAtEnemy(); 
		}
	}

	void ShootAtEnemy()
	{
		if (projectiles.Count > 0)
		{
			projectiles[0].Activate(enemyTarget.transform); 
			projectiles.RemoveAt(0); 
			enemyTarget = null; 
		}
	}

	IEnumerator ResetProjectileSpawnCooldown()
	{
		yield return new WaitForSeconds(projectileSpawnInterval); 
		projectileSpawnCheckDone = false; 
	}
}
