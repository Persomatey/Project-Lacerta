using System.Collections;
using UnityEngine;

public class MapScript : MonoBehaviour
{
	[SerializeField] int maxAllowedEnemies; 
	[SerializeField] bool loopingWaves; 
	[SerializeField] Transform[] routes; 
	[SerializeField] WaveSO wave;
	[SerializeField] private int gold; 
	public int Gold => gold; 

	private void Start()
	{
		StartCoroutine(StartWave()); 
	}

	public void IncreaseGold(int pGoldInc)
	{
		gold += pGoldInc; 
	}

	public void SpendGold(int pGoldDec)
	{
		if (Gold >= pGoldDec)
		{
			gold -= pGoldDec; 
		}
		else
		{
			Debug.Log($"Cannot decrease gold by {pGoldDec} because current gold {Gold} is less than that."); 
		}
	}

	IEnumerator StartWave()
	{
		Debug.Log("Starting wave"); 

		for(int i = 0; i < wave.enemyPrefabsInOrder.Length; i++)
		{
			yield return new WaitForSeconds(wave.enemyPrefabTimes[i]); 

			while (EnemyCount() >= maxAllowedEnemies) // if there are too many enemies on screen, then wait a second... 
			{
				Debug.Log("too many enemies, wait a sec..."); 
				yield return new WaitForSeconds(1); 
			}

			GameObject newEnem = Instantiate(wave.enemyPrefabsInOrder[i], routes[0].GetChild(0).position, transform.rotation); 
			newEnem.GetComponent<EnemyBase>().SetUpEnemy(this, routes); 
		}

		if (loopingWaves)
		{
			yield return new WaitForSeconds(wave.enemyPrefabTimes[wave.enemyPrefabTimes.Length - 1] * 2); 
			StartCoroutine(StartWave()); 
		}
	}

	int EnemyCount()
	{
		EnemyBase[] enemies = GameObject.FindObjectsOfType<EnemyBase>(); 
		return enemies.Length; 
	}
}
