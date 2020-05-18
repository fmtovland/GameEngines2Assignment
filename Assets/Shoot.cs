using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public string enemy;

	public void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag(enemy))
		{
			transform.parent.gameObject.GetComponent<Fighter>().shoot(collider.gameObject);
		}
	}
}
