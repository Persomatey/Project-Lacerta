using System.Collections;
using UnityEngine;

public class MapScript : MonoBehaviour
{
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
		for(int i = 0; i < wave.enemyPrefabsInOrder.Length; i++)
		{
			yield return new WaitForSeconds(wave.enemyPrefabTimes[i]); 
			GameObject newEnem = Instantiate(wave.enemyPrefabsInOrder[i], routes[0].GetChild(0).position, transform.rotation); 
			newEnem.GetComponent<EnemyBase>().SetUpEnemy(routes); 
		}

		if (loopingWaves)
		{
			StartCoroutine(StartWave()); 
		}
	}
}
