using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatak : MonoBehaviour
{
	void OnTriggerEnter(Collider collider)
	{
		transform.Find("Explosion").gameObject.SetActive(true);
	}
}
