using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Boid
{
	public GameObject missile;
	public int hitpoints;
	public int ammunition;
	public int time_between_shots;

	bool reloading=false;

	void Start()
	{
		base.Start();
	}
	
	public void shoot(GameObject target)
	{
		if(reloading) return;

		GameObject missile1=Instantiate(missile);
		missile.GetComponent<Chase>().target=target;
		ammunition--;
		StartCoroutine(cooldown());
	}

	IEnumerator cooldown()
	{
		reloading=true;
		yield return new WaitForSeconds(time_between_shots);
		reloading=false;
	}
}
