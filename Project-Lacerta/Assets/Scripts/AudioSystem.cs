using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem instance; 
    private AudioSource source; 

    [Header("Music")]
    [SerializeField] private AudioClip menuMusic; 
	[SerializeField] private AudioClip gameplayMusic; 

    [Header("SFX")]
    [SerializeField] private AudioClip EnemySpawnedFastSFX;
    [SerializeField] private AudioClip EnemySpawnedMedSFX;
    [SerializeField] private AudioClip EnemySpawnedSlowSFX;
    [SerializeField] private AudioClip enemyAttackSFX;
    [SerializeField] private AudioClip enemyDeathSFX;

    [SerializeField] private AudioClip towerAAttackSFX;
    [SerializeField] private AudioClip towerAConnectSFX;

    [SerializeField] private AudioClip towerBAttackSFX;
    [SerializeField] private AudioClip towerBExplosionSFX;

    [SerializeField] private AudioClip towerCSpawnHelperSFX;
    [SerializeField] private AudioClip towerCHelperMoveSFX;
    [SerializeField] private AudioClip towerCHelperAttackSFX;

    [SerializeField] private AudioClip towerABuiltSFX;
    [SerializeField] private AudioClip towerBBuiltSFX;
    [SerializeField] private AudioClip towerCBuiltSFX;
    [SerializeField] private AudioClip towerUpgradeSFX;

    [SerializeField] private AudioClip menuSelectionSFX;
    [SerializeField] private AudioClip menuBackSFX;

	private void Awake()
	{
		source = (GetComponent<AudioSource>()) ? GetComponent<AudioSource>() : gameObject.AddComponent<AudioSource>(); 

        if (instance != null)
		{
			Destroy(gameObject); 
		}
		else 
		{ 
			instance = this; 
			DontDestroyOnLoad(gameObject); 
		}
	}

	#region Music

	public void PlayMenuMusic()
	{
		if(!menuMusic) { return; }

		source.clip = menuMusic; 
		source.loop = true; 
		source.Play(); 
	}

	public void PlayGameplayMusic()
	{
		if(!gameplayMusic) { return; }

		source.clip = gameplayMusic; 
		source.loop = true; 
		source.Play(); 
	}

	#endregion Music

	#region SFX

	public void PlayEnemySpawnedSFX(EnemyBase.EnemyType type)
	{
		switch(type)
		{
			case EnemyBase.EnemyType.fast: // fast enemy 
				if(!EnemySpawnedFastSFX) { return; }
				source.PlayOneShot(EnemySpawnedFastSFX); 
				break; 
			case EnemyBase.EnemyType.med: // med enemy 
				if(!EnemySpawnedMedSFX) { return; }
				source.PlayOneShot(EnemySpawnedMedSFX); 
				break; 
			case EnemyBase.EnemyType.slow: // slow enemy 
				if(!EnemySpawnedSlowSFX) { return; }
				source.PlayOneShot(EnemySpawnedSlowSFX); 
				break;
		}
	}

	public void PlayEnemyDeathSFX()
	{
		if(!enemyDeathSFX) { return; }

		source.PlayOneShot(enemyDeathSFX); 
	}

	public void PlayEnemyAttackSFX()
	{
		if(!enemyAttackSFX) { return; }

		source.PlayOneShot(enemyAttackSFX, 0.33f); 
	}

	public void PlayTowerAAttackSFX()
	{
		if(!towerAAttackSFX) { return; }

		source.PlayOneShot(towerAAttackSFX, 1f); 
	}

	public void PlayTowerAConnectSFX()
	{
		if(!towerAConnectSFX) { return; }

		source.PlayOneShot(towerAConnectSFX, 0.15f); 
	}

	public void PlayTowerBAttackSFX()
	{
		if(!towerBAttackSFX) { return; }

		source.PlayOneShot(towerBAttackSFX); 
	}

	public void PlayTowerBExplosionSFX()
	{
		if(!towerBExplosionSFX) { return; }

		source.PlayOneShot(towerBExplosionSFX, 0.15f); 
	}

	public void PlayTowerCSpawnHelperSFX()
	{
		if(!towerCSpawnHelperSFX) { return; }

		source.PlayOneShot(towerCSpawnHelperSFX, 0.25f); 
	}

	public void PlayTowerCHelperMoveSFX()
	{
		if(!towerCHelperMoveSFX) { return; }

		source.PlayOneShot(towerCHelperMoveSFX, 0.10f); 
	}

	public void PlayTowerCHelperAttackSFX()
	{
		if(!towerCHelperAttackSFX) { return; }

		source.PlayOneShot(towerCHelperAttackSFX, 0.15f); 
	}

	public void PlayTowerBuildSFX(TowerBase.TowerType type)
	{
		switch(type)
		{
			case TowerBase.TowerType.a: 
				if(!towerABuiltSFX) { return; }
				source.PlayOneShot(towerABuiltSFX); 
				break; 
			case TowerBase.TowerType.b: 
				if(!towerBBuiltSFX) { return; }
				source.PlayOneShot(towerBBuiltSFX); 
				break; 
			case TowerBase.TowerType.c: 
				if(!towerCBuiltSFX) { return; }
				source.PlayOneShot(towerCBuiltSFX); 
				break; 
		}
	}

	public void PlayTowerUpgradeSFX()
	{
		if(!towerUpgradeSFX) { return; }

		source.PlayOneShot(towerUpgradeSFX, 0.5f); 
	}

	public void PlayMenuSelectionSFX()
	{
		if(!menuSelectionSFX) { return; }

		source.PlayOneShot(menuSelectionSFX, 0.4f); 
	}

	public void PlayMenuSelectionBackSFX()
	{
		if(!menuBackSFX) { return; }

		source.PlayOneShot(menuBackSFX, 0.5f); 
	}

	#endregion SFX
}
