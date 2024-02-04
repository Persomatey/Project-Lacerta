using UnityEngine;

public class ProjectileDisrupterTower : MonoBehaviour
{
	[SerializeField] float speed = 1; 
	[SerializeField] float stunLength = 2f; 
	public Transform target; 
	public bool activated = false;
	public int position; 

	private void Update()
	{
		

		if (target != null && Vector3.Distance(transform.position, target.position) < 0.1f)
		{
			//target.GetComponent<EnemyBase>().DamageEnemy(0); 
			target.GetComponent<EnemyBase>().Stun(stunLength); 
			Destroy(gameObject); 
		}

		if (activated && !target)
		{
			Debug.Log("<color=red>My target is dead! Destroying myself!</color>"); 
			Destroy(gameObject); 
		}
	}

	private void FixedUpdate()
	{
		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
		}
	}

	public void Activate(Transform pTarget)
	{
		transform.parent = null; 
		target = pTarget; 
		activated = true; 
		Debug.Log("ACTIVATED"); 
	}
}
