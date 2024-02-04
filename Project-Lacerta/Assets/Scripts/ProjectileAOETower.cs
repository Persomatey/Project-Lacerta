using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAOETower : MonoBehaviour
{
	float blastRadius = 5f;
	int damage = 0;
	[SerializeField] float speed = 1; 
	[SerializeField] Transform sprite; 
	[SerializeField] GameObject boom;
	Transform target;
	Vector3 blastPosition;
	public float scale = 2.0f;
 
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
			OnExplode();
			Destroy(gameObject); 
		}

		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
		}

		timePassed += Time.deltaTime; 
		if (timePassed > rotInterval)
		{
			timePassed = 0; 
			sprite.transform.rotation = Quaternion.Euler( new Vector3(90, sprite.transform.rotation.eulerAngles.y + rotAmount, 0) );  
		}
	}

	void OnExplode()
    {
		EnemyBase[] enemies = GameObject.FindObjectsOfType<EnemyBase>();
		// compiler complained about this one vvvvv
		//aOEBoom.transform.SetScale(blastRadius, blastRadius, blastRadius);
		
        GameObject fire = Instantiate(boom, gameObject.transform);
		fire.transform.localScale = new Vector3(blastRadius, blastRadius, blastRadius);
        foreach (EnemyBase enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= blastRadius)
            {
                enemy.GetComponent<EnemyBase>().DamageEnemy(damage);
            }
        }

    }

	// not sure if this will work to visualize the explosion
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
		blastPosition = target.position;
	}
}
