using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
    float blastRadius;
    private void Start()
	{
		gameObject.transform.localScale = new Vector3(blastRadius, blastRadius, blastRadius);
		Destroy(gameObject, .75f); 
	}

	public void GiveBlastRadius(float pBlastRadius) 
	{
		blastRadius = pBlastRadius;
	}

}