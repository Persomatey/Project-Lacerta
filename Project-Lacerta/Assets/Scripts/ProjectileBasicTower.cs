using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBasicTower : MonoBehaviour
{
	int damage = 0;
	[SerializeField] float speed = 1; 
	[SerializeField] Transform sprite; 
	Transform target;

	float rotInterval = 0.0001f; 
	float rotAmount = 1f; 
	float timePassed = 0f;

	private void Start()
	{
		Destroy(gameObject, 3f); 
	}

	private void Update()
	{
		if (damage == 0)
		{
			return; 
		}

		if (target == null)
		{
			Debug.Log("Destroying this proj because null target"); 
			Destroy(gameObject); 
		}

		if (target != null && Vector3.Distance(transform.position, target.position) < 0.1f)
		{
			target.GetComponent<EnemyBase>().DamageEnemy(damage); 
			AudioSystem.instance.PlayTowerAConnectSFX(); 
			Destroy(gameObject); 
		}
	}

	private void FixedUpdate()
	{
		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
		}
		
		timePassed += Time.deltaTime; 
		//if (timePassed > rotInterval)
		//{
		//	timePassed = 0; 
		//	sprite.transform.rotation = Quaternion.Euler( new Vector3(90, sprite.transform.rotation.eulerAngles.y + rotAmount, 0) );  
		//}
	}

	// This gets called by the tower that spawns it to set the damage and target and stuff. 
	// I figured I'd have the tower decide the damage it deals instead of the projectile itself in case we want to be able to upgrade towers later on. 
	public void SetupProjectile(Transform pTarget, int pDamage)
	{
		target = pTarget; 
		damage = pDamage; 
	}
}
