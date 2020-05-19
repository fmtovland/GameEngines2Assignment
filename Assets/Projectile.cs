using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage=10;
	public int timeout=5;

	void Start()
	{
		StartCoroutine(SelfDestruct());
	}

	public void OnTriggerEnter(Collider collider)
	{
		Fighter f=collider.gameObject.GetComponent<Fighter>();
		f.Damage(damage);
		Destroy(gameObject);
	}
	
	public IEnumerator SelfDestruct()
	{
		yield return new WaitForSeconds(timeout);
		Destroy(gameObject);
	}
}
