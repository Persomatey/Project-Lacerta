using UnityEngine;

public class TowerBasic : TowerBase
{
	[SerializeField] EnemyBase enemyTarget; 
	[SerializeField] GameObject projectile; 
	[SerializeField] int damage; 

	void Update()
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
		Debug.Log("Shooting at enemy"); 
		GameObject proj = Instantiate(projectile, transform.position, transform.rotation); 
		proj.GetComponent<ProjectileBasicTower>().SetupProjectile(enemyTarget.transform, damage); 
	}
}
