using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAOETower : MonoBehaviour
{
	int damage = 0;
	[SerializeField] float speed = 2; 
	[SerializeField] Transform sprite; 
	Transform target;
 
	private void Start()
	{
		Destroy(gameObject, 1.5f); 
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
			OnExplode();
			Destroy(gameObject); 
		}

	void OnExplode()
    {
        GameObject[] enemies = GameObject.FindObjectsOfType<EnemyBase>();

        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, target.position) <= blastRadius)
            {
              target.GetComponent<EnemyBase>().DamageEnemy(damage);
            }
        }

    }

		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
		}
		
	}
	    private void OnDrawGizmosSelected()
    {
        //explosion
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }

	// This gets called by the tower that spawns it to set the damage and target and stuff. 
	// I figured I'd have the tower decide the damage it deals instead of the projectile itself in case we want to be able to upgrade towers later on. 
	public void SetupProjectile(Transform pTarget, int pDamage, int pBlastRadius)
	{
		target = pTarget; 
		damage = pDamage; 
		blastRadius = pBlastRadius;
	}
}
