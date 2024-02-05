using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	public enum EnemyType 
	{ 
		fast, 
		med, 
		slow
	}

	MapScript mapScript; 
	Transform[] routes; 
	int routeToGo = 0; 
	float tParam = 0f; 
	bool coroutineAllowed = false; 
	bool traversedMap = false; 

	[SerializeField] float maxHealth; 
	float curHealth;
	public float Health => curHealth;
	[SerializeField] private HealthBar healthBar;
	[SerializeField] int damage; 
	public int Damage => damage; 
	[SerializeField] float curSpeed = 0.5f;  
	float setSpeed; 
	[SerializeField] int gold; 
	int level = 0; 
	public int Level => level; 
	[SerializeField] int levelIncrement; 

	float EnemyOffset = 1.0f; 

	public bool stunned = false; 

	// This gets called by the MapScript that instantiates enemies 
	public void SetUpEnemy(MapScript pScript, Transform[] pRoutes, int pLevel)
	{
		mapScript = pScript; 
		routes = pRoutes; 
		coroutineAllowed = true; 
		level = pLevel; 
	    maxHealth += (float)(Level * levelIncrement); 
		gold += (level * levelIncrement); 
        curHealth = maxHealth;
		setSpeed = curSpeed;
		
		//max health can't be zero
		healthBar.UpdateHealthBar(maxHealth, curHealth);
	}

	void Update()
	{
		HealthCheck(); 
		StartCoroutine( DirectionChecker() ); 
	}

	IEnumerator DirectionChecker()
	{
		float lastPos = transform.position.x;
		yield return new WaitForEndOfFrame(); 
		float curPos = transform.position.x;
		float move = curPos - lastPos;
		
		if (move < 0)
		{
			transform.Find("Sprite").GetComponent<SpriteRenderer>().flipX = false; 
		}
		else
		{
			transform.Find("Sprite").GetComponent<SpriteRenderer>().flipX = true; 
		}
	}

	private void FixedUpdate()
	{
		if (stunned)
		{
			curSpeed = 0; 
		}
		else
		{
			curSpeed = setSpeed; 
		}
		
		FollowBezierCurve(); 

		if (transform.position.x > 11) // Attack if the enemy's position reaches the specified area 
		{
			//routeToGo = 0; 
			traversedMap = true; 
			EnemyAttack(); 
		}
	}

	void FollowBezierCurve()
	{
		if (coroutineAllowed && !traversedMap)
		{
			StartCoroutine(GoByTheRoute(routeToGo)); 
		}
	}

	IEnumerator GoByTheRoute(int routeIndex)
	{
		coroutineAllowed = false; 


		Vector3 p0 = routes[routeIndex].GetChild(0).position + new Vector3(0, EnemyOffset, 0);// + (Random.insideUnitSphere * 0.5f); 
		Vector3 p1 = routes[routeIndex].GetChild(1).position + new Vector3(0, EnemyOffset, 0) + (Random.insideUnitSphere * 0.5f); 
		Vector3 p2 = routes[routeIndex].GetChild(2).position + new Vector3(0, EnemyOffset, 0) + (Random.insideUnitSphere * 0.5f); 
		Vector3 p3 = routes[routeIndex].GetChild(3).position + new Vector3(0, EnemyOffset, 0);// + (Random.insideUnitSphere * 0.5f); 

		while (tParam < 1)
		{
			tParam += Time.deltaTime * curSpeed; 

			transform.position = 
				Mathf.Pow(1 - tParam, 3) * p0 + 
				3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 
				3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + 
				Mathf.Pow(tParam, 3) * p3; 

			transform.position = transform.position; 
			yield return new WaitForEndOfFrame(); 
		}

		tParam = 0f; 
		routeToGo += 1; 

		//if (routeToGo > routes.Length - 1) // Attack if the enemy finishd its final route 
		//{
		//	//routeToGo = 0; 
		//	traversedMap = true; 
		//	EnemyAttack(); 
		//}

		coroutineAllowed = true; 
	}

	public void DamageEnemy(int hitAmount)
	{
		curHealth -= hitAmount; 
		healthBar.UpdateHealthBar(maxHealth, curHealth);
	}

	void HealthCheck()
	{
		if (Health <= 0)
		{
			StartCoroutine(EnemyDeathSequence()); 
		}
	}

	// this coroutine just exists in case we want to add a death animation or something 
	IEnumerator EnemyDeathSequence()
	{
		yield return new WaitForEndOfFrame(); 
		mapScript.IncreaseGold(gold); 
		AudioSystem.instance.PlayEnemyDeathSFX(); 
		Destroy(gameObject); 
	}

	// Enemy made it all the way across
	void EnemyAttack()
	{
		Debug.Log("<color=red>Enemy made it all the way (oh no!)</color>"); 
		mapScript.DecreaseGold(gold); 
		AudioSystem.instance.PlayEnemyAttackSFX();
		Destroy(gameObject); 
	}

	public void Stun(float stunDuration)
	{
		stunned = true; 
		StartCoroutine(DelayUnstunEnemy(stunDuration)); 
	}

	IEnumerator DelayUnstunEnemy(float stunDuratio)
	{
		yield return new WaitForSeconds(stunDuratio); 
		stunned = false; 
	}
}
