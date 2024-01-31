using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Waves/Create New Wave", order = 1)]
public class WaveSO : ScriptableObject 
{
	public GameObject[] enemyPrefabsInOrder; 
	public float[] enemyPrefabTimes; 
}
