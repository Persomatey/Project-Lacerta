using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBasicTower : MonoBehaviour
{
	[SerializeField] int damage;
	[SerializeField] float speed = 1; 
	[SerializeField] Transform sprite; 
	Transform target;

	float rotSpeed; 
	float rotInterval = 0.0001f; 
	float rotAmount = 1f; 
	float timePassed = 0f; 

	private void Update()
	{
		if (!target)
		{
			Destroy(gameObject); 
		}

		transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
		
		timePassed += Time.deltaTime; 
		if (timePassed > rotInterval)
		{
			timePassed = 0; 
			sprite.transform.rotation = Quaternion.Euler( new Vector3(90, sprite.transform.rotation.eulerAngles.y + rotAmount, 0) );  
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		//if (col.transform && col.transform.parent.GetComponent<EnemyBase>())
		if (col.transform && col.transform.parent == target)
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
