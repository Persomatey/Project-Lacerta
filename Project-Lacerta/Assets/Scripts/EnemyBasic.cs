using UnityEngine;

public class EnemyBasic : EnemyBase
{
	[SerializeField] EnemyType enemyType;

	private void Start()
	{
		AudioSystem.instance.PlayEnemySpawnedSFX(enemyType);
	}
}
