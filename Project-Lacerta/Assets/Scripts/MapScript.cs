using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
	// Add an array of bezier curves 
	[SerializeField] Transform[] routes; 
	[SerializeField] WaveSO wave;

	private void Start()
	{
		StartCoroutine(StartWave()); 
	}

	IEnumerator StartWave()
	{
		for(int i = 0; i < wave.enemyPrefabsInOrder.Length; i++)
		{
			yield return new WaitForSeconds(wave.enemyPrefabTimes[i]); 
			GameObject newEnem = Instantiate(wave.enemyPrefabsInOrder[i], routes[0].GetChild(0).position, transform.rotation); 
			newEnem.GetComponent<EnemyBase>().SetUpEnemy(routes); 
		}
	}
}
