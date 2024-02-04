using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
    float blastRadius;
	[SerializeField] SpriteRenderer sprite; 

    private void Start()
	{
		gameObject.transform.localScale = new Vector3(blastRadius, blastRadius, blastRadius);
		StartCoroutine(SpriteFlip()); 
		Destroy(gameObject, 0.5f); 
	}

	public void GiveBlastRadius(float pBlastRadius) 
	{
		blastRadius = pBlastRadius;
	}

	IEnumerator SpriteFlip()
	{
		yield return new WaitForSeconds(0.25f); 
		sprite.flipX = true; 
	}
}