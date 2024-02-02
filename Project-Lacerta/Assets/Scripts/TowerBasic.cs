using UnityEngine;

public class TowerBasic : TowerBase
{
	EnemyBase enemyTarget; 
	[SerializeField] GameObject projectile; 
	[SerializeField] int damage; 

	new void Update()
	{
		if (!checkDone)
		{ 
			if (enemiesWithinRange.Count > 0)
			{
				enemyTarget = enemiesWithinRange[0]; 
				ShootAtEnemy(); 
			}
		}

		base.Update(); 
	}

	// Adding the attack mechanics to the child classes in case we want to have unique behavior for some of these. 
	void ShootAtEnemy()
	{
		GameObject proj = Instantiate(projectile, transform.position, transform.rotation); 
		proj.GetComponent<ProjectileBasicTower>().SetupProjectile(enemyTarget.transform, damage); 
	}
}
