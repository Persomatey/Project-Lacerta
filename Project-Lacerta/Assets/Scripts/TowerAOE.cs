using UnityEngine;

public class TowerAOE : TowerBase
{
	EnemyBase enemyTarget; 
	[SerializeField] GameObject projectile; 
	[SerializeField] int damage; 
	[SerializeField] int blastRadius; 

	protected override void Update()
	{
		if (enemiesWithinRange.Count > 0)
		{
			enemyTarget = enemiesWithinRange[0]; 
		}

		base.Update(); 
	}

	// Making this separate from just a straight up shooting function just in case we want to do something other than shooting with a tower type 
	protected override void IntervalEvent()
	{
		if (enemyTarget)
		{
			ShootAtEnemy(); 
		}
	}

	// Adding the attack mechanics to the child classes in case we want to have unique behavior for some of these. 
	void ShootAtEnemy()
	{
		GameObject proj = Instantiate(projectile, transform.position, transform.rotation); 
		proj.GetComponent<ProjectileAOETower>().SetupProjectile(enemyTarget.transform, damage + towerLevel, blastRadius + towerLevel); 
	}
}
