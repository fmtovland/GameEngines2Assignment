using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage=10;
	public int timeout=5;
	public string friend_tag;

	void Start()
	{
		StartCoroutine(SelfDestruct());
		transform.parent=null;
	}

	public void OnTriggerEnter(Collider collider)
	{
		if(collider.tag==friend_tag) return;
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
