using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float size=2;
	public float rate=10;
	public int damage;

	// Update is called once per frame
	void Update()
	{
		float growth=rate*Time.deltaTime;
		transform.localScale += new Vector3(rate,rate,rate);
		if(size<transform.localScale.y) Destroy(transform.root.gameObject);
	}
	
	void OnTriggerStay(Collider collider)
	{
		Fighter fighter=collider.gameObject.GetComponent<Fighter>();
		fighter.Damage(damage);
	}
}
