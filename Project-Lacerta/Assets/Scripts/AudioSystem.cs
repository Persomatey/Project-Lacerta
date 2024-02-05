using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem instance; 
    private AudioSource sourceSFX; 
    private AudioSource sourceMusic; 
	[SerializeField] float musicVolume; 

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
		sourceSFX = gameObject.AddComponent<AudioSource>(); 
		sourceMusic = gameObject.AddComponent<AudioSource>(); 

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

		sourceMusic.clip = menuMusic; 
		sourceMusic.loop = true; 
		sourceMusic.Play(); 
	}

	public void PlayGameplayMusic()
	{
		if(!gameplayMusic) { return; }

		sourceMusic.clip = gameplayMusic; 
		sourceMusic.loop = true; 
		sourceMusic.volume = musicVolume; 
		sourceMusic.Play(); 
	}

	#endregion Music

	#region SFX

	public void PlayEnemySpawnedSFX(EnemyBase.EnemyType type)
	{
		switch(type)
		{
			case EnemyBase.EnemyType.fast: // fast enemy 
				if(!EnemySpawnedFastSFX) { return; }
				sourceSFX.PlayOneShot(EnemySpawnedFastSFX); 
				break; 
			case EnemyBase.EnemyType.med: // med enemy 
				if(!EnemySpawnedMedSFX) { return; }
				sourceSFX.PlayOneShot(EnemySpawnedMedSFX); 
				break; 
			case EnemyBase.EnemyType.slow: // slow enemy 
				if(!EnemySpawnedSlowSFX) { return; }
				sourceSFX.PlayOneShot(EnemySpawnedSlowSFX); 
				break;
		}
	}

	public void PlayEnemyDeathSFX()
	{
		if(!enemyDeathSFX) { return; }

		sourceSFX.PlayOneShot(enemyDeathSFX); 
	}

	public void PlayEnemyAttackSFX()
	{
		if(!enemyAttackSFX) { return; }

		sourceSFX.PlayOneShot(enemyAttackSFX, 0.33f); 
	}

	public void PlayTowerAAttackSFX()
	{
		if(!towerAAttackSFX) { return; }

		sourceSFX.PlayOneShot(towerAAttackSFX, 1f); 
	}

	public void PlayTowerAConnectSFX()
	{
		if(!towerAConnectSFX) { return; }

		sourceSFX.PlayOneShot(towerAConnectSFX, 0.15f); 
	}

	public void PlayTowerBAttackSFX()
	{
		if(!towerBAttackSFX) { return; }

		sourceSFX.PlayOneShot(towerBAttackSFX); 
	}

	public void PlayTowerBExplosionSFX()
	{
		if(!towerBExplosionSFX) { return; }

		sourceSFX.PlayOneShot(towerBExplosionSFX, 0.15f); 
	}

	public void PlayTowerCSpawnHelperSFX()
	{
		if(!towerCSpawnHelperSFX) { return; }

		sourceSFX.PlayOneShot(towerCSpawnHelperSFX, 0.25f); 
	}

	public void PlayTowerCHelperMoveSFX()
	{
		if(!towerCHelperMoveSFX) { return; }

		sourceSFX.PlayOneShot(towerCHelperMoveSFX, 0.10f); 
	}

	public void PlayTowerCHelperAttackSFX()
	{
		if(!towerCHelperAttackSFX) { return; }

		sourceSFX.PlayOneShot(towerCHelperAttackSFX, 0.15f); 
	}

	public void PlayTowerBuildSFX(TowerBase.TowerType type)
	{
		switch(type)
		{
			case TowerBase.TowerType.a: 
				if(!towerABuiltSFX) { return; }
				sourceSFX.PlayOneShot(towerABuiltSFX); 
				break; 
			case TowerBase.TowerType.b: 
				if(!towerBBuiltSFX) { return; }
				sourceSFX.PlayOneShot(towerBBuiltSFX); 
				break; 
			case TowerBase.TowerType.c: 
				if(!towerCBuiltSFX) { return; }
				sourceSFX.PlayOneShot(towerCBuiltSFX); 
				break; 
		}
	}

	public void PlayTowerUpgradeSFX()
	{
		if(!towerUpgradeSFX) { return; }

		sourceSFX.PlayOneShot(towerUpgradeSFX, 0.5f); 
	}

	public void PlayMenuSelectionSFX()
	{
		if(!menuSelectionSFX) { return; }

		sourceSFX.PlayOneShot(menuSelectionSFX, 0.4f); 
	}

	public void PlayMenuSelectionBackSFX()
	{
		if(!menuBackSFX) { return; }

		sourceSFX.PlayOneShot(menuBackSFX, 0.5f); 
	}

	#endregion SFX
}
