using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	[SerializeField] Transform[] routes; 
	int routeToGo = 0; 
	float tParam = 0f; 
	bool coroutineAllowed = false; 
	bool traversedMap = false; 

	[SerializeField] float speed = 0.5f;  
	[SerializeField] int health; 
	[SerializeField] int damage; 

	float EnemyOffset = 1.0f; 

	public void SetUpEnemy(Transform[] pRoutes)
	{
		routes = pRoutes; 
		coroutineAllowed = true; 
	}

	void Update()
	{
		FollowBezierCurve(); 
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

		Vector3 p0 = routes[routeIndex].GetChild(0).position + new Vector3(0, EnemyOffset, 0); 
		Vector3 p1 = routes[routeIndex].GetChild(1).position + new Vector3(0, EnemyOffset, 0); 
		Vector3 p2 = routes[routeIndex].GetChild(2).position + new Vector3(0, EnemyOffset, 0); 
		Vector3 p3 = routes[routeIndex].GetChild(3).position + new Vector3(0, EnemyOffset, 0); 

		while (tParam < 1)
		{
			tParam += Time.deltaTime * speed; 

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

		if (routeToGo > routes.Length - 1)
		{
			//routeToGo = 0; 
			traversedMap = true; 
		}

		coroutineAllowed = true; 
	}
}
