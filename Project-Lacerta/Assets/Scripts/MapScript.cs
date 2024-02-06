using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MapScript : MonoBehaviour
{
	[SerializeField] TMP_FontAsset fontAsset; 
	[SerializeField] GameObject gameOverMenu; 
	[SerializeField] int maxAllowedEnemies; 
	[SerializeField] bool loopingWaves; 
	[SerializeField] Transform[] routes; 
	[SerializeField] WaveSO wave;
	[SerializeField] TextMeshProUGUI goldText; 
	[SerializeField] TextMeshProUGUI timeText; 
	private int gold; 
	public int Gold => gold; 
	int waveCount = 0; 
	public int WaveCount => waveCount;
	bool loseOnce = false; 

	private void Start()
	{
		StartCoroutine(StartWave()); 
		gold = 50; 
	}

	private void Update()
	{
		UpdateGoldAndTimeText(); 
		LoseChecker(); 

		if (Application.isEditor)
		{
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				IncreaseGold(100); 
			}
		}
	}

	void LoseChecker()
	{
		if (Gold <= 0)
		{
			if (!loseOnce)
			{
				loseOnce = true; 
				Debug.Log("<color=red>Lose Once</color>"); 

				gold = 0; 
				//Debug.Log("<color=red>You've lost!</color>"); 
				Time.timeScale = 0; 
				gameOverMenu.SetActive(true); 
			}
		}
	}

	private void UpdateGoldAndTimeText()
	{
		// Update Gold Text 
		goldText.SetText($"{Gold}"); 
		goldText.UpdateFontAsset(); 

		// Update Time Text 
		string mins = $"{TimeSpan.FromSeconds(Time.time).Minutes}"; 
		string secs = (TimeSpan.FromSeconds(Time.time).Seconds < 10) ? $"0{TimeSpan.FromSeconds(Time.time).Seconds}" : $"{TimeSpan.FromSeconds(Time.time).Seconds}"; 
		timeText.SetText($"{mins}:{secs}"); 
		timeText.UpdateFontAsset(); 
	}

	public void IncreaseGold(int pGoldInc)
	{
		gold += pGoldInc; 
	}

	public void DecreaseGold(int pGoldDec)
	{
		if (Gold >= pGoldDec)
		{
			gold -= pGoldDec; 
		}
		else
		{
			Debug.Log($"Cannot decrease gold by {pGoldDec} because current gold {Gold} is less than that."); 
			// Start lose sequence
		}
	}

	public void DamagePlayerGold(int pGoldDec)
	{
		gold -= pGoldDec; 
	}

	IEnumerator StartWave()
	{
		Debug.Log($"Starting wave {waveCount}"); 
		waveCount++; 

		for(int i = 0; i < wave.enemyPrefabsInOrder.Length; i++)
		{
			float time = wave.enemyPrefabTimes[i]; 
			float diff = 0.2f; 
			float modified = time - (waveCount * diff); 
			modified = ( modified < 0.25f ) ? 0.25f : modified; 
			Debug.Log($"Delaying for {modified}"); 
			yield return new WaitForSeconds(modified); 

			while (EnemyCount() >= maxAllowedEnemies) // if there are too many enemies on screen, then wait a second... 
			{
				yield return new WaitForSeconds(1); 
			}

			GameObject newEnem = Instantiate(wave.enemyPrefabsInOrder[i], routes[0].GetChild(0).position, transform.rotation); 
			newEnem.GetComponent<EnemyBase>().SetUpEnemy(this, routes, waveCount); 
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
