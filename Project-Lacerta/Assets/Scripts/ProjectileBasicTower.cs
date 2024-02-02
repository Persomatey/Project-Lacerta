using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBasicTower : MonoBehaviour
{
	[SerializeField] int damage;
	[SerializeField] float speed = 1; 
	Transform target;

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.transform && col.transform.parent.GetComponent<EnemyBase>())
		{
			col.transform.parent.GetComponent<EnemyBase>().DamageEnemy(damage); 
			Destroy(gameObject); 
		}
	}
	
	// This gets called by the tower that spawns it to set the damage and target and stuff. 
	// I figured I'd have the tower decide the damage it deals instead of the projectile itself in case we want to be able to upgrade towers later on. 
	public void SetupProjectile(Transform pTarget, int pDamage)
	{
		target = pTarget; 
		damage = pDamage; 
	}
}
